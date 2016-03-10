using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
    public class UDG : Controller
    {
        public override void Start()
        {
            base.Start();

            IStack Stack = Platform.Current.Create<IStack>();

            ILabel lblLabel = Platform.Current.Create<ILabel>();
            lblLabel.Text = "Radio Universidad De Guadalajara";
            lblLabel.Height = 50;
            lblLabel.FontSize = 15;
            lblLabel.FontColor = new Color(1, 24, 4, 87);
            lblLabel.BackgroundColor = new Color(1, 255, 0, 255);
            lblLabel.VerticalAlignment = VerticalAlignment.Center;
            Stack.Children.Add(lblLabel);

            IImageButton imgbtn = Platform.Current.Create<IImageButton>();
            //imgbtn.LoadFromUrl(new Uri("/Bibliotecas/Imágenes/images.png"));
            imgbtn.LoadFromFile("/Bibliotecas/Imágenes/images.png");
            imgbtn.Height = 100;
            imgbtn.Width = 100;
            //imgbtn.Click += CmdViewImage_Click;
            Stack.Children.Add(imgbtn);

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
