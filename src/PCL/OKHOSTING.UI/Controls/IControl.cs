using System;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// Base interface for all user controls
	/// <para xml:lang="es">Interfaz base para todos los controles de usuario.</para>
	/// </summary>
	public interface IControl: IDisposable
	{
		/// <summary>
		/// Friendly programming name (or id) of the control. A simple view should not contain 2 controls with the same name.
		/// <para xml:lang="es">
		/// Nombre (o Id) de programacion amigable del control. Una simple vista no puede contener dos controles con el mismo nombre.
		/// </para>
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Gets or sets wether the control is visible or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es visible o no.
		/// </para>
		/// </summary>
		bool Visible { get; set; }

		/// <summary>
		/// Gets or sets wether the control is enabled or not
		/// <para xml:lang="es">
		/// Obtiene o establece si el control es habilitado o no.
		/// </para>
		/// </summary>
		bool Enabled { get; set; }

		/// <summary>
		/// Width of the control, in density independent pixels
		/// <para xml:lang="es">
		/// Ancho del control, en dencidad de pixeles independientes.
		/// </para>
		/// </summary>
		double? Width { get; set; }

		/// <summary>
		/// Height of the control, in density independent pixels.
		/// <para xml:lang="es">
		/// Altura del control, en dencididad de pixeles independiente
		/// </para>
		/// </summary>
		double? Height { get; set; }

		/// <summary>
		/// Space that this control will set between itself and it's container
		/// <para xml:lang="es">
		/// Espacio que este control se establecerá entre si mismo y su contenedor.
		/// </para>
		/// </summary>
		Thickness Margin { get; set; }

		/// <summary>
		/// Background color
		/// <para xml:lang="es">
		/// Color de fondo.
		/// </para>
		/// </summary>
		Color BackgroundColor { get; set; }

		/// <summary>
		/// Border color
		/// <para xml:lang="es">
		/// Color del borde.
		/// </para>
		/// </summary>
		Color BorderColor { get; set; }

		/// <summary>
		/// Border width, in density independent pixels (DIP)
		/// <para xml:lang="es">
		/// Ancho del borde, en dencidad de pixeles independientes (DIP)
		/// </para>
		/// </summary>
		Thickness BorderWidth { get; set; }

		/// <summary>
		/// Horizontal alignment of the control with respect to it's container.
		/// <para xml:lang="es">
		/// Alineacion horizontal del control con respecto a su contenedor.
		/// </para>
		/// </summary>
		HorizontalAlignment HorizontalAlignment { get; set; }

		/// <summary>
		/// Vertical alignment of the control with respect to it's container
		/// <para xml:lang="es">
		/// Alineacion vertical del control con respecto a su contenedor.
		/// </para>
		/// </summary>
		VerticalAlignment VerticalAlignment { get; set; }

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
		object Tag { get; set; }
	}
}