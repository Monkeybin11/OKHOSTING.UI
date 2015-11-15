using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layouts
{
	public class Grid : global::Xamarin.Forms.Grid, IGrid
	{
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
					base.ColumnDefinitions.Add(new global::Xamarin.Forms.ColumnDefinition());
				}

				while (base.ColumnDefinitions.Count > value)
				{
					base.ColumnDefinitions.RemoveAt(base.ColumnDefinitions.Count - 1);
				}
			}
		}

		public string Name
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
					base.RowDefinitions.Add(new global::Xamarin.Forms.RowDefinition());
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
				return base.IsVisible;
			}
			set
			{
				base.IsVisible = value;
			}
		}

		public void Dispose()
		{
		}

		public IControl GetContent(int row, int column)
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

		public void SetContent(int row, int column, IControl content)
		{
			global::Xamarin.Forms.Grid.SetRow((global::Xamarin.Forms.View) content, row);
			global::Xamarin.Forms.Grid.SetColumn((global::Xamarin.Forms.View) content, column);

			base.Children.Add((global::Xamarin.Forms.View) content);
		}
	}
}