using Prism.Mvvm;
using Pvirtech.QyRound.Core.Common;
using Pvirtech.QyRound.Models;
using Pvirtech.QyRound.Properties;
using Pvirtech.QyRound.SDK;
using Pvirtech.TcpSocket.Scs.Client;
using Pvirtech.TcpSocket.Scs.Communication;
using Pvirtech.TcpSocket.Scs.Communication.EndPoints.Tcp;
using Pvirtech.TcpSocket.Scs.Communication.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.ViewModels
{
   public  class RadioViewModel: BindableBase
    {
        public IScsClient Client { get; set; }
        public RadioViewModel()
        {
            Init();
            InitModel();
            string temp_time = "20091225091010";
            string results = DateTime.ParseExact(temp_time, "yyyyMMddHHmmss", null).ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void InitModel()
        {
            _signals = new ObservableCollection<Signal>();
            _signals.Add(new Signal() { Id = 0x00, Name = "阵列信号" });
            _signals.Add(new Signal() { Id = 0x01, Name = "标校信号" });
            _bandWidths = new ObservableCollection<BandWidth>();
            _bandWidths.Add(new BandWidth() { Id = 0x00, Name = "2MHz" });
            _bandWidths.Add(new BandWidth() { Id = 0x01, Name = "60MHz" });
        }

        private void Init()
        {
            _spIp = Settings.Default.SpIP;
            _spPort = Settings.Default.SpPort;
        }
        public void Connect()
        {
            try
            {

                //Create a client object to connect a server on 127.0.0.1 (local) IP and listens 10085 TCP port
                Client = ScsClientFactory.CreateClient(new ScsTcpEndPoint(SpIP, SpPort));
               
                Client.ConnectTimeout = 5;
                Client.MessageReceived += OnMessageReceived;
                Client.Connected += OnConnected;
                Client.Disconnected += OnDisconnected;
                Client.Connect(); //Connect to the server  
                //Send message to the server
                Client.SendMessage(new ScsTextMessage("3F", "q1"));

                //client.Disconnect(); //Close connection to server
            }
            catch (Exception ex)
            {
                Client.Dispose();
                LogHelper.ErrorLog(ex, "连接异常!");
            }
        }

        private void OnDisconnected(object sender, EventArgs e)
        {
            IsConnected = false;
        }

        private void OnConnected(object sender, EventArgs e)
        {
            var client = sender as IScsClient;
            if (client.CommunicationState == CommunicationStates.Connected)
            {
                IsConnected = true;
            }

        }
        /// <summary>
        /// 格式化数据
        /// </summary>
        /// <param name="deviceId"></param>
        public void ReinitDisk(int deviceId)
        {
            SDKApi.EagleControl_ReinitDisk(deviceId);
        }
        /// <summary>
        /// 格式化磁盘
        /// </summary>
        /// <param name="deviceId"></param>
        public void FormatDisk(int deviceId)
        {
            SDKApi.EagleControl_ReformatDisk(deviceId);
        }
        /// <summary>
        ///  恢复到出厂设置。
        /// </summary>
        /// <param name="deviceId"></param>
        public void RestoreConfig(int deviceId)
        {
            SDKApi.EagleControl_RestoreConfig(deviceId);
        }
        private void OnMessageReceived(object sender, MessageEventArgs e)
        {
            var message = e.Message as ScsTextMessage;
            var byteArray = Encoding.Default.GetBytes(message.Text);

        }
        #region 属性
        private bool _isConnected;
        public bool IsConnected
        {
            get { return _isConnected; }
            set { SetProperty(ref _isConnected, value); }
        }
        private int _spPort;
        public int SpPort
        {
            get { return _spPort; }
            set { SetProperty(ref _spPort, value); }
        }
        private string _spIp;
        public string SpIP
        {
            get { return _spIp; }
            set { SetProperty(ref _spIp, value); }
        }

        private ObservableCollection<Signal> _signals;
        public ObservableCollection<Signal> Signals
        {
            get { return _signals; }
            set { SetProperty(ref _signals, value); }
        }
        private ObservableCollection<BandWidth> _bandWidths;
        public ObservableCollection<BandWidth> BandWidths
        {
            get { return _bandWidths; }
            set { SetProperty(ref _bandWidths, value); }
        }
        #endregion
    }
}
