using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Pvirtech.QyRound.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void OnConnectedDevice()
        {
            GatherVm.Connect();
            RadioVm.Connect();
        }

        public ICommand ConnectCmd { get; private set; }
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
