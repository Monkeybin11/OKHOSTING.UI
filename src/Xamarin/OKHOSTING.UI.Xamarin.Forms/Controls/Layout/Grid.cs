using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using System.Collections.Generic;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layout
{
	public class Grid : global::Xamarin.Forms.Grid, IGrid
	{
        #region IGrid

        int IGrid.ColumnCount
		{
			get
			{
				return base.ColumnDefinitions.Count;
			}
			set
			{
				while (base.ColumnDefinitions.Count < value)
				{
					base.ColumnDefinitions.Add(new global::Xamarin.Forms.ColumnDefinition());
				}

				while (base.ColumnDefinitions.Count > value)
				{
					base.ColumnDefinitions.RemoveAt(base.ColumnDefinitions.Count - 1);
				}
			}
		}

		int IGrid.RowCount
		{
			get
			{
				return base.RowDefinitions.Count;
			}
			set
			{
				while (base.RowDefinitions.Count < value)
				{
					base.RowDefinitions.Add(new global::Xamarin.Forms.RowDefinition());
				}

				while (base.RowDefinitions.Count > value)
				{
					base.RowDefinitions.RemoveAt(base.RowDefinitions.Count - 1);
				}
			}
		}

		IControl IGrid.GetContent(int row, int column)
		{
			foreach (global::Xamarin.Forms.View children in base.Children)
			{
				if (global::Xamarin.Forms.Grid.GetRow(children) == row && global::Xamarin.Forms.Grid.GetColumn(children) == column)
				{
					return (IControl) children;
				}
			}

			return null;
		}

		void IGrid.SetContent(int row, int column, IControl content)
		{
			global::Xamarin.Forms.Grid.SetRow((global::Xamarin.Forms.View) content, row);
			global::Xamarin.Forms.Grid.SetColumn((global::Xamarin.Forms.View) content, column);

			base.Children.Add((global::Xamarin.Forms.View) content);
		}
        
		Thickness IGrid.CellMargin
		{
			get; set;
		}

		Thickness IGrid.CellPadding
		{
			get
			{
				return Platform.Current.Parse(base.Padding);
			}
			set
			{
				base.Padding = Platform.Current.Parse(value);
			}
		}

		void IGrid.SetColumnSpan(int columnSpan, IControl content)
		{
			SetColumnSpan((global::Xamarin.Forms.BindableObject) content, columnSpan);
		}

		int IGrid.GetColumnSpan(IControl content)
		{
			return GetColumnSpan((global::Xamarin.Forms.BindableObject) content);
		}

		void IGrid.SetRowSpan(int rowSpan, IControl content)
		{
			SetColumnSpan((global::Xamarin.Forms.BindableObject) content, rowSpan);
		}

		int IGrid.GetRowSpan(IControl content)
		{
			return GetRowSpan((global::Xamarin.Forms.BindableObject) content);
		}

		void IGrid.SetWidth(int column, double width)
		{
			base.ColumnDefinitions[column].Width = new global::Xamarin.Forms.GridLength(width, global::Xamarin.Forms.GridUnitType.Star);
		}

		double IGrid.GetWidth(int column)
		{
			return base.ColumnDefinitions[column].Width.Value;
		}

		void IGrid.SetHeight(int row, double height)
		{
			base.RowDefinitions[row].Height = new global::Xamarin.Forms.GridLength(height, global::Xamarin.Forms.GridUnitType.Star);
		}

		double IGrid.GetHeight(int row)
		{
			return base.RowDefinitions[row].Height.Value;
		}

        #endregion

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

        void IDisposable.Dispose()
        {
        }
    }
}