using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Net4.WPF
{
	/// <summary>
	/// Enables drag and drop functionality
	/// </summary>
	public class DragDrop: IDragDrop
	{
		readonly Dictionary<string, IControl> Draggables = new Dictionary<string, IControl>();
		
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
			var data = native.GetHashCode().ToString();
			Draggables[data] = (IControl) native;

			System.Windows.DragDrop.DoDragDrop(native, data, System.Windows.DragDropEffects.Move);
		}

		private void control_DragEnter(object sender, System.Windows.DragEventArgs e)
		{
			e.Effects = System.Windows.DragDropEffects.Move;
		}

		private void control_DragDrop(object sender, System.Windows.DragEventArgs e)
		{
			var data = (string)e.Data.GetData(System.Windows.DataFormats.Text);
			IControl dragged = Draggables[data];

			ControlDropped?.Invoke(dragged, (IControl)sender);
		}
	}
}