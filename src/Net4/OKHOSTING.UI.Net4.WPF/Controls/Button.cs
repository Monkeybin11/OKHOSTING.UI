using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
	public class Button : System.Windows.Controls.Button, IButton
	{
		public Button()
		{
		}
		
		public new event EventHandler Click;

		protected override void OnClick()
		{
			base.OnClick();
			
			if (Click != null)
			{
				Click(this, new EventArgs());
			}
		}

		public string Text
		{
			get
			{
				return (string)base.Content;
			}
			set
			{
				base.Content = value;
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

		public bool Bold
		{
			get
			{
				return base.FontWeight.ToOpenTypeWeight() == 2;
			}

			set
			{
				base.FontWeight = System.Windows.FontWeight.FromOpenTypeWeight(value ? 2 : 1);
			}
		}

		public bool Italic
		{
			get
			{
				return base.FontStyle.
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public bool Underline
		{
			get
			{
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public HorizontalAlignment TextHorizontalAlignment
		{
			get
			{
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		public VerticalAlignment TextVerticalAlignment
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

		Thickness IControl.Margin
		{
			get
			{
				base.Margin;
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		Thickness IControl.BorderWidth
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

		HorizontalAlignment IControl.HorizontalAlignment
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

		VerticalAlignment IControl.VerticalAlignment
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