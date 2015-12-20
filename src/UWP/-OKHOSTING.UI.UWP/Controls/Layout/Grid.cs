using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using System;

namespace OKHOSTING.UI.UWP.Controls.Layout
{
	public class Grid : Windows.UI.Xaml.Controls.Grid, IGrid
	{
		public Grid()
		{
		}

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
					base.ColumnDefinitions.Add(new Windows.UI.Xaml.Controls.ColumnDefinition());
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
					base.RowDefinitions.Add(new Windows.UI.Xaml.Controls.RowDefinition());
				}

				while (base.RowDefinitions.Count > value)
				{
					base.RowDefinitions.RemoveAt(base.RowDefinitions.Count - 1);
				}
			}
		}

		IControl IGrid.GetContent(int row, int column)
		{
			foreach (Windows.UI.Xaml.FrameworkElement children in base.Children)
			{
				if (Windows.UI.Xaml.Controls.Grid.GetRow(children) == row && Windows.UI.Xaml.Controls.Grid.GetColumn(children) == column)
				{
					return (IControl) children;
				}
			}

			return null;
		}

		void IGrid.SetContent(int row, int column, IControl content)
		{
			Grid.SetRow((Windows.UI.Xaml.FrameworkElement) content, row);
			Grid.SetColumn((Windows.UI.Xaml.FrameworkElement) content, column);

			base.Children.Add((Windows.UI.Xaml.FrameworkElement) content);
		}


		Thickness IGrid.CellMargin
		{
			get
			{
				return new Thickness(0);
			}
			set
			{
				//do nothing
			}
		}

		Thickness IGrid.CellPadding
		{
			get
			{
				return App.Current.Parse(base.Padding);
			}
			set
			{
				base.Padding = App.Current.Parse(value);
			}
		}

		void IDisposable.Dispose()
		{
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
				return App.Current.Parse(base.Margin);
			}
			set
			{
				base.Margin = App.Current.Parse(value);
			}
		}

		Color IControl.BackgroundColor
		{
			get
			{
				return App.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush)base.Background).Color);
			}
			set
			{
				base.Background = new Windows.UI.Xaml.Media.SolidColorBrush(App.Current.Parse(value));
			}
		}

		Color IControl.BorderColor
		{
			get
			{
				return App.Current.Parse(((Windows.UI.Xaml.Media.SolidColorBrush)base.BorderBrush).Color);
			}
			set
			{
				base.BorderBrush = new Windows.UI.Xaml.Media.SolidColorBrush(App.Current.Parse(value));
			}
		}

		Thickness IControl.BorderWidth
		{
			get
			{
				return App.Current.Parse(base.BorderThickness);
			}
			set
			{
				base.BorderThickness = App.Current.Parse(value);
			}
		}

		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return App.Current.Parse(base.HorizontalAlignment);
			}
			set
			{
				base.HorizontalAlignment = App.Current.Parse(value);
			}
		}

		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return App.Current.Parse(base.VerticalAlignment);
			}
			set
			{
				base.VerticalAlignment = App.Current.Parse(value);
			}
		}

		#endregion
	}
}
