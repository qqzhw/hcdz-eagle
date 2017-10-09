
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using Pvirtech.QyRound.Views;

namespace Pvirtech.QyRound
{
	public class QyRoundModule : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;
        public QyRoundModule(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
			 
		}
		 

		public void Initialize()
        {
            _regionManager.RegisterViewWithRegion("MainRegion", typeof(MainView));
           _unityContainer.RegisterTypeForNavigation<MainView>("MainView"); 
         //   _unityContainer.RegisterTypeForNavigation<FilesView>("FilesView");
           // _unityContainer.RegisterTypeForNavigation<SettingsView>("SettingsView");

        }
    }
}
