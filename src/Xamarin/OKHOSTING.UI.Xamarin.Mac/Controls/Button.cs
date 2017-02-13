using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Mac.Controls
{
	public class Button : global::Xamarin.Mac.Button, IButton
	{
		public Button()
		{
			base.Clicked += Button_Clicked;
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			Click?.Invoke(sender, e);
		}

		public event EventHandler Click;

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
				return Platform.Current.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = Platform.Current.Parse(value);
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return Platform.Current.Parse(base.BorderColor);
			}
			set
			{
				base.BorderColor = Platform.Current.Parse(value);
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				return new Thickness(base.BorderWidth);
			}
			set
			{
				if (value.Top.HasValue)
				{
					base.BorderWidth = value.Top.Value;
				}
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Mac.LayoutOptions(Platform.Current.Parse(value), false);
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
				base.VerticalOptions = new global::Xamarin.Mac.LayoutOptions(Platform.Current.Parse(value), false);
			}
		}

		#endregion

		#region ITextControl

		string ITextControl.FontFamily
		{
			get
			{
				return base.FontFamily;
			}
			set
			{
				base.FontFamily = value;
			}
		}

		Color ITextControl.FontColor
		{
			get
			{
				return Platform.Current.Parse(base.TextColor);
			}
			set
			{
				base.TextColor = Platform.Current.Parse(value);
			}
		}

		bool ITextControl.Bold
		{
			get
			{
				return base.FontAttributes.HasFlag(global::Xamarin.Mac.FontAttributes.Bold);
			}
			set
			{
				base.FontAttributes = global::Xamarin.Mac.FontAttributes.Bold;
			}
		}

		bool ITextControl.Italic
		{
			get
			{
				return base.FontAttributes.HasFlag(global::Xamarin.Mac.FontAttributes.Italic);
			}
			set
			{
				base.FontAttributes = global::Xamarin.Mac.FontAttributes.Italic;
			}
		}

		bool ITextControl.Underline
		{
			get;
			set;
		}

		HorizontalAlignment ITextControl.TextHorizontalAlignment
		{
			get;
			set;
		}

		VerticalAlignment ITextControl.TextVerticalAlignment
		{
			get;
			set;
		}

		Thickness ITextControl.TextPadding
		{
			get;
			set;
		}

		#endregion
	}
}