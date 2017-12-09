using Pvirtech.QyRound.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.Commons
{
   
    public static class NativeMethods
    {
        public const UInt32 FLASHW_STOP = 0;
        public const UInt32 FLASHW_CAPTION = 1;
        public const UInt32 FLASHW_TRAY = 2;
        public const UInt32 FLASHW_ALL = 3;
        public const UInt32 FLASHW_TIMER = 4;
        public const UInt32 FLASHW_TIMERNOFG = 12;
        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMiliseconds;
        }
        public struct FLASHWINFO
        {
            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
        [DllImport("user32.dll")]
        public static extern bool FlashWindow(IntPtr handle, bool invert);

        [DllImport("user32.dll")]
        public static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsIconic(IntPtr hWnd);
        /// <summary>
        /// 释放内存
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>      
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet =
         CharSet.Auto, SetLastError = true)]
        public static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

        [DllImport("Kernel32.dll")]
        public static extern bool SetSystemTime(ref SystemTime time);
        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SystemTime time);
        [DllImport("Kernel32.dll")]
        public static extern void GetSystemTime(ref SystemTime time);
        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(ref SystemTime time);

        public static bool SyncLocalTime(DateTime currentTime)
        {
            SystemTime sysTime = new SystemTime();
            sysTime.wYear = (ushort)currentTime.Year;
            sysTime.wMonth = (ushort)currentTime.Month;
            sysTime.wDay = (ushort)currentTime.Day;
            sysTime.wHour = (ushort)currentTime.Hour;
            sysTime.wMinute = (ushort)currentTime.Minute;
            sysTime.wSecond = (ushort)currentTime.Second;
            try
            {
                return SetLocalTime(ref sysTime);//设置本机时间 
            }
            catch (Exception ex)
            {
                LogHelper.ErrorLog(ex);
                return false;
            }

        }
        public static DateTime ConverSystemTimeToDateTime(SystemTime time)
        {
            return new DateTime(time.wYear, time.wMonth, time.wDay, time.wHour, time.wMinute, time.wSecond);
        }
    }
}
