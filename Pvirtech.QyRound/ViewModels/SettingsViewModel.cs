
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
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
		 
		}

		private void Initializer()
		{
		 
		}
		#region 属性

		private string _bar0;
		public string Bar0
		{
			get { return _bar0; }
			set { SetProperty(ref _bar0,value); }
		}
		private string _bar1;
		public string Bar1
		{
			get { return _bar1; }
			set { SetProperty(ref _bar1, value); }
		}
		private string _bar2;
		public string Bar2
		{
			get { return _bar2; }
			set { SetProperty(ref _bar2, value); }
		}
		private string _bar3;
		public string Bar3
		{
			get { return _bar3; }
			set { SetProperty(ref _bar3, value); }
		}
		private string _bar4;
		public string Bar4
		{
			get { return _bar4; }
			set { SetProperty(ref _bar4, value); }
		}
		private string _bar5;
		public string Bar5
		{
			get { return _bar5; }
			set { SetProperty(ref _bar5, value); }
		}

		public ICommand SaveCommand { get; private set; }

		#endregion
	}
}
