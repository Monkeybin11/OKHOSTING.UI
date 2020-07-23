namespace OKHOSTING.UI.Controls.Maps
{
	//
	// Resumen:
	//     A circular region on a Xamarin.Forms.Maps.Map.
	//
	// Comentarios:
	//     To be added.
	public sealed class MapSpan
	{
		public MapSpan(Position center, double latitudeDegrees, double longitudeDegrees)
		{
			Center = center;
			LatitudeDegrees = latitudeDegrees;
			LongitudeDegrees = longitudeDegrees;
		}

		//
		// Resumen:
		//     The Xamarin.Forms.Maps.Position in the geographical center of the Xamarin.Forms.Maps.MapSpan.
		//
		// Valor:
		//     To be added.
		//
		// Comentarios:
		//     To be added.
		public Position Center { get; private set; }
		
		//
		// Resumen:
		//     The degrees of latitude that are spanned by the Xamarin.Forms.Maps.MapSpan.
		//
		// Valor:
		//     The number of degrees of latitude that are spanned by the Xamarin.Forms.Maps.MapSpan.
		//
		// Comentarios:
		//     To be added.
		public double LatitudeDegrees { get; private set; }
		//
		// Resumen:
		//     The degrees of longitude that are spanned by the Xamarin.Forms.Maps.MapSpan.
		//
		// Valor:
		//     The number of degrees of longitude that are spanned by the Xamarin.Forms.Maps.MapSpan.
		//
		// Comentarios:
		//     To be added.
		public double LongitudeDegrees { get; private set; }
	}
}
