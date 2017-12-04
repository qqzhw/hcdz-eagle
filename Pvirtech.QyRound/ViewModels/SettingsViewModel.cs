
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Pvirtech.QyRound.Properties;
using System.Windows.Input;

namespace Pvirtech.QyRound.ViewModels
{
	public class SettingsViewModel: BindableBase
	{
		private readonly IEventAggregator _eventAggregator;
		private readonly IUnityContainer _container; 
		private readonly IServiceLocator _serviceLocator; 
		public SettingsViewModel(IUnityContainer container, IEventAggregator eventAggregator, IServiceLocator serviceLocator)
		{
			_container = container;
			_eventAggregator = eventAggregator; 
			_serviceLocator = serviceLocator;
			SaveCommand = new DelegateCommand(OnSaveData);
			Initializer();
		}

		private void OnSaveData()
		{
            Settings.Default.Byte0 = Byte0;
            Settings.Default.Byte1 = Byte1;
            Settings.Default.FrameTop = FrameTop;
            Settings.Default.CjIP = CjIP;
            Settings.Default.CjPort = CjPort;
            Settings.Default.SpIP = SpIP;
            Settings.Default.SpPort = SpPort;
            //Settings.Default.DwonloadUrl = DownloadUrl;
            //Settings.Default.LocalPath = LocalPath;
            Settings.Default.Save();

        }

		private void Initializer()
		{
            _byte0 = Settings.Default.Byte0;
            _byte1 = Settings.Default.Byte1;
            _frameTop = Settings.Default.FrameTop;
            _cjIp = Settings.Default.CjIP;
            _cjPort = Settings.Default.CjPort;
            _spIp = Settings.Default.SpIP;
           _spPort= Settings.Default.SpPort;
        }
		#region 属性

		private byte _byte0;
		public byte Byte0
		{
			get { return _byte0; }
			set { SetProperty(ref _byte0, value); }
		}
		private byte _byte1;
		public byte Byte1
        {
			get { return _byte1; }
			set { SetProperty(ref _byte1, value); }
		}

        private byte _frameTop;
        public byte FrameTop
        {
            get { return _frameTop; }
            set { SetProperty(ref _frameTop, value); }
        }
        private string _cjIp;
		public string CjIP
		{
			get { return _cjIp; }
			set { SetProperty(ref _cjIp, value); }
		}
		private int _cjPort;
		public int CjPort
		{
			get { return _cjPort; }
			set { SetProperty(ref _cjPort, value); }
		}
		private string _spIp;
		public string SpIP
		{
			get { return _spIp; }
			set { SetProperty(ref _spIp, value); }
		}
		private int _spPort;
		public int SpPort
        {
			get { return _spPort; }
			set { SetProperty(ref _spPort, value); }
		}

        

        public ICommand SaveCommand { get; private set; }

		#endregion
	}
}
