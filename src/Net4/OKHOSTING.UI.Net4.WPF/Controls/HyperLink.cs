using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class HyperLink : System.Windows.Documents.Hyperlink, IHyperLink
	{
		public string Text
		{
			get;
			set;
		}

		public Uri Uri
		{
			get
			{
				return base.NavigateUri;
			}
			set
			{
				base.NavigateUri = value;
			}
		}

		public Color BackgroundColor
		{
			get
			{
				return Page.Parse(((System.Windows.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new System.Windows.Media.SolidColorBrush(Page.Parse(value));
			}
		}

		public Color BorderColor
		{
			get
			{
				return Page.Parse(((System.Windows.Media.SolidColorBrush)base.BorderBrush).Color);
			}
			set
			{
				base.BorderBrush = new System.Windows.Media.SolidColorBrush(Page.Parse(value));
			}
		}

		public double BorderWidth
		{
			get
			{
				return base.BorderThickness.Bottom;
			}
			set
			{
				base.BorderThickness = new System.Windows.Thickness(value);
			}
		}

		public bool Enabled
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

		public Color FontColor
		{
			get
			{
				return Page.Parse(((System.Windows.Media.SolidColorBrush)base.Foreground).Color);
			}
			set
			{
				base.Foreground = new System.Windows.Media.SolidColorBrush(Page.Parse(value));
			}
		}

		string ITextControl.FontFamily
		{
			get
			{
				return base.FontFamily.Source;
			}
			set
			{
				base.FontFamily = new System.Windows.Media.FontFamily(value);
			}
		}

		public bool Visible
		{
			get
			{
				return base.Visibility == System.Windows.Visibility.Visible;
			}
			set
			{
				if (value)
				{
					base.Visibility = System.Windows.Visibility.Visible;
				}
				else
				{
					base.Visibility = System.Windows.Visibility.Hidden;
				}
			}
		}

		public double Width
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public double Height
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public void Dispose()
		{
		}
	}
}