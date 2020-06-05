using System;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using OKHOSTING.UI.Test.Css.Grids;

namespace OKHOSTING.UI.Test.Css
{
	/// <summary>
	/// It represents the main platform where controls are housed.
	/// <para xml:lang="es">
	/// Representa la plataforma principal donde se alojan controles.
	/// </para>
	/// </summary>
	public class IndexController: Controller 
	{
		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">.
		/// Inicia la instancia de este objeto.
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			IStack stack = Core.BaitAndSwitch.Create<IStack>();

			//CSSController
			ILabelButton cssController = Core.BaitAndSwitch.Create<ILabelButton>();
			cssController.Text = "CSS";
			cssController.Click += (object sender, EventArgs e) => new CssController() { Page = Page }.Start();
			stack.Children.Add(cssController);

			ILabelButton URLCssGrid = Core.BaitAndSwitch.Create<ILabelButton>();
			URLCssGrid.Text = "Css Grid";
			URLCssGrid.Click += (object sender, EventArgs e) => new CssGrid() { Page = Page }.Start();
			stack.Children.Add(URLCssGrid);

			ILabelButton ManyControladores = Core.BaitAndSwitch.Create<ILabelButton>();
			ManyControladores.Text = "CSS Grid 2";
			ManyControladores.Click += (object sender, EventArgs e) => new CssGrid2 () { Page = Page }.Start();
			stack.Children.Add(ManyControladores);

			ILabelButton ArrobaMedia = Core.BaitAndSwitch.Create<ILabelButton>();
			ArrobaMedia.Text = "CSS with @media";
			ArrobaMedia.Click += (object sender, EventArgs e) => new CssMediaController() { Page = Page }.Start();
			stack.Children.Add(ArrobaMedia);

			ILabelButton backgroundImage = Core.BaitAndSwitch.Create<ILabelButton>();
			backgroundImage.Text = "Background image";
			backgroundImage.Click += (object sender, EventArgs e) => new BackgroundImageController(Page).Start();
			stack.Children.Add(backgroundImage);

			// Establishes the content and title of the page.
			Page.Title = "Choose one control/feature to test";
			Page.Content = stack;
		}
	}
}