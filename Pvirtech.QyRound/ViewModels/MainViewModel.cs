using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Pvirtech.QyRound.Commons;
using Pvirtech.QyRound.Core.Common;
using Pvirtech.QyRound.SDK;
using Pvirtech.QyRound.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Pvirtech.QyRound.ViewModels
{

	public class MainViewModel : BindableBase
	{
		private readonly IEventAggregator _eventAggregator;
		private readonly IUnityContainer _container;
		private readonly IServiceLocator _serviceLocator;
		private readonly IQyRoundService _qyRoundService;
		private DispatcherTimer dispatcherTimer;
		private bool IsCompleted = false;
		private bool IsStop = false;

		public MainViewModel(IUnityContainer container, IEventAggregator eventAggregator, IServiceLocator serviceLocator, IQyRoundService qyRoundService)
		{
			_container = container;
			_eventAggregator = eventAggregator;
			_serviceLocator = serviceLocator;
			_qyRoundService = qyRoundService;
			dispatcherTimer = new DispatcherTimer(DispatcherPriority.Background)
			{
				Interval = TimeSpan.FromSeconds(1)
			};
			dispatcherTimer.Tick += DispatcherTimer_Tick;
			LoadData();//加载基本信息
            ConnectCmd = new DelegateCommand(OnConnectedDevice);
            SdkInitCmd = new DelegateCommand(OnSDKInit);
            StartRecordCmd= new DelegateCommand(OnStartRecord);
        }

        private void OnStartRecord()
        {
            
        }

        private void OnSDKInit()
        {
            //获取存储SDK 版本
            int major = 0, minor = 0;
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
            MessageBox.Show("设备数量"+device_num.ToString());
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
            var s = SDKApi.EagleControl_StartRecord(1, 0, 0, 0);
            /*
            * init data api
             */
            var initdevice = SDKApi.EagleData_Init();
            LogHelper.WriteLog(string.Format("init eagle data {0}", initdevice));
            if (initdevice>5000)
            {
                MessageBox.Show("初始化设备失败" + initdevice.ToString());
            }
        }

    

        private void OnConnectedDevice()
        {
            GatherVm.Connect();
            RadioVm.Connect();
        }

        public ICommand ConnectCmd { get; private set; }
        public ICommand SdkInitCmd { get; private set; }
        public ICommand StartRecordCmd { get; private set; }

        private GatherViewModel _gatherVm;
        public GatherViewModel GatherVm
        {
            get { return _gatherVm; }
            set { SetProperty(ref _gatherVm, value); }

        }
        private RadioViewModel _radioVm;
        public RadioViewModel RadioVm
        {
            get { return _radioVm; }
            set { SetProperty(ref _radioVm, value); }

        }
        private void LoadData()
		{
            _gatherVm = new GatherViewModel();
            _radioVm = new RadioViewModel();
        }

		private void DispatcherTimer_Tick(object sender, EventArgs e)
		{
		}
	}
}
