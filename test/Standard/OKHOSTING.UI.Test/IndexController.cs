using System;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
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

			// Controls
			ILabelButton lblControls = Core.BaitAndSwitch.Create<ILabelButton>();
			lblControls.Text = "Controls";
			lblControls.Click += (object sender, EventArgs e) => new Controls.IndexController() { Page = Page }.Start();
			stack.Children.Add(lblControls);
			
			// Css
			ILabelButton lblCss = Core.BaitAndSwitch.Create<ILabelButton>();
			lblCss.Text = "CSS";
			lblCss.Click += (object sender, EventArgs e) => new Css.IndexController() { Page = Page }.Start();
			stack.Children.Add(lblCss);

			// Misc
			ILabelButton lblMisc = Core.BaitAndSwitch.Create<ILabelButton>();
			lblMisc.Text = "Miscelaneous";
			lblMisc.Click += (object sender, EventArgs e) => new Misc.IndexController() { Page = Page }.Start();
			stack.Children.Add(lblMisc);

			// Establishes the content and title of the page.
			Page.Title = "Choose one control/feature to test";
            Page.Content = stack;
        }
    }
}