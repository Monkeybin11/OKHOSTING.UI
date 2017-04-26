using System;
using System.Collections.Specialized;
using System.Linq;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Remote.Client.Controls
{
	public class Control : IControl
	{
		/// <summary>
		/// Gets or sets the name of the control.
		/// <para xml:lang="es">Obtiene o establece el nombre del control</para>
		/// </summary>
		/// <value>The name of the control.
		/// <para xml:lang="es">El nombre del control</para>
		/// </value>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the background of the control.
		/// <para xml:lang="es">Obtiene o establece el color de fondo del control</para>
		/// </summary>
		/// <value>The background of the hiperlink.
		/// <para xml:lang="es">El color de fondo del control.</para>
		/// </value>
		public Color BackgroundColor { get; set; }

		/// <summary>
		/// Gets or sets the BorderColor of the control.
		/// <para xml:lang="es">Obtiene o establece el color del borde del control</para>
		/// </summary>
		/// <value>The BorderColor of the control.
		/// <para xml:lang="es">El color del borde del control</para>
		/// </value>
		public Color BorderColor { get; set; }

		/// <summary>
		/// Gets or Sets the width of the control.
		/// <para xml:lang="es">Obtiene o establece el ancho del control</para>
		/// </summary>
		/// <value>The width of the control.
		/// <para xml:lang="es">El ancho del control</para>
		/// </value>
		public double? Width { get; set; }

		/// <summary>
		/// Gets or sets the Height of the control
		/// <para xml:lang="es">Obtiene o establece la altura del control</para>
		/// </summary>
		/// <value>The height of the control.
		/// <para xml:lang="es">La altura del control</para>
		/// </value>
		public double? Height { get; set; }

		/// <summary>
		/// Gets or sets the margin of the control.
		/// <para xml:lang="es">Obtien o establece el margen del control</para>
		/// </summary>
		/// <value>The margin of the control.
		/// <para xml:lang="es">El margen del control</para>
		/// </value>
		public Thickness Margin { get; set; }

		/// <summary>
		/// Gets or sets the BorderWidth of the control.
		/// <para xml:lang="es">Obtiene o establece el ancho del borde del control.</para>
		/// </summary>
		/// <value>The BorderWidth of the control.
		/// <para xml:lang="es">El ancho del borde del control.</para>
		/// </value>
		public Thickness BorderWidth { get; set; }

		/// <summary>
		/// Gets or sets the HorizontalAlignment of the control.
		/// <para xml:lang="es">Obtiene o establece la alineacion horizontal del control.</para>
		/// </summary>
		/// <value>The HorizontalAlignment of the control.
		/// <para xml:lang="es">La alineacion horizontal del control</para>
		/// </value>
		public HorizontalAlignment HorizontalAlignment { get; set; }

		/// <summary>
		/// Gets or sets the VerticalAlignment of the control.
		/// <para xml:lang="es">Obtiene o establece la alineación vertical del control</para>
		/// </summary>
		/// <value>The VerticalAlignemnt of the control.
		/// <para xml:lang="es">La alineación vertical del control</para>
		/// </value>
		public VerticalAlignment VerticalAlignment { get; set; }

		/// <summary>
		/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
		/// <para xml:lang="es">Obtiene o establece un valor de objeto arbitrario que puede ser usado para almacenar informacion personalizada de este objeto.</para>
		/// </summary>
		/// <remarks>
		/// Returns the intended value. This property has no default value.
		/// <para xml:lang="es">Devuelve el valor previsto. Esta propiedad no contiene un valor predeterminado.</para>
		/// </remmarks>
		public object Tag { get; set; }

		public bool Visible { get; set; }

		public bool Enabled { get; set; }

		public void Dispose()
		{
		}
	}
}