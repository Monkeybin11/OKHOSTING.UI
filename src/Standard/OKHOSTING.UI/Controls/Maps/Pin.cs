namespace OKHOSTING.UI.Controls.Maps
{
	/// <summary>
	/// A marker on a Map
	/// </summary>
	/// <remarks>
	/// A Xamarin.Forms.Maps.Pin must have its Xamarin.Forms.Maps.Pin.Label property assigned before it is added to a map. If not, a System.ArgumentException is thrown.
	/// </remarks>
	public class Pin
	{
		public object MarkerId { get; set; }
		
		//
		// Resumen:
		//     The kind of pin.
		//
		// Valor:
		//     To be added.
		//
		// Comentarios:
		//     To be added.
		public PinType Type { get; set; }
		
		//
		// Resumen:
		//     The latitude and longitude of the Xamarin.Forms.Maps.Pin.
		//
		// Valor:
		//     The Xamarin.Forms.Maps.Position of the Xamarin.Forms.Maps.Pin.
		//
		// Comentarios:
		//     To be added.
		public Position Position { get; set; }
		
		//
		// Resumen:
		//     A user-readable associated with the Xamarin.Forms.Maps.Pin.
		//
		// Valor:
		//     To be added.
		//
		// Comentarios:
		//     To be added.
		public string Label { get; set; }
		
		//
		// Resumen:
		//     A describing the street address.
		//
		// Valor:
		//     To be added.
		//
		// Comentarios:
		//     To be added.
		public string Address { get; set; }
	}
}
