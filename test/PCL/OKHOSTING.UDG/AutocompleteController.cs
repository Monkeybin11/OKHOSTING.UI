using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;

namespace OKHOSTING.UI.Test
{
	public class AutocompleteController: Controller
	{
		public override void Start()
		{
			base.Start();

			IStack Stack = Platform.Current.Create<IStack>();

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Tis is my team";
			lblLabel.Height = 50;
			lblLabel.FontSize = 20;
			Stack.Children.Add(lblLabel);

			IAutocomplete txtBox = Platform.Current.Create<IAutocomplete>();
			txtBox.Name = "Team";
			//txtBox.BackgroundColor = new Color(1, 222, 184, 135);
			txtBox.FontColor = new Color(1, 36, 24, 130);
			txtBox.BorderColor = new Color(1, 229, 238, 0);
			txtBox.Width = 100;
			txtBox.Height = 80;
			txtBox.FontFamily = "Times new roman";
			txtBox.FontSize = 20;
			Stack.Children.Add(txtBox);

			IButton cmdClose = Platform.Current.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			Stack.Children.Add(cmdClose);

			Platform.Current.Page.Title = "Test Autocomplete";
			Platform.Current.Page.Content = Stack;
		}

		private void CmdClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}
	}
}