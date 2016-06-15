using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.Forms
{
	/// <summary>The current page
	/// <para xml:lang="es">
	/// Es la pagina actual
	/// </para>
	/// </summary>
	public class Page : global::Xamarin.Forms.ContentPage, IPage
	{
		/// <summary>
		/// The scroll.
		/// <para xml:lang="es">El scroll de la pagina.</para>
		/// </summary>
		private readonly global::Xamarin.Forms.ScrollView Scroll;

		/// <summary>
		/// Initializes a new instance of the Page class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase Page</para>
		/// </summary>
		public Page()
		{
			Scroll = new global::Xamarin.Forms.ScrollView();
			base.Content = Scroll;
		}

		/// <summary>
		/// Gets or sets the content.
		/// <para xml:lang="es">Obtiene o establece el contenido de la pagina actual.</para>
		/// </summary>
		/// <value>The content.</value>
		public new IControl Content
		{
			get
			{
				return (IControl) Scroll.Content;
			}
			set
			{
				Scroll.Content = (global::Xamarin.Forms.View) value;
			}
		}

		/// <summary>
		/// Ons the size allocated.
		/// <para xml:lang="es">El tamaño asignado a la pagina.</para>
		/// </summary>
		/// <returns>The size allocated.</returns>
		/// <param name="width">Width.</param>
		/// <param name="height">Height.</param>
		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);

			if (Platform.Current.Controller != null)
			{
				Platform.Current.Controller.Resize();
			}
		}
	}
}