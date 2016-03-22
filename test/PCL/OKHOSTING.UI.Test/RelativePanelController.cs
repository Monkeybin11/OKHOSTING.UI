using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	public class RelativePanelController : Controller
	{
		protected IImage BackgroundImage;

		public override void Start()
		{
			base.Start();

			IRelativePanel panel = Platform.Current.CreateControl<IRelativePanel>();

			//should be a background image
			BackgroundImage = Platform.Current.CreateControl<IImage>();
			BackgroundImage.LoadFromUrl(new Uri("http://okhosting.com/resources/uploads/2015/09/diseno-de-paginas-responsivas.png"));
			BackgroundImage.Width = Platform.Current.Page.Width;
			BackgroundImage.Height = Platform.Current.Page.Height;
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			ILabel lblLabel = Platform.Current.CreateControl<ILabel>();
			lblLabel.Text = "This label is centered";
			lblLabel.FontColor = new Color(255, 0, 0, 255);
			lblLabel.BackgroundColor = new Color(255, 255, 0, 0);
			panel.Add(lblLabel, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.CenterWith);

			ILabel lblLabel2 = Platform.Current.CreateControl<ILabel>();
			lblLabel2.Text = "This label is centered and below the first one";
			lblLabel.FontColor = new Color(255, 0, 0, 255);
			lblLabel2.BackgroundColor = new Color(255, 0, 255, 0);
			panel.Add(lblLabel2, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, lblLabel);

			IButton cmdClose = Platform.Current.CreateControl<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += CmdClose_Click;
			lblLabel.FontColor = new Color(255, 0, 0, 0);
			lblLabel2.BackgroundColor = new Color(255, 0, 255, 255);
			panel.Add(cmdClose, RelativePanelHorizontalContraint.RightOf, RelativePanelVerticalContraint.AboveOf, lblLabel);

			Platform.Current.Page.Title = "Test RelativePanel";
			Platform.Current.Page.Content = panel;
		}

		public override void Resize()
		{
			base.Resize();

			BackgroundImage.Width = Platform.Current.Page.Width;
			BackgroundImage.Height = Platform.Current.Page.Height;
		}

		private void CmdClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}
	}
}