using System;
using System.Drawing;
using OKHOSTING.UI.Animations;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Animations
{
	public class Linear : Controller 
	{
		protected override void OnStart()
		{
			IStack stack = Core.BaitAndSwitch.Create<IStack>();
			stack.Height = Page.Height;

			ILabelButton lblColor = Core.BaitAndSwitch.Create<ILabelButton>();
			lblColor.Width = 30;
			lblColor.Height = 30;
			lblColor.BackgroundColor = Color.FromArgb(255, 100, 0, 0);
			stack.Children.Add(lblColor);

			ILabelButton lblClose = Core.BaitAndSwitch.Create<ILabelButton>();
			lblClose.Text = "Close";
			lblClose.Width = 100;
			lblClose.Height = 30;
			lblClose.Click += lblClose_Click;
			stack.Children.Add(lblClose);

			// Establishes the content and title of the page.
			Page.Title = "Animation simple test";
			Page.Content = stack;

			Transition transition = new Transition(new UI.Animations.TimingFunction.ThrowAndCatch(2000));
			transition.Page = Page;
			transition.Add(lblColor, m=> m.Width, 700.0);
			transition.Add(lblColor, m=> m.Height, 200.0, 500.0);
			transition.Add(lblColor, m=> m.Margin, new Thickness(300));
			transition.Add(lblColor, m=> m.BackgroundColor, Color.LightCyan, Color.YellowGreen);
			transition.Run();
		}

		private void lblClose_Click(object sender, EventArgs e)
		{
			Finish();
		}
	}
}