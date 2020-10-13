using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

			var colorMember = new Data.MemberExpression<IControl>(c => c.BackgroundColor);
			var widthMember = new Data.MemberExpression<IControl>(c => c.Width);

			UI.Animation.Animation animation = new UI.Animation.Animation();
			animation.Iterations = 10;
			animation.Delay = TimeSpan.FromSeconds(1);
			animation.Duration = TimeSpan.FromSeconds(10);
			animation.KeyFrames = new List<UI.Animation.KeyFrame>();
			var colors = UI.Animation.Animation.GetGradients(Color.FromArgb(255, 255, 0, 0), Color.FromArgb(255, 0, 255, 0), 1000).ToArray();

			for (int i = 0; i < 1000; i++)
			{
				var frame = new UI.Animation.KeyFrame(i + 1);
				frame.Changes.Add(colorMember, colors[i]);
				frame.Changes.Add(widthMember, 300 + i);

				animation.KeyFrames.Add(frame);
			}

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