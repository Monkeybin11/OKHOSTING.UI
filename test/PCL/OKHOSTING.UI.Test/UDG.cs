using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	public class UDG : Controller
	{
		protected IImage BackgroundImage;
		ITextArea txtArea;

		public override void Start()
		{
			base.Start();

			IRelativePanel panel = Platform.Current.Create<IRelativePanel>();

			BackgroundImage = Platform.Current.Create<IImage>();
			BackgroundImage.LoadFromUrl(new Uri("http://okhosting.com/resources/uploads/2015/09/diseno-de-paginas-responsivas.png"));
			BackgroundImage.Width = Platform.Current.Page.Width;
			BackgroundImage.Height = Platform.Current.Page.Height;
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			ILabel lblLabel = Platform.Current.Create<ILabel>();
			lblLabel.Text = "Radio Universidad De Guadalajara";
			lblLabel.Width = 230;
			lblLabel.Height = 30;
			lblLabel.FontColor = new Color(1, 0, 0, 255);
			lblLabel.BackgroundColor = new Color(1, 255, 0, 255);
			panel.Add(lblLabel, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.AboveOf);

			IGrid grid = Platform.Current.Create<IGrid>();
			grid.ColumnCount = 1;
			grid.RowCount = 20;
			panel.Add(grid, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.CenterWith);

			IImageButton cmdOpen = Platform.Current.Create<IImageButton>();
			cmdOpen.LoadFromUrl(new Uri("http://okhosting.com/resources/uploads/2015/09/diseno-de-paginas-responsivas.png"));
			cmdOpen.Height = 50;
			cmdOpen.Click += CmdViewImage_Click;
			grid.SetContent(0, 0, cmdOpen);
			//panel.Add(cmdOpen, RelativePanelHorizontalContraint.LeftOf, RelativePanelVerticalContraint.BottomWith);

			ILabel lblLabel2 = Platform.Current.Create<ILabel>();
			lblLabel2.Text = "NOTAS DE EL ACORDEON";
			lblLabel2.Width = 230;
			lblLabel2.Height = 50;
			lblLabel2.FontColor = new Color(1, 255, 0, 255);
			lblLabel2.BackgroundColor = new Color(1, 10, 0, 255);
			grid.SetContent(1, 0, lblLabel2);
			//panel.Add(lblLabel2, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.CenterWith);

			txtArea = Platform.Current.Create<ITextArea>();
			txtArea.Value = "Hoy estamos hablando de las palabras que usamos que provienen del árabe. Llama a cabina y dinos cules conoces. Entras a la rifa de boletos de Radaid";
			txtArea.BorderColor = new Color(1, 255, 255, 255);
			txtArea.Width = 230;
			txtArea.Height = 150;
			txtArea.Visible = false;
			grid.SetContent(3, 0, txtArea);
			//panel.Add(txtArea, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.CenterWith);

			ILabel lblLabel3 = Platform.Current.Create<ILabel>();
			lblLabel3.Text = "ENVIA UN MENSAJE A EL ACORDEÓN";
			lblLabel3.Width = 230;
			lblLabel3.Height = 50;
			lblLabel3.FontColor = new Color(1, 255, 0, 255);
			lblLabel3.BackgroundColor = new Color(1, 10, 0, 255);
			grid.SetContent(6, 0, lblLabel3);
			//panel.Add(lblLabel3, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.CenterWith);

			ITextArea txtAreaComentario = Platform.Current.Create<ITextArea>();
			txtAreaComentario.Value = "";
			txtAreaComentario.BackgroundColor = new Color(1, 255, 255, 255);
			txtAreaComentario.Width = 230;
			txtAreaComentario.Height = 50;
			grid.SetContent(8, 0, txtArea);
			//panel.Add(txtAreaComentario, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.CenterWith);

			IButton cmdClose = Platform.Current.Create<IButton>();
			cmdClose.Text = "Enviar";
			cmdClose.Height = 50;
			cmdClose.BackgroundColor = new Color(1, 255, 0, 255);
			cmdClose.Click += CmdClose_Click;
			panel.Add(cmdClose, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BottomWith);

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
		private void CmdViewImage_Click(object sender, EventArgs e)
		{
			txtArea.Visible = true;
		}
	}
}
