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
		public IndexController(IPage page) : base(page)
		{
		}

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">.
		/// Inicia la instancia de este objeto.
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			IImage imgPicture = Core.BaitAndSwitch.Create<IImage>();
			imgPicture.LoadFromUrl(new Uri("https://cdn.britannica.com/69/42169-050-33D1516C/dance-Aztec-Codex-Borbonicus-detail-Xolotl-Quetzalcoatl.jpg"));

			IStack stack = Core.BaitAndSwitch.Create<IStack>();
			stack.BackgroundImage = imgPicture;

			// Controls
			ILabelButton lblControls = Core.BaitAndSwitch.Create<ILabelButton>();
			lblControls.Text = "Controls";
			lblControls.BackgroundColor = System.Drawing.Color.FromArgb(50, 255, 0, 0);
			lblControls.Click += (object sender, EventArgs e) => new Controls.IndexController() { Page = Page }.Start();
			stack.Children.Add(lblControls);
			
			// Css
			ILabelButton lblCss = Core.BaitAndSwitch.Create<ILabelButton>();
			lblCss.Text = "CSS";
			lblCss.BackgroundColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
			lblCss.Click += (object sender, EventArgs e) => new Css.IndexController() { Page = Page }.Start();
			stack.Children.Add(lblCss);

			// Misc
			ILabelButton lblMisc = Core.BaitAndSwitch.Create<ILabelButton>();
			lblMisc.Text = "Miscelaneous";
			lblMisc.BackgroundColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
			lblMisc.Click += (object sender, EventArgs e) => new Misc.IndexController() { Page = Page }.Start();
			stack.Children.Add(lblMisc);

			// animation
			ILabelButton lblAnimation = Core.BaitAndSwitch.Create<ILabelButton>();
			lblAnimation.Text = "Animation";
			lblAnimation.BackgroundColor = System.Drawing.Color.FromArgb(0, 0, 0, 0);
			lblAnimation.Click += (object sender, EventArgs e) => new Animations.IndexController() { Page = Page }.Start();
			stack.Children.Add(lblAnimation);

			// Establishes the content and title of the page.
			Page.Title = "Choose one control/feature to test";
			Page.Content = stack;
		}
	}
}