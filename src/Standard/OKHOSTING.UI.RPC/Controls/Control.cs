using OKHOSTING.UI.Controls;
using System.Drawing;

namespace OKHOSTING.UI.RPC.Controls
{
	/// <summary>
	/// Base class for all user controls
	/// <para xml:lang="es">Interfaz base para todos los controles de usuario.</para>
	/// </summary>
	public abstract class Control: OKHOSTING.RPC.Bidireccional.ServerObject, IControl
	{
		/// <summary>
		/// Friendly programming name (or id) of the control. A simple view should not contain 2 controls with the same name.
		/// <para xml:lang="es">
		/// Nombre (o Id) de programacion amigable del control. Una simple vista no puede contener dos controles con el mismo nombre.
		/// </para>
		/// </summary>
		public string Name
		{
			get
			{
				return (string) Get(nameof(Name));
			}
			set
			{
				Set(nameof(Name), value);
			}
		}

		/// <summary>
		/// Gets or sets wether the control is visible or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es visible o no.
		/// </para>
		/// </summary>
		public bool Visible
		{
			get
			{
				return (bool) Get(nameof(Visible));
			}
			set
			{
				Set(nameof(Visible), value);
			}
		}

		/// <summary>
		/// Gets or sets wether the control is enabled or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es habilitado o no.
		/// </para>
		/// </summary>
		public bool Enabled
		{
			get
			{
				return (bool) Get(nameof(Enabled));
			}
			set
			{
				Set(nameof(Enabled), value);
			}
		}

		/// <summary>
		/// Width of the control, in density independent pixels
		/// <para xml:lang="es">
		/// Ancho del control, en dencidad de pixeles independientes.
		/// </para>
		/// </summary>
		public double? Width
		{
			get
			{
				return (double?) Get(nameof(Width));
			}
			set
			{
				Set(nameof(Width), value);
			}
		}

		/// <summary>
		/// Height of the control, in density independent pixels.
		/// <para xml:lang="es">
		/// Altura del control, en dencididad de pixeles independiente
		/// </para>
		/// </summary>
		public double? Height
		{
			get
			{
				return (double?) Get(nameof(Name));
			}
			set
			{
				Set(nameof(Name), value);
			}
		}

		/// <summary>
		/// Space that this control will set between itself and it's container
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su contenedor.
		/// </para>
		/// </summary>
		public Thickness Margin
		{
			get
			{
				return (Thickness) Get(nameof(Margin));
			}
			set
			{
				Set(nameof(Margin), value);
			}
		}

		/// <summary>
		/// Background color
		/// <para xml:lang="es">
		/// Color de fondo.
		/// </para>
		/// </summary>
		public Color BackgroundColor
		{
			get
			{
				return (Color) Get(nameof(BackgroundColor));
			}
			set
			{
				Set(nameof(BackgroundColor), value);
			}
		}

		/// <summary>
		/// Border color
		/// <para xml:lang="es">
		/// Color del borde.
		/// </para>
		/// </summary>
		public Color BorderColor
		{
			get
			{
				return (Color) Get(nameof(BorderColor));
			}
			set
			{
				Set(nameof(BorderColor), value);
			}
		}

		/// <summary>
		/// Border width, in density independent pixels (DIP)
		/// <para xml:lang="es">
		/// Ancho del borde, en dencidad de pixeles independientes (DIP)
		/// </para>
		/// </summary>
		public Thickness BorderWidth
		{
			get
			{
				return (Thickness) Get(nameof(BorderWidth));
			}
			set
			{
				Set(nameof(BorderWidth), value);
			}
		}

		/// <summary>
		/// Horizontal alignment of the control with respect to it's container.
		/// <para xml:lang="es">
		/// Alineacion horizontal del control con respecto a su contenedor.
		/// </para>
		/// </summary>
		public HorizontalAlignment HorizontalAlignment
		{
			get
			{
				return (HorizontalAlignment) Get(nameof(HorizontalAlignment));
			}
			set
			{
				Set(nameof(HorizontalAlignment), value);
			}
		}

		/// <summary>
		/// Vertical alignment of the control with respect to it's container
		/// <para xml:lang="es">
		/// Alineacion vertical del control con respecto a su contenedor.
		/// </para>
		/// </summary>
		public VerticalAlignment VerticalAlignment
		{
			get
			{
				return (VerticalAlignment) Get(nameof(VerticalAlignment));
			}
			set
			{
				Set(nameof(VerticalAlignment), value);
			}
		}

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">
		/// Obtiene o establece un objeto de valor arbitrario que se puede usar para almacenar informacion personalizada sobre este elemento.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">
		/// Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.
		/// </para>
		/// </remarks>
		public object Tag
		{
			get
			{
				return Get(nameof(Tag));
			}
			set
			{
				Set(nameof(Tag), value);
			}
		}

		/// <summary>
		/// Gets or sets a list of classes that define a control's style. 
		/// Exactly the same concept as in CSS. 
		/// </summary>
		public string CssClass { get; set; }
	}
}