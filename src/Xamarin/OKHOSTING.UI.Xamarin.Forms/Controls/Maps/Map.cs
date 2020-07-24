using OKHOSTING.UI.Controls.Maps;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Maps
{
	public class Map : global::Xamarin.Forms.Maps.Map, IMap
	{
		protected new readonly PinCollection Pins;

		public Map()
		{
			Pins = new PinCollection(this);
		}

		public Map(MapSpan region) : base(Parse(region))
		{
			Pins = new PinCollection(this);
		}

		#region IControl

		/// <summary>
		/// Gets or sets the name of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece el nombre del control.
		/// </para>
		/// </summary>
		string IControl.Name
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets wether the control is visible or not.
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es visible o no.
		/// </para>
		/// </summary>
		bool IControl.Visible
		{
			get
			{
				return base.IsVisible;
			}
			set
			{
				base.IsVisible = value;
			}
		}

		/// <summary>
		/// Gets or sets wether the control is enabled or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es habilitado o no.
		/// </para>
		/// </summary>
		bool IControl.Enabled
		{
			get
			{
				return base.IsEnabled;
			}
			set
			{
				base.IsEnabled = value;
			}
		}

		/// <summary>
		/// Gets or sets the width of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece el ancho del control.
		/// </para>
		/// </summary>
		double? IControl.Width
		{
			get
			{
				return base.WidthRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.WidthRequest = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the height of the control.
		/// <para xml:lang="es">
		/// Obtiene o establece la altura del control.
		/// </para>
		/// </summary>
		double? IControl.Height
		{
			get
			{
				return base.HeightRequest;
			}
			set
			{
				if (value.HasValue)
				{
					base.HeightRequest = value.Value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the control margin.
		/// <para xml:lang="es">
		/// Obtiene o establece el margen del control.
		/// </para>
		/// </summary>
		Thickness IControl.Margin
		{
			get
			{
				return Forms.Platform.Parse(base.Margin);
			}
			set
			{
				base.Margin = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Space that this control will set between its content and its border
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre su contenido y su borde
		/// </para>
		/// </summary>
		Thickness IControl.Padding
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the color of the Control background.
		/// <para xml:lang="es">
		/// Obtiene o establece el color de fondo del control.
		/// </para>
		/// </summary>
		Color IControl.BackgroundColor
		{
			get
			{
				return Forms.Platform.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = Forms.Platform.Parse(value);
			}
		}

		/// <summary>
		/// Gets or sets the color of the control border.
		/// <para xml:lang="es">
		/// Obtiene o establece el color del borde del control.
		/// </para>
		/// </summary>
		Color IControl.BorderColor
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the width of the control border.
		/// <para xml:lang="es">
		/// Obtiene o establece el ancho del borde del control.
		/// </para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets the control horizontal alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineación horizontal del control.
		/// </para>
		/// </summary>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Forms.Platform.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(Forms.Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets the control vertical alignment.
		/// <para xml:lang="es">
		/// Obtiene o establece la alineación vertical del control.
		/// </para>
		/// </summary>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Forms.Platform.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(Forms.Platform.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un valor de objeto arbitrario que puede ser usado para almacenar informacion personalizada de este elemento.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">
		/// Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.
		/// </para>
		/// </remarks>
		object IControl.Tag
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		string IControl.CssClass { get; set; }

		/// <summary>
		/// Control that contains this control, like a grid, or stack
		/// </summary>
		IControl IControl.Parent
		{
			get
			{
				return (IControl)base.Parent;
			}
		}

		#endregion

		object ICloneable.Clone()
		{
			return MemberwiseClone();
		}

		void IDisposable.Dispose()
		{
		}

		ICollection<Pin> IMap.Pins
		{
			get
			{
				return Pins;
			}
		}

		public new MapSpan VisibleRegion
		{
			get
			{
				return Parse(base.VisibleRegion);
			}
			set
			{
				base.MoveToRegion(Parse(value));
			}
		}

		#region Parsing

		public static global::Xamarin.Forms.Maps.Pin Parse(Pin item)
		{
			return new global::Xamarin.Forms.Maps.Pin()
			{
				Position = Parse(item.Position),
				Address = item.Address,
				Type = Parse(item.Type),
				Label = item.Label,
			};
		}

		public static Pin Parse(global::Xamarin.Forms.Maps.Pin item)
		{
			return new Pin()
			{
				Position = Parse(item.Position),
				Address = item.Address,
				Type = Parse(item.Type),
				Label = item.Label,
			};
		}

		public static global::Xamarin.Forms.Maps.Position Parse(Position position)
		{
			return new global::Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude);
		}

		public static Position Parse(global::Xamarin.Forms.Maps.Position position)
		{
			return new Position(position.Latitude, position.Longitude);
		}

		public static global::Xamarin.Forms.Maps.PinType Parse(PinType pinType)
		{
			switch (pinType)
			{
				case PinType.Generic:
					return global::Xamarin.Forms.Maps.PinType.Generic;

				case PinType.Place:
					return global::Xamarin.Forms.Maps.PinType.Place;

				case PinType.SavedPin:
					return global::Xamarin.Forms.Maps.PinType.SavedPin;

				case PinType.SearchResult:
					return global::Xamarin.Forms.Maps.PinType.SearchResult;

				default:
					return global::Xamarin.Forms.Maps.PinType.Generic;
			}
		}

		public static PinType Parse(global::Xamarin.Forms.Maps.PinType pinType)
		{
			switch (pinType)
			{
				case global::Xamarin.Forms.Maps.PinType.Generic:
					return PinType.Generic;

				case global::Xamarin.Forms.Maps.PinType.Place:
					return PinType.Place;

				case global::Xamarin.Forms.Maps.PinType.SavedPin:
					return PinType.SavedPin;

				case global::Xamarin.Forms.Maps.PinType.SearchResult:
					return PinType.SearchResult;

				default:
					return PinType.Generic;
			}
		}

		public static global::Xamarin.Forms.Maps.MapSpan Parse(MapSpan mapSpan)
		{
			return new global::Xamarin.Forms.Maps.MapSpan(Parse(mapSpan.Center), mapSpan.LatitudeDegrees, mapSpan.LongitudeDegrees);
		}

		public static MapSpan Parse(global::Xamarin.Forms.Maps.MapSpan mapSpan)
		{
			return new MapSpan(Parse(mapSpan.Center), mapSpan.LatitudeDegrees, mapSpan.LongitudeDegrees);
		}

		#endregion
	}
}
