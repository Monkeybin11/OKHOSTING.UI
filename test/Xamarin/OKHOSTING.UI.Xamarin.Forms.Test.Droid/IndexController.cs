using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Xamarin.Forms.Test.Droid
{
	public class IndexController : Controller
	{
		protected IImage BackgroundImage;
		IImageButton play;
		IImageButton pause;
		IImageButton stop;

		public override void Start()
		{
			base.Start();

			IRelativePanel panel = Platform.Current.CreateControl<IRelativePanel>();

			BackgroundImage = Platform.Current.CreateControl<IImage>();
			BackgroundImage.LoadFromUrl(new Uri("http://app-udg.okhosting.com/ICONOS-PROG/icon2--47.png"));
			BackgroundImage.Width = Platform.Current.Page.Width;
			BackgroundImage.Height = Platform.Current.Page.Height;
			panel.Add(BackgroundImage, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);
			
			ILabelButton cmdProgramas = Platform.Current.CreateControl<ILabelButton>();
			cmdProgramas.Text = "Programas";
			cmdProgramas.FontSize = 13;
			cmdProgramas.Width = 80;
			cmdProgramas.Height = 35;
			cmdProgramas.Click += (object sender, EventArgs e) => new Programas().Start();
			panel.Add(cmdProgramas, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.TopWith);

			ILabelButton Regionales = Platform.Current.CreateControl<ILabelButton>();
			Regionales.Text = "Regionales";
			Regionales.FontSize = 13;
			Regionales.Width = 80;
			Regionales.Height = 35;
			panel.Add(Regionales, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.TopWith);

			ILabelButton Virtuales = Platform.Current.CreateControl<ILabelButton>();
			Virtuales.Text = "Virtual";
			Virtuales.FontSize = 13;
			Virtuales.Width = 80;
			Virtuales.Height = 35;
			panel.Add(Virtuales, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.TopWith);

			ILabel lblLabel = Platform.Current.CreateControl<ILabel>();
			lblLabel.Text = "Radio Universidad De Guadalajara";
			lblLabel.Width = 240;
			lblLabel.Height = 20;
			lblLabel.FontColor = new Color(1, 0, 0, 255);
			lblLabel.BackgroundColor = new Color(1, 255, 0, 255);
			panel.Add(lblLabel, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, cmdProgramas);

			ILabel lblLabels = Platform.Current.CreateControl<ILabel>();
			lblLabels.Text = "";
			lblLabels.Height = 20;
			lblLabels.Width = 20;
			panel.Add(lblLabels, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel);

			ILabel lblLabel2 = Platform.Current.CreateControl<ILabel>();
			lblLabel2.Text = "AHORA AL AIRE";
			lblLabel2.FontColor = new Color(1, 255, 0, 255);
			panel.Add(lblLabel2, RelativePanelHorizontalContraint.CenterWith, RelativePanelVerticalContraint.BelowOf, lblLabels);

			play = Platform.Current.CreateControl<IImageButton>();
			play.LoadFromUrl(new Uri("http://app-udg.okhosting.com/ICONOS-PROG/icon-28.png"));
			play.Click += Play_Click;
			play.Width = 80;
			play.Height = 35;
			panel.Add(play, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel2);

			pause = Platform.Current.CreateControl<IImageButton>();
			pause.LoadFromUrl(new Uri("http://app-udg.okhosting.com/ICONOS-PROG/icon-04.png"));
			pause.Click += Pause_Click;
			pause.Width = 80;
			pause.Height = 35;
			panel.Add(pause, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, play);

			stop = Platform.Current.CreateControl<IImageButton>();
			stop.LoadFromUrl(new Uri("http://app-udg.okhosting.com/ICONOS-PROG/icon-15.png"));
			stop.Click += Stop_Click;
			stop.Width = 80;
			stop.Height = 35;
			panel.Add(stop, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, pause);

			ILabel lblLabel3 = Platform.Current.CreateControl<ILabel>();
			lblLabel3.Text = "NOTAS DE EL ACORDEON";
			lblLabel3.FontColor = new Color(1, 255, 0, 255);
			panel.Add(lblLabel3, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, stop);

			ILabel lblTexto = Platform.Current.CreateControl<ILabel>();
			lblTexto.Text = "Hoy estamos hablando de las palabras que usamos que provienen del árabe. Llama a cabina y dinos cules conoces. Entras a la rifa de boletos de Radaid";
			lblTexto.BorderColor = new Color(1, 255, 255, 255);
			lblTexto.BorderWidth = new Thickness(9, 9, 9, 9);
			panel.Add(lblTexto, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel3);

			ILabel lblLabel4 = Platform.Current.CreateControl<ILabel>();
			lblLabel4.Text = "ENVIA UN MENSAJE A EL ACORDEON";
			lblLabel4.FontSize = 11;
			lblLabel4.FontColor = new Color(1, 255, 0, 255);
			panel.Add(lblLabel4, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblTexto);

			ITextArea txtAreaComentario = Platform.Current.CreateControl<ITextArea>();
			txtAreaComentario.Value = "";
			txtAreaComentario.FontSize = 12;
			txtAreaComentario.FontColor = new Color(1, 0, 0, 255);
			txtAreaComentario.BackgroundColor = new Color(1, 255, 255, 255);
			txtAreaComentario.Width = 210;
			txtAreaComentario.Height = 80;
			panel.Add(txtAreaComentario, RelativePanelHorizontalContraint.LeftWith, RelativePanelVerticalContraint.BelowOf, lblLabel4);

			IButton Enviar = Platform.Current.CreateControl<IButton>();
			Enviar.Text = "Enviar";
			Enviar.Width = 80;
			Enviar.Height = 30;
			Enviar.FontSize = 12;
			Enviar.BackgroundColor = new Color(1, 255, 0, 255);
			panel.Add(Enviar, RelativePanelHorizontalContraint.RightWith, RelativePanelVerticalContraint.BelowOf, txtAreaComentario);

			Platform.Current.Page.Title = "straming";
			Platform.Current.Page.Content = panel;
		}

		public override void Resize()
		{
			base.Resize();

			BackgroundImage.Width = Platform.Current.Page.Width;
			BackgroundImage.Height = Platform.Current.Page.Height;
		}

		private void Stop_Click(object sender, EventArgs e)
		{
			Intent intent = new Intent(StreamingBackgroundService.ActionStop);
			global::Xamarin.Forms.Forms.Context.StartService(intent);
		}

		private void Pause_Click(object sender, EventArgs e)
		{
			Intent intent = new Intent(StreamingBackgroundService.ActionPause);
			global::Xamarin.Forms.Forms.Context.StartService(intent);
		}

		private void Play_Click(object sender, EventArgs e)
		{
			Intent intent = new Intent(StreamingBackgroundService.ActionPlay);
			System.Threading.Tasks.Task.Factory.StartNew(
					() =>
					{
						global::Xamarin.Forms.Forms.Context.StartService(intent);
					});
		}
	}
}