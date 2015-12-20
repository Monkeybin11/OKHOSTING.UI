using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms.Controls
{
	public class PasswordTextBox : global::Xamarin.Forms.Entry, IPasswordTextBox
	{
		public PasswordTextBox()
		{
			base.IsPassword = true;
		}


		void IDisposable.Dispose()
		{
		}

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
				return App.Current.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = App.Current.Parse(value);
			}
		}

		Color IControl.BorderColor
		{
			get;
			set;
		}

		Thickness IControl.BorderWidth
		{
			get;
			set;
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return App.Current.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(App.Current.Parse(value), false);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Current.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(App.Current.Parse(value), false);
			}
		}

		#endregion
	}
}