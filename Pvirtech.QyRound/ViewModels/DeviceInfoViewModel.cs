using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.ViewModels
{
    
    public class DeviceInfoViewModel : BindableBase
    {
        public int Id { get; set; }
        private string _deviceName;
        public string DeviceName
        {
            get { return _deviceName; }
            set { SetProperty(ref _deviceName, value); }
        }
        /// <summary>
        /// 温度/通道序号
        /// </summary>
        private string _tbarNo;
        public string TBarNo
        {
            get { return _tbarNo; }
            set { SetProperty(ref _tbarNo, value); }
        }
        private string _error;
        public string Error
        {
            get { return _error; }
            set { SetProperty(ref _error, value); }
        }
        /// <summary>
        /// 状态
        /// </summary>
        private bool _status;
        public bool Status
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }
        private bool _isOpen;
        public bool IsOpen
        {
            get { return _isOpen; }
            set { SetProperty(ref _isOpen, value); }
        }         
        
        private long _availableFreeSpace;
        public long AvailableFreeSpace
        {
            get { return _availableFreeSpace; }
            set { SetProperty(ref _availableFreeSpace, value); }
        }

        private long  _totalFreeSpace;
        public long TotalFreeSpace
        {
            get { return _totalFreeSpace; }
            set { SetProperty(ref _totalFreeSpace, value); }
        }

        private string _availableFreeSpaceText;
        public string AvailableFreeSpaceText
        {
            get { return _availableFreeSpaceText; }
            set { SetProperty(ref _availableFreeSpaceText, value); }
        }
        private string _totalFreeSpaceText;
        public string TotalFreeSpaceText
        {
            get { return _totalFreeSpaceText; }
            set { SetProperty(ref _totalFreeSpaceText, value); }
        }
       
    }
}
