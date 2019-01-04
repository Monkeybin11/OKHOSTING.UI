using System;

namespace OKHOSTING.UI.Remote
{
	/// <summary>
	/// Represents a "window" that contains a view. In WinForms this is a Form, in ASP.NET a WebForm, in Xamarin Forms it will be a Page
	/// <para xml:lang="es">
	/// Representa una "ventana" que contiene una vista. En WinForms se trata de un formulario, en ASP.NET es un formulario web, en Xamarin forms sera una pagina.
	/// </para>
	/// </summary>
	public class Page: IPage
	{
		public RPC.Server Server { get; set; }

		private App _App;

		/// <summary>
		/// App that is running on this page
		/// </summary>
		public App App
		{
			get
			{
				return _App;
			}
			set
			{
				_App = value;
				Server.Execute(new RPC.Value(value), new RPC.Member() { Instance = new RPC.Variable("page"), Expression = new Data.MemberExpression<Page>(p=> p.App) });
			}
		}

		/// <summary>
		/// Title for this page
		/// <para xml:lang="es">
		/// El titulo para esta pagina.
		/// </para>
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Each Page only contains one main view, which can optionally be a container and contain more views
		/// <para xml:lang="es">
		/// Cada ventana solo contiene una vista principal, que puede ser opcionalmente un contenedor y contener mas vistas.
		/// </para>
		/// </summary>
		public UI.Controls.IControl Content { get; set; }

		/// <summary>
		/// Width of the page, in density independent pixels
		/// <para xml:lang="es">
		/// Anchura de la pagina, en la dencidad de pixeles independientes.
		/// </para>
		/// </summary>
		public double? Width { get; }

		/// <summary>
		/// Height of the page, in density independent pixels
		/// <para xml:lang="es">
		/// Altura de la página, en la densidad de pixeles independientes.
		/// </para>
		/// </summary>
		public double? Height { get; }

		/// <summary>
		/// Raised when the page is resized
		/// </summary>
		public event EventHandler Resized;

		public virtual void CopyTo(IPage page)
		{
			page.Title = Title;
			page.Content = Content;
		}
	}
}