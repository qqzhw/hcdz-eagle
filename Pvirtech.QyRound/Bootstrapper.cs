using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Unity;
using Pvirtech.QyRound.Services;
using Pvirtech.QyRound.ViewModels;
using Pvirtech.QyRound.Views;
using System;
using System.Windows; 
 
namespace Pvirtech.QyRound
{
	class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            // var ident = WindowsIdentity.GetCurrent();
            // var principal = new GenericPrincipal(ident, new string[] { "User" });
            //Thread.CurrentPrincipal = principal; 
            //  AppDomain.CurrentDomain.SetThreadPrincipal(principal);
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }
        protected override void ConfigureServiceLocator()
        {
            base.ConfigureServiceLocator();
          	Container.RegisterType<MainWindowViewModel>(new ContainerControlledLifetimeManager());
			RegisterService();
        }
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
           // Container.RegisterType<IModuleInitializer, RoleBasedModuleInitializer>(new ContainerControlledLifetimeManager());
           
        }
		private void RegisterService()
		{
			Container.RegisterType<IQyRoundService, QyRoundService>(new ContainerControlledLifetimeManager());
			Container.RegisterType<SettingsViewModel>(new ContainerControlledLifetimeManager());
		}

		protected override void InitializeModules()
		{
			base.InitializeModules();
		 
		}
		protected override void ConfigureModuleCatalog()
		{
			Type typeModule = typeof(QyRoundModule );
			ModuleInfo module = new ModuleInfo
			{   //  ModuleA没有设置InitializationMode,默认为WhenAvailable
				ModuleName = typeModule.Name,
				ModuleType = typeModule.AssemblyQualifiedName,
			};
			base.ModuleCatalog.AddModule(module);
		}
		 

	}
}
