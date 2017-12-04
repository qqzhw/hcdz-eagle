using Prism.Mvvm;
using Pvirtech.QyRound.Core.Common;
using Pvirtech.QyRound.Properties;
using Pvirtech.TcpSocket.Scs.Client;
using Pvirtech.TcpSocket.Scs.Communication;
using Pvirtech.TcpSocket.Scs.Communication.EndPoints.Tcp;
using Pvirtech.TcpSocket.Scs.Communication.Messages;
using System;
using System.Collections.Generic;
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
        #endregion
    }
}
