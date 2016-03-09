using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System.Collections.Generic;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layout
{
	public class RelativePanel : global::Xamarin.Forms.RelativeLayout, IRelativePanel
	{
		public RelativePanel()
		{
			_Children = new ControlList(base.Children);
		}

		protected readonly ControlList _Children;

		#region IControl

		string IControl.Name
		{
			get; set;
		}

		bool IControl.Visible
		{
			get
			{
				return base.IsVisible;
			}
			set
			{
				base.IsVisible = value;
			}
		}

		bool IControl.Enabled
		{
			get
			{
				return base.IsEnabled;
			}
			set
			{
				base.IsEnabled = value;
			}
		}

		double? IControl.Width
		{
			get
			{
				return base.WidthRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.WidthRequest = value.Value;
				}
			}
		}

		double? IControl.Height
		{
			get
			{
				return base.HeightRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.HeightRequest = value.Value;
				}
			}
		}

		Thickness IControl.Margin
		{
			get; set;
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Current.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = Platform.Current.Parse(value);
			}
		}

		Color IControl.BorderColor
		{
			get; set;
		}

		Thickness IControl.BorderWidth
		{
			get; set;
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(Platform.Current.Parse(value), false);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Current.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(Platform.Current.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// </remmarks>
		object IControl.Tag
		{
			get; set;
		}

		#endregion

		#region IDisposable

		void IDisposable.Dispose()
		{
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

		
		#endregion
	}
}