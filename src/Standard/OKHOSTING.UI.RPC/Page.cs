using System;

namespace OKHOSTING.UI.RPC
{
	/// <summary>
	/// Represents a "window" that contains a view. In WinForms this is a Form, in ASP.NET a WebForm, in Xamarin Forms it will be a Page
	/// <para xml:lang="es">
	/// Representa una "ventana" que contiene una vista. En WinForms se trata de un formulario, en ASP.NET es un formulario web, en Xamarin forms sera una pagina.
	/// </para>
	/// </summary>
	public class Page: OKHOSTING.RPC.Bidireccional.ServerObject, IPage
	{
		/// <summary>
		/// App that is running on this page
		/// </summary>
		public App App
		{
			get
			{
				return (App) Get(nameof(App));
			}
			set
			{
				Set(nameof(App), value);
			}
		}

		/// <summary>
		/// Title for this page
		/// <para xml:lang="es">
		/// El titulo para esta pagina.
		/// </para>
		/// </summary>
		public string Title
		{
			get
			{
				return (string) Get(nameof(Title));
			}
			set
			{
				Set(nameof(Title), value);
			}
		}

		/// <summary>
		/// Each Page only contains one main view, which can optionally be a container and contain more views
		/// <para xml:lang="es">
		/// Cada ventana solo contiene una vista principal, que puede ser opcionalmente un contenedor y contener mas vistas.
		/// </para>
		/// </summary>
		public IControl Content
		{
			get
			{
				return (IControl) Get(nameof(Content));
			}
			set
			{
				Set(nameof(Content), value);
			}
		}

		/// <summary>
		/// Width of the page, in density independent pixels
		/// <para xml:lang="es">
		/// Anchura de la pagina, en la dencidad de pixeles independientes.
		/// </para>
		/// </summary>
		public double? Width
		{
			get
			{
				return (double?) Get(nameof(Width));
			}
		}

		/// <summary>
		/// Height of the page, in density independent pixels
		/// <para xml:lang="es">
		/// Altura de la página, en la densidad de pixeles independientes.
		/// </para>
		/// </summary>
		public double? Height
		{
			get
			{
				return (double?) Get(nameof(Height));
			}
		}

		/// <summary>
		/// Raised when the page is resized
		/// </summary>
		public event EventHandler Resized
		{
			add
			{
				AddHybridEventHandler(nameof(Resized), value);
			}
			remove
			{
				RemoveHybridEventHandler(nameof(Resized), value);
			}
		}

		public void InvokeOnMainThread(Action action)
		{
			Invoke(nameof(InvokeOnMainThread), action);
		}
	}
}