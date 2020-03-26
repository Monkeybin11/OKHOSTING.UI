using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Net4.WPF
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
			var native = (System.Windows.FrameworkElement) control;
			native.MouseDown += control_MouseDown;
		}

		/// <summary>
		/// Allows a control to receive controls that have been dragged into it
		/// </summary>
		public void AllowDrop(IControl control)
		{
			var native = (System.Windows.FrameworkElement) control;

			native.AllowDrop = true;
			native.DragEnter += control_DragEnter;
			native.Drop += control_DragDrop;
		}

		private void control_MouseDown(object sender, System.Windows.Input.MouseEventArgs e)
		{
			var native = (System.Windows.FrameworkElement) sender;
			System.Windows.DragDrop.DoDragDrop(native, native, System.Windows.DragDropEffects.Copy | System.Windows.DragDropEffects.Move);
		}

		private void control_DragEnter(object sender, System.Windows.DragEventArgs e)
		{
			e.Effects = System.Windows.DragDropEffects.Move;
		}

		private void control_DragDrop(object sender, System.Windows.DragEventArgs e)
		{
			ControlDropped?.Invoke(e.Data.GetData(typeof(IControl)), (IControl) sender);
		}
	}
}