using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using NativeRelativePanel = Windows.UI.Xaml.Controls.RelativePanel;
using UIElement = Windows.UI.Xaml.UIElement;

namespace OKHOSTING.UI.UWP.Controls.Layout
{
	public class RelativePanel : NativeRelativePanel, IRelativePanel
	{
		protected readonly ControlList _Children;

		public RelativePanel()
		{
			_Children = new ControlList(base.Children);
		}

		#region IControl

		bool IControl.Visible
		{
			get
			{
				return base.Visibility == Windows.UI.Xaml.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Visible;
				}
				else
				{
					base.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
				}
			}
		}

		bool IControl.Enabled
		{
			get
			{
				return true;
			}
			set
			{
				if (!value)
				{
					throw new NotImplementedException();
				}
			}
		}

		double? IControl.Width
		{
			get
			{
				return base.Width;
			}
			set
			{
				if (value.HasValue)
				{
					base.Width = value.Value;
				}
			}
		}

		double? IControl.Height
		{
			get
			{
				return base.Height;
			}
			set
			{
				if (value.HasValue)
				{
					base.Height = value.Value;
				}
			}
		}

		Thickness IControl.Margin
		{
			get
			{
				return Platform.Current.Parse(base.Margin);
			}
			set
			{
				base.Margin = Platform.Current.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Platform.Current.Parse(value));
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return Platform.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush)base.BorderBrush).Color);
			}
			set
			{
				base.BorderBrush = new Windows.UI.Xaml.Media.SolidColorBrush(Platform.Current.Parse(value));
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				return Platform.Current.Parse(base.BorderThickness);
			}
			set
			{
				base.BorderThickness = Platform.Current.Parse(value);
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = Platform.Current.Parse(value);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = Platform.Current.Parse(value);
			}
		}

		#endregion

		#region IRelativePanel

		IList<IControl> IRelativePanel.Children
		{
			get
			{
				return _Children;
			}
		}

		//getters

		IControl IRelativePanel.GetAbove(IControl control)
		{
			return (IControl) NativeRelativePanel.GetAbove((UIElement) control);
		}

		IControl IRelativePanel.GetBelow(IControl control)
		{
			return (IControl) NativeRelativePanel.GetBelow((UIElement) control);
		}

		IControl IRelativePanel.GetLeftOf(IControl control)
		{
			return (IControl) NativeRelativePanel.GetLeftOf((UIElement) control);
		}

		IControl IRelativePanel.GetRightOf(IControl control)
		{
			return (IControl) NativeRelativePanel.GetRightOf((UIElement) control);
		}

		IControl IRelativePanel.GetAlignBottomWith(IControl control)
		{
			return (IControl) NativeRelativePanel.GetAlignBottomWith((UIElement) control);
		}

		IControl IRelativePanel.GetAlignHorizontalCenterWith(IControl control)
		{
			return (IControl) NativeRelativePanel.GetAlignHorizontalCenterWith((UIElement) control);
		}

		IControl IRelativePanel.GetAlignLeftWith(IControl control)
		{
			return (IControl) NativeRelativePanel.GetAlignLeftWith((UIElement) control);
		}

		IControl IRelativePanel.GetAlignRightWith(IControl control)
		{
			return (IControl) NativeRelativePanel.GetAlignRightWith((UIElement) control);
		}

		IControl IRelativePanel.GetAlignTopWith(IControl control)
		{
			return (IControl) NativeRelativePanel.GetAlignTopWith((UIElement) control);
		}

		IControl IRelativePanel.GetAlignVerticalCenterWith(IControl control)
		{
			return (IControl) NativeRelativePanel.GetAlignVerticalCenterWith((UIElement) control);
		}

		bool IRelativePanel.GetAlignBottomWithPanel(IControl control)
		{
			return NativeRelativePanel.GetAlignBottomWithPanel((UIElement) control);
		}

		bool IRelativePanel.GetAlignHorizontalCenterWithPanel(IControl control)
		{
			return NativeRelativePanel.GetAlignHorizontalCenterWithPanel((UIElement) control);
		}

		bool IRelativePanel.GetAlignLeftWithPanel(IControl control)
		{
			return NativeRelativePanel.GetAlignLeftWithPanel((UIElement) control);
		}

		bool IRelativePanel.GetAlignRightWithPanel(IControl control)
		{
			return NativeRelativePanel.GetAlignRightWithPanel((UIElement) control);
		}

		bool IRelativePanel.GetAlignTopWithPanel(IControl control)
		{
			return NativeRelativePanel.GetAlignTopWithPanel((UIElement) control);
		}

		bool IRelativePanel.GetAlignVerticalCenterWithPanel(IControl control)
		{
			return NativeRelativePanel.GetAlignVerticalCenterWithPanel((UIElement) control);
		}

		//setters

		void IRelativePanel.SetAbove(IControl control, IControl value)
		{
			NativeRelativePanel.SetAbove((UIElement) control, value);
		}

		void IRelativePanel.SetBelow(IControl control, IControl value)
		{
			NativeRelativePanel.SetBelow((UIElement) control, value);
		}

		void IRelativePanel.SetLeftOf(IControl control, IControl value)
		{
			NativeRelativePanel.SetLeftOf((UIElement) control, value);
		}

		void IRelativePanel.SetRightOf(IControl control, IControl value)
		{
			NativeRelativePanel.SetRightOf((UIElement) control, value);
		}

		void IRelativePanel.SetAlignBottomWith(IControl control, IControl value)
		{
			NativeRelativePanel.SetAlignBottomWith((UIElement) control, value);
		}

		void IRelativePanel.SetAlignBottomWithPanel(IControl control, bool value)
		{
			NativeRelativePanel.SetAlignBottomWithPanel((UIElement) control, value);
		}

		void IRelativePanel.SetAlignHorizontalCenterWith(IControl control, IControl value)
		{
			NativeRelativePanel.SetAlignHorizontalCenterWith((UIElement) control, value);
		}

		void IRelativePanel.SetAlignHorizontalCenterWithPanel(IControl control, bool value)
		{
			NativeRelativePanel.SetAlignHorizontalCenterWithPanel((UIElement) control, value);
		}

		void IRelativePanel.SetAlignLeftWith(IControl control, IControl value)
		{
			NativeRelativePanel.SetAlignLeftWith((UIElement) control, value);
		}

		void IRelativePanel.SetAlignLeftWithPanel(IControl control, bool value)
		{
			NativeRelativePanel.SetAlignLeftWithPanel((UIElement) control, value);
		}

		void IRelativePanel.SetAlignRightWith(IControl control, IControl value)
		{
			NativeRelativePanel.SetAlignRightWith((UIElement) control, value);
		}

		void IRelativePanel.SetAlignRightWithPanel(IControl control, bool value)
		{
			NativeRelativePanel.SetAlignRightWithPanel((UIElement) control, value);
		}

		void IRelativePanel.SetAlignTopWith(IControl control, IControl value)
		{
			NativeRelativePanel.SetAlignTopWith((UIElement) control, value);
		}

		void IRelativePanel.SetAlignTopWithPanel(IControl control, bool value)
		{
			NativeRelativePanel.SetAlignTopWithPanel((UIElement) control, value);
		}

		void IRelativePanel.SetAlignVerticalCenterWith(IControl control, IControl value)
		{
			NativeRelativePanel.SetAlignVerticalCenterWith((UIElement) control, value);
		}

		void IRelativePanel.SetAlignVerticalCenterWithPanel(IControl control, bool value)
		{
			NativeRelativePanel.SetAlignVerticalCenterWithPanel((UIElement) control, value);
		}

		#endregion

		#region IDisposable

		void IDisposable.Dispose()
		{
		}

		#endregion
	}
}