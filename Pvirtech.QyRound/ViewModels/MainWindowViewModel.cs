using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Pvirtech.QyRound.Core;
using Pvirtech.QyRound.Core.Interactivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.ViewModels
{
 
	public class MainWindowViewModel : BindableBase
	{
		private string _title = "青羊公安绕圈分析平台";
		public string Title
		{
			get { return _title; }
			set { SetProperty(ref _title, value); }
		}
		private readonly IEventAggregator _eventAggregator;
		private readonly IUnityContainer _container;
		private readonly IRegionManager _regionManager;
		private readonly IModuleManager _moduleManager;
		private readonly IServiceLocator _serviceLocator;
		public MainWindowViewModel(IUnityContainer container, IEventAggregator eventAggregator, IRegionManager regionManager, IModuleManager moduleManager, IServiceLocator serviceLocator)
		{
			_container = container;
			_eventAggregator = eventAggregator;
			_regionManager = regionManager;
			_moduleManager = moduleManager;
			_serviceLocator = serviceLocator;
			CustomPopupRequest = new InteractionRequest<INotification>();
			CustomPopupCommand = new DelegateCommand(RaiseCustomPopup);
			_systemInfos = new ObservableCollection<SystemInfoViewModel>();
			SelectedCommand = new DelegateCommand<object[]>(OnItemSelected);
		}
		public DelegateCommand<object[]> SelectedCommand { get; private set; }
		private ObservableCollection<SystemInfoViewModel> _systemInfos;
		public ObservableCollection<SystemInfoViewModel> SystemInfos
		{
			get { return _systemInfos; }
			set { SetProperty(ref _systemInfos, value); }
		}
		public InteractionRequest<INotification> CustomPopupRequest { get; set; }
		public DelegateCommand CustomPopupCommand { get; set; }
		/// <summary>
		/// 加载设置选项
		/// </summary>
		public void InitLoadSetting()
		{

		}

		[InjectionMethod]
		public void Init()
		{ 
			
			InitHeader();


			//string fileName = "testdb.bak";
			//String sourceFullPath = Path.Combine("D:\\", fileName);
			//if (!File.Exists(sourceFullPath))
			//{
			//	throw new Exception("A file given by the sourcePath doesn't exist."); 
			//}

			//String targetFullPath = Path.Combine("F:\\5555\\", fileName); 


			//FileUtilities.CreateDirectoryIfNotExist(Path.GetDirectoryName(targetFullPath));

			//FileUtilities.CopyFileEx(sourceFullPath, targetFullPath, token);

		 

		}
		  
		private void InitHeader()
		{
			_systemInfos.Add(new SystemInfoViewModel()
			{
				Id = "MainView",
				Title = "数据分析",
				InitMode = InitializationMode.OnDemand,
				IsDefaultShow = true,
				IsSelected = true,
			}); 
			_systemInfos.Add(new SystemInfoViewModel()
			{
				Id = "FilesView",
				Title = "文件管理",
				InitMode = InitializationMode.OnDemand,
				IsDefaultShow = false,
			});
			_systemInfos.Add(new SystemInfoViewModel()
			{
				Id = "SettingsView",
				Title = "基本设置",
				InitMode = InitializationMode.OnDemand,
				IsDefaultShow = false,
			});
			 
		}

		private void RaiseCustomPopup()
		{

		}

		private void OnItemSelected(object[] selectedItems)
		{
			if (selectedItems != null && selectedItems.Count() > 0)
			{
				foreach (var item in _systemInfos)
				{
					item.IsSelected = false;
				}
				var model = selectedItems[0] as SystemInfoViewModel;
				model.IsSelected = true;
				var region = _regionManager.Regions["MainRegion"]; 
				_regionManager.RequestNavigate("MainRegion", model.Id, navigationCallback);
				//  CustomPopupRequest.Raise(new Notification { Title = "Custom Popup", Content = "Custom Popup Message " });
			}
		}
		 

		private void navigationCallback(NavigationResult result)
		{
			var s = result;
		}
		  
	}
}
