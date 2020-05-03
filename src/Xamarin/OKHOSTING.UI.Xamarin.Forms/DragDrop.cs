using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Xamarin.Forms
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
			var native = (global::Xamarin.Forms.View) control;

			var panGestureRecognizer = new global::Xamarin.Forms.PanGestureRecognizer
			{
				TouchPoints = 1
			};

			panGestureRecognizer.PanUpdated += PanGestureRecognizer_PanUpdated;
			native.GestureRecognizers.Clear();
			native.GestureRecognizers.Add(panGestureRecognizer);
		}

		/// <summary>
		/// Allows a control to receive controls that have been dragged into it
		/// </summary>
		public void AllowDrop(IControl control)
		{
		}

		private void PanGestureRecognizer_PanUpdated(object sender, global::Xamarin.Forms.PanUpdatedEventArgs e)
		{
			var native = (IControl) sender;
			var visualElement = (global::Xamarin.Forms.View) sender;
			var dropContainer = native.Parent;
			var android = global::Xamarin.Forms.Device.RuntimePlatform == global::Xamarin.Forms.Device.Android;

			// Update on Drop
			if (e.StatusType == global::Xamarin.Forms.GestureStatus.Completed)
			{
				// Coordinate of center = Initial position of top left corner + Pan transformation + Size / 2 
				//var screenCoordinates = visualElement.GetScreenCoordinates();

				switch (e.StatusType)
				{
					case global::Xamarin.Forms.GestureStatus.Running:
						visualElement.TranslationX = (android ? visualElement.TranslationX : 0) + e.TotalX;
						visualElement.TranslationY = (android ? visualElement.TranslationY : 0) + e.TotalY;
						//visualElement.ScreenX = screenCoordinates.X + (android ? visualElement.TranslationX : 0) + e.TotalX + visualElement.Width / 2;
						//visualElement.ScreenY = screenCoordinates.Y + (android ? visualElement.TranslationY : 0) + e.TotalY + visualElement.Height / 2;
						break;

					case global::Xamarin.Forms.GestureStatus.Completed:
						OnDrop(visualElement, (global::Xamarin.Forms.View) dropContainer);
						break;

					case global::Xamarin.Forms.GestureStatus.Canceled:
						visualElement.TranslationX = 0;
						visualElement.TranslationY = 0;
						//visualElement.ScreenX = screenCoordinates.X + visualElement.Width / 2;
						//visualElement.ScreenY = screenCoordinates.Y + visualElement.Height / 2;
						break;
				}
			}
		}

		private void OnDrop(global::Xamarin.Forms.View dragged, global::Xamarin.Forms.View dropped)
		{
			var allReceivers = App.GetAllChildren((IControl) dropped);

			foreach (var receiver in allReceivers)
			{
				if (!(receiver is global::Xamarin.Forms.VisualElement veReceiver))
					continue;

				var movingCoordinates = dragged.GetScreenCoordinates();
				var receiverCoordinates = veReceiver.GetScreenCoordinates();

				var width = veReceiver.Width;
				var height = veReceiver.Height;
				if (movingCoordinates.X >= receiverCoordinates.X &&
					movingCoordinates.X <= receiverCoordinates.X + width &&
					movingCoordinates.Y >= receiverCoordinates.Y &&
					movingCoordinates.Y <= receiverCoordinates.Y + height)
				{
					ControlDropped?.Invoke(dragged, (IControl) dropped);
				}
			}
		}
	}
}