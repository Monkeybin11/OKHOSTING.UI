using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Layout
{
	/// <summary>
	/// It represents a container where we can be stacked controls.								
	/// <para xml:lang="es">
	/// Representa un contenedor donde podemos ir apilando controles.
	/// </para>
	/// </summary>
	public class Flow : global::Xamarin.Forms.StackLayout, IFlow
	{
		/// <summary>
		/// The children controls.
		/// <para xml:lang="es">Lista de los controles hijos del Stack</para>
		/// </summary>
		protected readonly ControlList _Children;

		/// <summary>
		/// Initializes a new instance of the Stack class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase Stack</para>
		/// </summary>
		public Flow()
		{
			_Children = new ControlList(base.Children);
			base.Orientation = global::Xamarin.Forms.StackOrientation.Horizontal;
		}

		/// <summary>
		/// Gets the controls IStack children.
		/// <para xml:lang="es">Obtiene la lista de los controles hijos del Stack.</para>
		/// </summary>
		IList<IControl> IFlow.Children
		{
			get
			{
				return _Children;
			}
		}

		/// <summary>
		/// The identifier dispose.
		/// <para xml:lang="es">El identificador Dispose.</para>
		/// </summary>
		void IDisposable.Dispose()
		{
		}

		#region IControl
		/// <summary>
		/// Friendly programming name (or id) of the control. A simple view should not contain 2 controls with the same name.
		/// <para xml:lang="es">
		/// Nombre (o Id) de programacion amigable del control. Una simple vista no puede contener dos controles con el mismo nombre.
		/// </para>
		/// </summary>
		string IControl.Name
		{
			get; set;
		}

		/// <summary>
		/// Gets or sets wether the control is visible or not
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
		/// Width of the control, in density independent pixels
		/// <para xml:lang="es">
		/// Ancho del control, en dencidad de pixeles independientes.
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
		/// Height of the control, in density independent pixels.
		/// <para xml:lang="es">
		/// Altura del control, en dencididad de pixeles independiente
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
		/// Space that this control will set between itself and it's container
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su contenedor.
		/// </para>
		/// </summary>
		Thickness IControl.Margin
		{
			get; set;
		}

		/// <summary>
		/// Background color
		/// <para xml:lang="es">
		/// Color de fondo.
		/// </para>
		/// </summary>
		Color IControl.BackgroundColor
		{
			get
			{
				return Platform.Current.Parse(base.BackgroundColor);
			}
			set
			{
				base.BackgroundColor = Platform.Current.Parse(value);
			}
		}

		/// <summary>
		/// Border color
		/// <para xml:lang="es">
		/// Color del borde.
		/// </para>
		/// </summary>
		Color IControl.BorderColor
		{
			get;
			set;
		}

		/// <summary>
		/// Border width, in density independent pixels (DIP)
		/// <para xml:lang="es">
		/// Ancho del borde, en dencidad de pixeles independientes (DIP)
		/// </para>
		/// </summary>
		Thickness IControl.BorderWidth
		{
			get;
			set;
		}

		/// <summary>
		/// Horizontal alignment of the control with respect to it's container.
		/// <para xml:lang="es">
		/// Alineación horizontal del control con respecto a su contenedor.
		/// </para>
		/// </summary>
		HorizontalAlignment IControl.HorizontalAlignment
		{
			get
			{
				return Platform.Current.Parse(base.HorizontalOptions.Alignment);
			}
			set
			{
				base.HorizontalOptions = new global::Xamarin.Forms.LayoutOptions(Platform.Current.Parse(value), false);
			}
		}

		/// <summary>
		/// Vertical alignment of the control with respect to it's container
		/// <para xml:lang="es">
		/// Alineacion vertical del control con respecto a su contenedor.
		/// </para>
		/// </summary>
		VerticalAlignment IControl.VerticalAlignment
		{
			get
			{
				return Platform.Current.ParseVerticalAlignment(base.VerticalOptions.Alignment);
			}
			set
			{
				base.VerticalOptions = new global::Xamarin.Forms.LayoutOptions(Platform.Current.Parse(value), false);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un objeto con valor arbitrario que puede ser usado para almacenar informacion personalizada sobre este elemento.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">
		/// Devuelve el valor previsto. esta propiedad no contiene un valor predeterminado.
		/// </para>
		/// </remarks>
		object IControl.Tag
		{
			get; set;
		}

		#endregion
	}
}