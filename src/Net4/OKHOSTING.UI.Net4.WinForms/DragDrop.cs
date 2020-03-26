using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Net4.WinForms
{
	/// <summary>
	/// Enables drag and drop functionality
	/// </summary>
	public class DragDrop: IDragDrop
	{
		/// <summary>
		/// Raised when a control has been dragged and dropped
		/// </summary>
		public event EventHandler<IControl> ControlDropped;

		/// <summary>
		/// Allows a control to be dragged
		/// </summary>
		public void AllowDrag(IControl control)
		{
			var native = (System.Windows.Forms.Control) control;
			native.MouseDown += control_MouseDown;
		}

		/// <summary>
		/// Allows a control to receive controls that have been dragged into it
		/// </summary>
		public void AllowDrop(IControl control)
		{
			var native = (System.Windows.Forms.Control) control;
			native.AllowDrop = true;
			native.DragEnter += control_DragEnter;
			native.DragDrop += control_DragDrop;
		}

		private void control_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			var native = (System.Windows.Forms.Control) sender;
			native.DoDragDrop(native, System.Windows.Forms.DragDropEffects.Copy | System.Windows.Forms.DragDropEffects.Move);
		}

		private void control_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = System.Windows.Forms.DragDropEffects.Move;
		}

		private void control_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			ControlDropped?.Invoke(sender, (IControl) e.Data.GetData(typeof(IControl)));
		}
	}
}