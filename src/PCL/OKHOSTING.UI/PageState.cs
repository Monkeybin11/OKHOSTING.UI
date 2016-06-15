namespace OKHOSTING.UI
{
	/// <summary>
	/// Represents the "state" of a page, which consist only of a Title and a Content.
	/// Use this class to save/restore a page state
	/// <para xml:lang="es">
	/// Representa el "estado" de una página, que consiste sólo de un título y un contenido.
	/// Utilice esta clase para guardar/restaurar un estado de la pagina.
	/// </para>
	/// </summary>
	public class PageState
	{
		/// <summary>
		/// Initializes a new instance of the PageState class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase PageState.</para>
		/// </summary>
		public PageState()
		{
		}

		/// <summary>
		/// Initializes a new instance of the PageState class whit the specified title and content.
		/// <para xml:lang="es">
		/// Inicializa una nueva instancia se la clase PageState con el titulo y el contenido especificados
		/// </para>
		/// </summary>
		/// <param name="title">Title.
		/// <para xml:lang="es">El titulo</para>
		/// </param>
		/// <param name="content">Content.
		/// <para xml:lang="es">El contenido.</para>
		/// </param>
		public PageState(string title, Controls.IControl content)
		{
			Title = title;
			Content = content;
		}

		/// <summary>
		/// Gets or sets the title.
		/// <para xml:lang="es">Obtiene o establece el titulo de la pagina.</para>
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the content.
		/// <para xml:lang="es">Obtiene o establece el contenido de la pagina.</para>
		/// </summary>
		public Controls.IControl Content { get; set; }
	}
}