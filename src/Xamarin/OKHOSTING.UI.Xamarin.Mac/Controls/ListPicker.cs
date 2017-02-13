using System;
using System.Linq;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Mac.Controls
{
	public class ListPicker : global::Xamarin.Mac.Picker, IListPicker
	{
		public ListPicker()
		{
			base.SelectedIndexChanged += ListPicker_SelectedIndexChanged;
		}

		private void ListPicker_SelectedIndexChanged(object sender, EventArgs e)
		{
			SelectedItemChanged?.Invoke(sender, e);
		}

		IEnumerable<string> IListPicker.DataSource
		{
			get
			{
				return base.Items;
			}
			set
			{
				base.Items.Clear();
				
				foreach(string item in value)
				{
					base.Items.Add(item);
				}
			}
		}

		string IListPicker.SelectedItem
		{
			get
			{
				return ((IListPicker) this).DataSource.ToArray()[base.SelectedIndex];
			}
			set
			{
				int index = ((IListPicker) this).DataSource.ToList().IndexOf(value);
				base.SelectedIndex = index;
			}
		}

		public event EventHandler SelectedItemChanged;

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
			get;
			set;
		}

		Color ITextControl.FontColor
		{
			get;
			set;
		}

		bool ITextControl.Bold
		{
			get;
			set;
		}

		bool ITextControl.Italic
		{
			get;
			set;
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

		double ITextControl.FontSize
		{
			get;
			set;
		}


		#endregion
	}
}