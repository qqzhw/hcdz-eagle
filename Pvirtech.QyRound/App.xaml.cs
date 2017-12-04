﻿
using Pvirtech.QyRound.Core.Common;
using System;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace Pvirtech.QyRound
{
	/// <summary>
	/// App.xaml 的交互逻辑
	/// </summary>
	public partial class App : Application
	{
	}
	/// <summary>
	/// App.xaml 的交互逻辑
	/// </summary>
	public partial class App : Application
	{
		private static Mutex SingleInstanceMutex = new Mutex(true, "{56A802DF-C96C-8769-BAA8-1BC527857BEB}");

		private static bool SingleInstanceCheck()
		{

			if (!SingleInstanceMutex.WaitOne(TimeSpan.Zero, true))
			{
				Process thisProc = Process.GetCurrentProcess();
				Process process = Process.GetProcessesByName(thisProc.ProcessName).FirstOrDefault(delegate (Process p)
				{
					if (p.Id != thisProc.Id)
					{
						return true;
					}
					return false;
				});
				if (process != null)
				{
					IntPtr mainWindowHandle = process.MainWindowHandle;
					if (NativeMethods.IsIconic(mainWindowHandle))
					{
						NativeMethods.ShowWindow(mainWindowHandle, 9);
					}
					NativeMethods.SetForegroundWindow(mainWindowHandle);
				}
				Application.Current.Shutdown(1);
				return false;
			}
			return true;
		}

		protected override void OnStartup(StartupEventArgs e)
		{           
            if (!SingleInstanceCheck())
			{
				return;
			}
			base.OnStartup(e);
			log4net.Config.XmlConfigurator.Configure();
			Initialize();
		}

		public void Initialize()
		{
			this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(App_DispatcherUnhandledException);
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

			Bootstrapper bootstrapper = new Bootstrapper();
			bootstrapper.Run();
		}

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			LogHelper.ErrorLog((Exception)e.ExceptionObject);
		}

		private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			LogHelper.ErrorLog(e.Exception);
		}

		internal static void FlushMemory()
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				NativeMethods.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
			}
			GC.Collect();
		}
	}
}
