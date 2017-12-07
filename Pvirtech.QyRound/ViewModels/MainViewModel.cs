using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Pvirtech.QyRound.Commons;
using Pvirtech.QyRound.Core.Common;
using Pvirtech.QyRound.Models;
using Pvirtech.QyRound.SDK;
using Pvirtech.QyRound.Services;
using Pvirtech.TcpSocket.Scs.Communication.Messages;
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
            SelectedModeCmd = new DelegateCommand<CollectMode>(OnSelectedMode);
            SelectSignalCmd= new DelegateCommand<Signal>(OnSelectedSignal);
            SelectKdCmd = new DelegateCommand<BandWidth>(OnSelectedKd);
            CjStartCmd =new DelegateCommand(OnCjStart);
            SelectedRateCmd = new DelegateCommand<object>(OnSelectedRate);
        }
        /// <summary>
        /// 频率输出选择值
        /// </summary>
        /// <param name="silderValue"></param>
        private void OnSelectedRate(object silderValue)
        {
            int result = 60;
            int.TryParse(silderValue.ToString(), out result);
            SelectedRate = result;
        }
        /// <summary>
        /// 选择信号
        /// </summary>
        /// <param name="signal"></param>
        private void OnSelectedSignal(Signal signal)
        {
            
        }

        /// <summary>
        /// 选择带宽
        /// </summary>
        /// <param name="bandWidth"></param>
        private void OnSelectedKd(BandWidth bandWidth)
        {
             
        }

        /// <summary>
        /// 采集启停控制
        /// </summary>
        private void OnCjStart()
        {
            //var modeByte = new List<byte>();
            //modeByte.Add(0x7e);//帧头
            //modeByte.Add(0x03);//帧长度
            //modeByte.Add(0x00);//帧标识
            //modeByte.Add(collectMode.ModeByte);//数据
            ////和校验
            //var andValue = (byte)(0x30 + 0x00 + collectMode.ModeByte);
            //modeByte.Add(andValue);
            //modeByte.Add(0xf5);//帧尾
            ////var t1 = string.Join("", modeByte);
            //var t2 = CommonHelper.ByteToString(modeByte.ToArray());
            //var text = new ScsTextMessage(t2);
            //GatherVm.Client.SendMessage(text);
            if (CjButtonText == "开始采集")
            {
                CjButtonEnable = false;
                OnSendData(0x03, 0x02, 0x01);
                CjButtonText = "停止采集";
                CjButtonEnable = true;
            }
            else
            {
                CjButtonEnable = false;
                OnSendData(0x03, 0x02, 0x00);
                CjButtonText = "开始采集";
                CjButtonEnable = true;
            }
        }
        private void OnSendData(byte length,byte mark,byte data)
        {
            var modeByte = new List<byte>();
            modeByte.Add(0x7e);//帧头
            modeByte.Add(length);//帧长度
            modeByte.Add(mark);//帧标识
            modeByte.Add(data);//数据
            //和校验
            var andValue = (byte)(length+ mark + data);
            modeByte.Add(andValue);
            modeByte.Add(0xf5);//帧尾
            //var t1 = string.Join("", modeByte);
            var t2 = CommonHelper.ByteToString(modeByte.ToArray());
            var text = new ScsTextMessage(t2);
            if (GatherVm.Client.CommunicationState==TcpSocket.Scs.Communication.CommunicationStates.Connected)
            {
                GatherVm.Client.SendMessage(text);
            }
            else
            {
                MessageBox.Show("设备已断开连接！");
            }
        }
        /// <summary>
        /// 选中控制模式事件
        /// </summary>
        /// <param name="collectMode"></param>
        private void OnSelectedMode(CollectMode  collectMode)
        {
            OnSendData(0x03,0x00,collectMode.ModeByte);
            //var modeByte = new List<byte>();
            //modeByte.Add(0x7e);//帧头
            //modeByte.Add(0x03);//帧长度
            //modeByte.Add(0x00);//帧标识
            //modeByte.Add(collectMode.ModeByte);//数据
            ////和校验
            //var andValue =(byte)(0x30 + 0x00 + collectMode.ModeByte);
            //modeByte.Add(andValue);
            //modeByte.Add(0xf5);//帧尾
            ////var t1 = string.Join("", modeByte);
            //var t2 = CommonHelper.ByteToString(modeByte.ToArray());
            //var text = new ScsTextMessage(t2);
            //GatherVm.Client.SendMessage(text);
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
        public ICommand SelectedRateCmd { get; private set; }
        public ICommand ConnectCmd { get; private set; }
        public ICommand SdkInitCmd { get; private set; }
        public ICommand StartRecordCmd { get; private set; }
        public ICommand SelectedModeCmd { get; private set; }
        public ICommand CjStartCmd { get; private set; }
        public ICommand SelectSignalCmd { get; private set; }
        public ICommand SelectKdCmd { get; private set; }
        private CollectMode _selectCollectMode;
        public CollectMode SelectCollectMode
        {
            get { return _selectCollectMode; }
            set { SetProperty(ref _selectCollectMode, value); }

        }
        private Signal _selectsignal;
        public Signal SelectedSignal
        {
            get { return _selectsignal; }
            set { SetProperty(ref _selectsignal, value); }

        }
        private BandWidth _selectkd;
        public BandWidth SelectedKd
        {
            get { return _selectkd; }
            set { SetProperty(ref _selectkd, value); }

        }

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
        private string _cjbuttonText="开始采集";
        public string  CjButtonText
        {
            get { return _cjbuttonText; }
            set { SetProperty(ref _cjbuttonText, value); }
        }        
        private bool _cjbuttonEnable=true;
        public bool CjButtonEnable
        {
            get { return _cjbuttonEnable; }
            set { SetProperty(ref _cjbuttonEnable, value); }
        }
        private int _selectedRate = 60;
        public int SelectedRate
        {
            get { return _selectedRate; }
            set { SetProperty(ref _selectedRate, value); }
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
