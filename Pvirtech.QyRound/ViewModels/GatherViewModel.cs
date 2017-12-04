﻿using Prism.Mvvm;
using Pvirtech.QyRound.Properties;
using Pvirtech.TcpSocket.Scs.Client;
using Pvirtech.TcpSocket.Scs.Communication.EndPoints.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pvirtech.TcpSocket.Scs.Communication.Messages;
using Pvirtech.QyRound.Core.Common;
using Pvirtech.TcpSocket.Scs.Communication;

namespace Pvirtech.QyRound.ViewModels
{
    /// <summary>
    /// 数据采集控制类
    /// </summary>

    public class GatherViewModel : BindableBase
    {
        public  IScsClient Client { get; set; }
        public GatherViewModel()
        {
            Init();
        }
        private void Init()
        {
            _cjIp = Settings.Default.CjIP;
            _cjPort = Settings.Default.CjPort;
        }
        public void Connect()
        {
            try
            {

                //Create a client object to connect a server on 127.0.0.1 (local) IP and listens 10085 TCP port
                Client = ScsClientFactory.CreateClient(new ScsTcpEndPoint(CjIP, CjPort));
                // client.WireProtocol = new CustomWireProtocol(); //Set custom wire protocol
                //Register to MessageReceived event to receive messages from server.
                Client.ConnectTimeout = 5;
                Client.MessageReceived +=OnMessageReceived;
                Client.Connected +=OnConnected;
                Client.Disconnected +=OnDisconnected;
                Client.Connect(); //Connect to the server  
                //Send message to the server
                //findItem.Client.SendMessage(new ScsTextMessage("3F", "q1"));

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
        private int _cjPort;
        public int CjPort
        {
            get { return _cjPort; }
            set { SetProperty(ref _cjPort, value); }
        }
        private string _cjIp;
        public string CjIP
        {
            get { return _cjIp; }
            set { SetProperty(ref _cjIp, value); }
        }
        #endregion
    }
}
