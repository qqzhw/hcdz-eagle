using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pvirtech.QyRound.Controls
{ 
	public class SwitchControl : Control
	{
		public static DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(string), typeof(SwitchControl));
		public static DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(SwitchControl), new UIPropertyMetadata(false, new PropertyChangedCallback(OnValueChanged)));
		public static DependencyProperty SelectedBackgroundProperty = DependencyProperty.Register("SelectedBackground", typeof(Brush), typeof(SwitchControl));

		public Brush SelectedBackground
		{
			get
			{
				return (Brush)GetValue(SelectedBackgroundProperty);
			}
			set
			{
				SetValue(SelectedBackgroundProperty, value);
			}
		}

		private const string SwitchBorder = "switchBorder";
		private Border bottomBorder;
		static SwitchControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchControl), new FrameworkPropertyMetadata(typeof(SwitchControl)));
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			var _toggleBorder = GetTemplateChild(SwitchBorder) as Border;
			bottomBorder = GetTemplateChild("border") as Border;
			if (_toggleBorder != null)
			{
				//_toggleBorder.MouseLeftButtonDown += ToggleBorderMouseLeftButtonDown;
				//_toggleBorder.MouseEnter += _toggleBorder_MouseEnter;
				//SBorder = _toggleBorder; 
			}
		}

		void _toggleBorder_MouseEnter(object sender, MouseEventArgs e)
		{
			//   SelectedBackground=random.Next(0,3)
		}




		public bool IsSelected
		{
			get { return (bool)GetValue(IsSelectedProperty); }
			set { SetValue(IsSelectedProperty, value); }
		}
		public string Content
		{
			get
			{
				return (string)GetValue(ContentProperty);
			}
			set
			{
				SetValue(ContentProperty, value);
			}
		}
		private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			SwitchControl border = d as SwitchControl;
			if (border.IsSelected)
			{
				border.SelectedBackground = new SolidColorBrush(Color.FromRgb(34, 113, 172));
			}
		}

	}
}
