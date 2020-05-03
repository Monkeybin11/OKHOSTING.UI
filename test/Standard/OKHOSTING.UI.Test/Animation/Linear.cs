using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Animation
{
	public class Linear : Controller 
	{
		protected override void OnStart()
		{
			IStack stack = Core.BaitAndSwitch.Create<IStack>();

			ILabelButton lblColor = Core.BaitAndSwitch.Create<ILabelButton>();
			lblColor.Width = 300;
			lblColor.Height = 300;
			lblColor.BackgroundColor = Color.FromArgb(255, 0, 0, 0);
			stack.Children.Add(lblColor);

			ILabelButton lblClose = Core.BaitAndSwitch.Create<ILabelButton>();
			lblClose.Text = "Close";
			lblClose.Click += lblClose_Click;
			stack.Children.Add(lblClose);

			var member = new Data.MemberExpression<IControl>(c => c.BackgroundColor);

			UI.Animation.Animation animation = new UI.Animation.Animation();
			animation.Iterations = 10;
			animation.Delay = TimeSpan.FromSeconds(1);
			animation.Duration = TimeSpan.FromSeconds(6);
			animation.KeyFrames = new List<UI.Animation.KeyFrame>()
			{
				new UI.Animation.KeyFrame(0, member, Color.FromArgb(255, 255, 0, 0)),
				new UI.Animation.KeyFrame(50, member, Color.FromArgb(255, 0, 255, 0)),
				new UI.Animation.KeyFrame(100, member, Color.FromArgb(255, 0, 0, 255)),
			};

			// Establishes the content and title of the page.
			Page.Title = "Animation simple test";
			Page.Content = stack;

			animation.Start(lblColor, Page);
		}

		private void lblClose_Click(object sender, EventArgs e)
		{
			Finish();
		}
	}
}