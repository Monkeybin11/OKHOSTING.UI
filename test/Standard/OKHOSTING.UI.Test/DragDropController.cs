using System;
using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	public class DragDropController : Controller
	{
		protected ILabel lblMessage;
		protected ILabel lblDropHere;

		protected override void OnStart()
		{
			var image = BaitAndSwitch.Create<IImage>();
			image.LoadFromUrl(new Uri("https://avatars1.githubusercontent.com/u/161583"));
			image.Width = 100;
			image.Height = 100;

			lblDropHere = BaitAndSwitch.Create<ILabel>();
			lblDropHere.Text = "Drop it here bro!";
			lblDropHere.TextHorizontalAlignment = HorizontalAlignment.Center;
			lblDropHere.TextVerticalAlignment = VerticalAlignment.Center;
			lblDropHere.Width = 200;
			lblDropHere.Height = 200;
			lblDropHere.BorderColor = System.Drawing.Color.Green;
			lblDropHere.BackgroundColor = System.Drawing.Color.Aqua;

			lblMessage = BaitAndSwitch.Create<ILabel>();
			lblMessage.Text = "Drag the top leftr image and drop it in the bottom right one";

			var cmdBack = BaitAndSwitch.Create<IButton>();
			cmdBack.Text = "Back";
			cmdBack.Click += cmdBack_Click;

			var grid = BaitAndSwitch.Create<IGrid>();
			grid.RowCount = 4;
			grid.ColumnCount = 2;
			grid.Height = Page.Height;
			grid.Width = Page.Width;

			grid.SetContent(0, 0, image);
			grid.SetContent(1, 1, lblDropHere);
			grid.SetContent(2, 0, lblMessage);
			grid.SetContent(3, 0, cmdBack);

			grid.SetColumnSpan(2, lblMessage);
			grid.SetColumnSpan(2, cmdBack);

			var dragDrop = BaitAndSwitch.Create<IDragDrop>();
			dragDrop.AllowDrag(image);
			dragDrop.AllowDrop(lblDropHere);
			dragDrop.ControlDropped += DragDrop_ControlDropped;

			Page.Content = grid;
		}

		private void cmdBack_Click(object sender, EventArgs e)
		{
			Finish();
		}

		private void DragDrop_ControlDropped(object sender, IControl e)
		{
			lblMessage.Text = "Well done my brother!";
			lblDropHere.BackgroundColor = System.Drawing.Color.Red;
		}
	}
}