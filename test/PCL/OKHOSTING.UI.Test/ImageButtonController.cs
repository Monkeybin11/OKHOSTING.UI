using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using System.IO;


namespace OKHOSTING.UI.Test
{
	public class ImageButtonController: Controller
	{
        IImage imgPicture;

        public override void Start()
        {
            base.Start();

            IStack stack = Platform.Current.Create<IStack>();

            ILabel lblLabel = Platform.Current.Create<ILabel>();
            lblLabel.Text = "View an image from Url";
            lblLabel.Height = 30;
            stack.Children.Add(lblLabel);

            IImageButton imgbtn = Platform.Current.Create<IImageButton>();
            imgbtn.LoadFromUrl(new Uri("http://okhosting.com/wp-content/uploads/2016/02/okhosting-150x150.png"));
            imgbtn.Height = 100;
            imgbtn.Width = 100;
            imgbtn.Click += CmdViewImage_Click;
            stack.Children.Add(imgbtn);

            imgPicture = Platform.Current.Create<IImage>();
            imgPicture.LoadFromUrl(new Uri("http://www.patycantu.com/wp-content/uploads/2014/07/91.jpg"));
            imgPicture.Height = 250;
            imgPicture.Width = 600;
            imgPicture.Visible = false;
            stack.Children.Add(imgPicture);

            IButton cmdClose = Platform.Current.Create<IButton>();
            cmdClose.Text = "Close";
            cmdClose.Click += CmdClose_Click;
            stack.Children.Add(cmdClose);

            Platform.Current.Page.Title = "Test label";
			Platform.Current.Page.Content = stack;
		}

        private void CmdViewImage_Click(object sender, EventArgs e)
        {
            imgPicture.Visible = true;
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}