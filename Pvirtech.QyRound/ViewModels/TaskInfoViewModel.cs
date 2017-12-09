using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvirtech.QyRound.ViewModels
{
    public class TaskInfoViewModel: BindableBase
    {
        public int Id { get; set; }
        private string _taskName;
        public string TaskName
        {
            get { return _taskName; }
            set { SetProperty(ref _taskName, value); }
        }
        /// <summary>
        /// 通道序号
        /// </summary>
        private int _barNo ;
        public int BarNo
        {
            get { return _barNo; }
            set { SetProperty(ref _barNo, value); }
        }
        private long _dataSize;
        public long DataSize
        {
            get { return _dataSize; }
            set { SetProperty(ref _dataSize, value); }
        }
        private string _dataSizeText;
        public string DataSizeText
        {
            get { return _dataSizeText; }
            set { SetProperty(ref _dataSizeText, value); }
        }
        private DateTime _beginTime;
        public DateTime BeginTime
        {
            get { return _beginTime; }
            set { SetProperty(ref _beginTime, value); }
        }
        private DateTime _endTime;
        public DateTime EndTime
        {
            get { return _endTime; }
            set { SetProperty(ref _endTime, value); }
        }
    }
}
