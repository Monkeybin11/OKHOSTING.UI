using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Net4.WebForms
{
	public class DragDrop : IDragDrop
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
			var native = (System.Web.UI.WebControls.WebControl)control;
			native.Attributes.Add("draggable", "true");
			native.Attributes.Add("ondragstart", "OnDragStart(event)");
		}

		/// <summary>
		/// Allows a control to receive controls that have been dragged into it
		/// </summary>
		public void AllowDrop(IControl control)
		{
			var native = (System.Web.UI.WebControls.WebControl)control;
			native.Attributes.Add("ondragover", "OnDragOver(event)");
			native.Attributes.Add("ondrop", "OnDrop(event)");

			CurrentDragDrops[control] = this;
		}

		protected void OnDropped(IControl dragged, IControl dropped)
		{
			ControlDropped?.Invoke(dragged, dropped);
		}

		protected static Dictionary<IControl, DragDrop> CurrentDragDrops
		{
			get
			{
				if (System.Web.HttpContext.Current?.Session == null)
				{
					throw new Exception("No ASP.NET Session exist yet to initialize CurrentDragDrops");
				}

				if (System.Web.HttpContext.Current.Session[nameof(CurrentDragDrops)] == null)
				{
					System.Web.HttpContext.Current.Session[nameof(CurrentDragDrops)] = new Dictionary<IControl, DragDrop>();
				}

				return (Dictionary<IControl, DragDrop>) System.Web.HttpContext.Current.Session[nameof(CurrentDragDrops)];
			}
		}

		internal static void RaiseDropped(IControl dragged, IControl dropped)
		{
			var dragDrop = CurrentDragDrops[dropped];
			dragDrop.OnDropped(dragged, dropped);
		}
	}
}