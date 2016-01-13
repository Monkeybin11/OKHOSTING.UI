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

			IStack grid = Platform.Current.Create<IStack>();

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "This is a label";
			lblLabel.Height = 30;
			grid.Children.Add(lblLabel);

			ITextBox txtText = Platform.Current.Create<ITextBox>();
			txtText.Value = "Update label text here";
			txtText.ValueChanged += (object sender, string e) => lblLabel.Text = txtText.Value;
			grid.Children.Add(txtText);

			IListPicker lstFont = Platform.Current.Create<IListPicker>();
			lstFont.DataSource = new string[] { "Arial", "Verdana", "Times new roman", "Helvetica" };
			lstFont.ValueChanged += (object sender, string e) => lblLabel.FontFamily = lstFont.Value;
			grid.Children.Add(lstFont);

			Platform.Current.Page.Title = "Test label";
			Platform.Current.Page.Content = grid;
		}
	}
}