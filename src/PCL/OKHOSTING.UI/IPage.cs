using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Represents a "window" that contains a view. In WinForms this is a Form, in ASP.NET a WebForm, in Xamarin Forms it will be a Page
    /// <para xml:lang="es">
    /// Representa una "ventana" que contiene una vista. En WinForms se trata de un formulario, en ASP.NET es un formulario web, en Xamarin forms sera una pagina.
    /// </para>
	/// </summary>
	public interface IPage
	{
		/// <summary>
		/// Title for this page
        /// <para xml:lang="es">
        /// El titulo para esta pagina.
        /// </para>
		/// </summary>
		string Title { get; set; }

		/// <summary>
		/// Each window only contains one main view, which can optionally be a container and contain more views
        /// <para xml:lang="es">
        /// Cada ventana solo contiene una vista principal, que puede ser opcionalmente un contenedor y contener mas vistas.
        /// </para>
		/// </summary>
		Controls.IControl Content { get; set; }

		/// <summary>
		/// Width of the screen, in density independent pixels
        /// <para xml:lang="es">
        /// Anchura de la pantalla, en la dencidad de pixeles independientes.
        /// </para>
		/// </summary>
		double Width { get; }

		/// <summary>
		/// Height of the screen, in density independent pixels
        /// <para xml:lang="es">
        /// Altura de la pantalla, en la densidad de pixeles independientes.
        /// </para>
		/// </summary>
		double Height { get; }
	}
}