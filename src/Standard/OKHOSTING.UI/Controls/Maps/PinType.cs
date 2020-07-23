using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Controls.Maps
{
	//
	// Resumen:
	//     Enumeration specifying the various kinds of Xamarin.Forms.Maps.Pin.
	//
	// Comentarios:
	//     To be added.
	public enum PinType
	{
		//
		// Resumen:
		//     A generic pin.
		Generic = 0,
		//
		// Resumen:
		//     Pin for a place.
		Place = 1,
		//
		// Resumen:
		//     Pin for a saved location.
		SavedPin = 2,
		//
		// Resumen:
		//     Pin for a search result.
		SearchResult = 3
	}
}
