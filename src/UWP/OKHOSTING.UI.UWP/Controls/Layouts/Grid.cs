using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.UWP.Controls.Layouts
{
	public class Grid : Windows.UI.Xaml.Controls.Grid, UI.Controls.Layouts.IGrid
	{
		public Grid()
		{
		}

		public int ColumnCount
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

		public int RowCount
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

		public bool Visible
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

		public void Dispose()
		{
		}

		public IControl GetContent(int row, int column)
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

		public void SetContent(int row, int column, IControl content)
		{
			Grid.SetRow((Windows.UI.Xaml.FrameworkElement) content, row);
			Grid.SetColumn((Windows.UI.Xaml.FrameworkElement) content, column);

			base.Children.Add((Windows.UI.Xaml.FrameworkElement) content);
		}
	}
}
