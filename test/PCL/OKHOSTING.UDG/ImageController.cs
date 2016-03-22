using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using System.IO;


namespace OKHOSTING.UI.Test
{
	public class ImageController: Controller
	{
		public override void Start()
		{
			base.Start();

			IStack stack = Platform.Current.Create<IStack>();

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "View an image from Url";
			lblLabel.Height = 30;
			stack.Children.Add(lblLabel);

			IImage imgPicture = Platform.Current.Create<IImage>();
			imgPicture.LoadFromUrl(new Uri("http://www.patycantu.com/wp-content/uploads/2014/07/91.jpg"));
			imgPicture.Height = 250;
			imgPicture.Width = 600;
			stack.Children.Add(imgPicture);

			IButton cmdClose = Platform.Current.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			stack.Children.Add(cmdClose);

			Platform.Current.Page.Title = "Test label";
			Platform.Current.Page.Content = stack;
		}

		private void CmdClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}
	}
}