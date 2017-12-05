using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Pvirtech.QyRound.Core;
using Pvirtech.QyRound.Core.Common;
using Pvirtech.QyRound.Core.Interactivity;
using Pvirtech.QyRound.SDK;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Pvirtech.QyRound.ViewModels
{
 
	public class MainWindowViewModel : BindableBase
	{
		private string _title = "上位机程序";
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
            ConnectCmd = new DelegateCommand(OnConnectedDevice);
            SdkInitCmd = new DelegateCommand(OnSDKInit);
        }

        private void OnSDKInit()
        {
            //获取存储SDK 版本
            int major = 0, minor =0;
            //SetConsoleCtrlHandler(CosonleHandler, TRUE);
            SDKApi.EagleData_GetVersion(ref major, ref minor);
            Console.WriteLine(string.Format("SDK Version: {0}.{1}\n", major, minor));
            LogHelper.WriteLog(string.Format("SDK Version: {0}.{1}\n", major, minor));
            //所有在本地计算机上网卡列表

            eagle_all_netcards nics = new eagle_all_netcards();

            int ret = SDKApi.EagleControl_GetSystemNICs(ref nics);
            LogHelper.WriteLog(nics.card_num.ToString());

            for (int i = 1; i <= nics.card_num; i++)
            {
                LogHelper.WriteLog(string.Format("{0} : {1}\n", i, nics.cards[i - 1].dev_description));
            }
            /*
    * set netcards used to connect to devices, here you can select one or more than one netcards
    * depend on your system topology.
    */
            //printf("select control netcards, input num such as: 1 and press ENTER!\n");
            //printf("Input 0 to finish select:");
            //eagle_all_netcards set_nics;

            //while (1)
            //{
            //    int num = 0;
            //    scanf("%d", &num);
            //    if (num == 0)
            //        break;
            //    if (num > 0 && num <= nics.card_num)
            //    {
            //        memcpy(&set_nics.cards[set_nics.card_num++], &nics.cards[num - 1], sizeof(eagle_netcard_info));
            //    }
            //}
            ret = SDKApi.EagleControl_SetControlNICs(nics);
            //printf("set control netcards:\n");
            //for (int i = 0; i < set_nics.card_num; i++)
            //{
            //    printf("%d : %s\n", i, set_nics.cards[i].dev_description);
            //}
            /*
            * get device number
            */
            int device_num = 0;
            ret = SDKApi.EagleControl_ScanAndGetDeviceNum(ref device_num);
            LogHelper.WriteLog(string.Format("get device numbers {0}", device_num));
            /*
            * get device ids
            */
            int[] device_ids = new int[device_num];
            int ids = 0;
            ret = SDKApi.EagleControl_GetDeviceIds(ref device_ids, device_num, ref ids);
            LogHelper.WriteLog("get device ids:\n");
            for (int i = 0; i < ids; i++)
            {
                LogHelper.WriteLog(string.Format(" ** {0}: device id {1}\n", i + 1, device_ids[i]));
            }
            /*
            * init data api
             */
            var initdevice = SDKApi.EagleData_Init();
            LogHelper.WriteLog(string.Format("init eagle data {0}", initdevice));

        }

        private void OnConnectedDevice()
        {
            
        }

        public DelegateCommand<object[]> SelectedCommand { get; private set; }
        public ICommand ConnectCmd { get; private set; }
        public ICommand SdkInitCmd { get; private set; }

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
				Title = "控制平台",
				InitMode = InitializationMode.OnDemand,
				IsDefaultShow = true,
				IsSelected = true,
			}); 
			//_systemInfos.Add(new SystemInfoViewModel()
			//{
			//	Id = "BanAnalysisView",
			//	Title = "禁入分析",
			//	InitMode = InitializationMode.OnDemand,
			//	IsDefaultShow = false,
			//});
			//_systemInfos.Add(new SystemInfoViewModel()
			//{
			//	Id = "ParkAnalysisView",
			//	Title = "停车场分析",
			//	InitMode = InitializationMode.OnDemand,
			//	IsDefaultShow = false,
			//});
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
			 
		}
		  
	}
}
