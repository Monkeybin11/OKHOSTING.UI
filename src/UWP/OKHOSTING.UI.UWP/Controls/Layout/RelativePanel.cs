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

		void IRelativePanel.Add(IControl control, RelativePanelHorizontalContraint horizontalContraint, IControl horizontalReference, RelativePanelVerticalContraint verticalContraint, IControl verticalReference)
		{
			if (control == null)
			{
				throw new ArgumentNullException(nameof(control));
			}

			//horizontal constraint

			if (horizontalReference == null)
			{
				switch (horizontalContraint)
				{
					case RelativePanelHorizontalContraint.CenterWith:
						NativeRelativePanel.SetAlignHorizontalCenterWithPanel((UIElement)control, true);
						break;

					case RelativePanelHorizontalContraint.LeftOf:
						throw new NotImplementedException();

					case RelativePanelHorizontalContraint.LeftWith:
						NativeRelativePanel.SetAlignHorizontalCenterWithPanel((UIElement)control, true);
						break;

					case RelativePanelHorizontalContraint.RightOf:
						throw new NotImplementedException();

					case RelativePanelHorizontalContraint.RightWith:
						NativeRelativePanel.SetAlignRightWithPanel((UIElement)control, true);
						break;
				}
			}
			else
			{
				switch (horizontalContraint)
				{
					case RelativePanelHorizontalContraint.CenterWith:
						NativeRelativePanel.SetAlignHorizontalCenterWith((UIElement) control, horizontalReference);
						break;

					case RelativePanelHorizontalContraint.LeftOf:
						NativeRelativePanel.SetLeftOf((UIElement) control, horizontalReference);
						break;

					case RelativePanelHorizontalContraint.LeftWith:
						NativeRelativePanel.SetAlignLeftWith((UIElement) control, horizontalReference);
						break;

					case RelativePanelHorizontalContraint.RightOf:
						NativeRelativePanel.SetRightOf((UIElement) control, horizontalReference);
						break;

					case RelativePanelHorizontalContraint.RightWith:
						NativeRelativePanel.SetAlignRightWith((UIElement) control, horizontalReference);
						break;
				}
			}

			//vertical constraint

			if (verticalReference == null)
			{
				switch (verticalContraint)
				{
					case RelativePanelVerticalContraint.AboveOf:
						throw new NotImplementedException();

					case RelativePanelVerticalContraint.BelowOf:
						throw new NotImplementedException();

					case RelativePanelVerticalContraint.BottomWith:
						NativeRelativePanel.SetAlignBottomWithPanel((UIElement) control, true);
						break;

					case RelativePanelVerticalContraint.CenterWith:
						NativeRelativePanel.SetAlignVerticalCenterWithPanel((UIElement) control, true);
						break;

					case RelativePanelVerticalContraint.TopWith:
						NativeRelativePanel.SetAlignTopWithPanel((UIElement) control, true);
						break;
				}
			}
			else
			{
				switch (verticalContraint)
				{
					case RelativePanelVerticalContraint.AboveOf:
						NativeRelativePanel.SetAbove((UIElement) control, verticalReference);
						break;

					case RelativePanelVerticalContraint.BelowOf:
						NativeRelativePanel.SetBelow((UIElement) control, verticalReference);
						break;

					case RelativePanelVerticalContraint.BottomWith:
						NativeRelativePanel.SetAlignBottomWith((UIElement) control, verticalReference);
						break;

					case RelativePanelVerticalContraint.CenterWith:
						NativeRelativePanel.SetAlignVerticalCenterWith((UIElement) control, verticalReference);
						break;

					case RelativePanelVerticalContraint.TopWith:
						NativeRelativePanel.SetAlignTopWith((UIElement) control, verticalReference);
						break;
				}
			}

			//finally add to children
			base.Children.Add((UIElement) control);
		}

		#endregion

		#region IDisposable

		void IDisposable.Dispose()
		{
		}

		#endregion
	}
}