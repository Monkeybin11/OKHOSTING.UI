using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Test
{
	public class LabelController: Controller
	{
		public override void Start()
		{
			base.Start();

			IGrid grid = Platform.Current.Create<IGrid>();
			grid.ColumnCount = 1;
			grid.RowCount = 13;

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "This is a label";
			grid.SetContent(0, 0, lblLabel);

			ITextBox txtText = Platform.Current.Create<ITextBox>();
			txtText.Value = "Update label text here";
			txtText.ValueChanged += (object sender, string e) => lblLabel.Text = txtText.Value;
			grid.SetContent(1, 0, txtText);

			IListPicker lstFont = Platform.Current.Create<IListPicker>();
			lstFont.DataSource = new string[] { "Arial", "Verdana", "Times new roman", "Helvetica" };
			lstFont.ValueChanged += (object sender, string e) => lblLabel.FontFamily = lstFont.Value;
			grid.SetContent(2, 0, lstFont);

			Platform.Current.Page.Title = "Test label";
			Platform.Current.Page.Content = grid;
		}
	}
}