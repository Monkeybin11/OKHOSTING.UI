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

		void IRelativePanel.SetAlignBottomWithPanel(IControl control)
		{
			NativeRelativePanel.SetAlignBottomWithPanel((UIElement) control, true);
		}

		void IRelativePanel.SetAlignHorizontalCenterWith(IControl control, IControl value)
		{
			NativeRelativePanel.SetAlignHorizontalCenterWith((UIElement) control, value);
		}

		void IRelativePanel.SetAlignHorizontalCenterWithPanel(IControl control)
		{
			NativeRelativePanel.SetAlignHorizontalCenterWithPanel((UIElement) control, true);
		}

		void IRelativePanel.SetAlignLeftWith(IControl control, IControl value)
		{
			NativeRelativePanel.SetAlignLeftWith((UIElement) control, value);
		}

		void IRelativePanel.SetAlignLeftWithPanel(IControl control)
		{
			NativeRelativePanel.SetAlignLeftWithPanel((UIElement) control, true);
		}

		void IRelativePanel.SetAlignRightWith(IControl control, IControl value)
		{
			NativeRelativePanel.SetAlignRightWith((UIElement) control, value);
		}

		void IRelativePanel.SetAlignRightWithPanel(IControl control)
		{
			NativeRelativePanel.SetAlignRightWithPanel((UIElement) control, true);
		}

		void IRelativePanel.SetAlignTopWith(IControl control, IControl value)
		{
			NativeRelativePanel.SetAlignTopWith((UIElement) control, value);
		}

		void IRelativePanel.SetAlignTopWithPanel(IControl control)
		{
			NativeRelativePanel.SetAlignTopWithPanel((UIElement) control, true);
		}

		void IRelativePanel.SetAlignVerticalCenterWith(IControl control, IControl value)
		{
			NativeRelativePanel.SetAlignVerticalCenterWith((UIElement) control, value);
		}

		void IRelativePanel.SetAlignVerticalCenterWithPanel(IControl control)
		{
			NativeRelativePanel.SetAlignVerticalCenterWithPanel((UIElement) control, true);
		}

		#endregion

		#region IDisposable

		void IDisposable.Dispose()
		{
		}

		#endregion
	}
}