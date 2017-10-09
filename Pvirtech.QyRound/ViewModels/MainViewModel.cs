﻿using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Prism.Events;
using Prism.Mvvm;
using Pvirtech.QyRound.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		}

		private void LoadData()
		{

		}

		private void DispatcherTimer_Tick(object sender, EventArgs e)
		{
		}
	}
}