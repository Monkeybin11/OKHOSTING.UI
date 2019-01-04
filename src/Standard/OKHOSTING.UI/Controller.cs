using System;

namespace OKHOSTING.UI
{
	/// <summary>
	/// This is the class that controlls all the UI. Inherit from Controller and create your app specific controllers.
	/// Each controller can have many methods 
	/// <para xml:lang="es">
	/// Esta es la clase que controla toda la interfaz de usuario. Hereda de Controller y crea sus controladores especificos de aplicaciones.
	/// Cada controlador puede tener muchos metodos.
	/// </para>
	/// </summary>
	public abstract class Controller: IDisposable
	{
		public Controller()
		{
		}

		public Controller(IPage page)
		{
			if (page == null)
			{
				throw new ArgumentNullException(nameof(page));
			}

			Page = page;
		}

		/// <summary>
		/// Private page field
		/// </summary>
		protected IPage _Page;

		/// <summary>
		/// Raised when the page is resized
		/// </summary>
		protected void Page_Resized(object sender, EventArgs e)
		{
			Refresh();
		}

		/// <summary>
		/// Will be executed when this controller "executes" at first
		/// <para xml:lang="es">Se produce cuando este controlador "ejecuta" un primer metodo.</para>
		/// </summary>
		internal protected abstract void OnStart();

		/// <summary>
		/// Gets the Page that is currently being displayed to the user
		/// <para xml:lang="es">Obtiene la pagina que actualmente se esta mostrando al usuario</para>
		/// </summary>
		public virtual IPage Page
		{
			get
			{
				return _Page;
			}
			set
			{
				_Page = value;

				if (_Page != null)
				{
					_Page.Resized -= Page_Resized;
					_Page.Resized += Page_Resized;
				}
			}
		}

		/// <summary>
		/// Will be executed when the controller gets the focus once again, after giving focus to another controller, or after page resize
		/// <para xml:lang="es">
		/// Sera ejecutado cuando el control recibe la atencion una vez mas, despues de dar atencion a otro controlador, o cuando la pagina cambia de tamaño.
		/// </para>
		/// </summary>
		public virtual void Refresh()
		{
		}

		/// <summary>
		/// Finishes the execution of this controller
		/// <para xml:lang="es">
		/// Finaliza la ejecucion de este controlador
		/// </para>
		/// </summary>
		protected virtual void Finish()
		{
			Page.App.FinishController(Page);
		}

		/// <summary>
		/// Starts the execution of this controller on the page
		/// <para xml:lang="es">Arranca la ejecucion de este controlador en la pagina</para>
		/// </summary>
		public virtual void Start()
		{
			Page.App.StartController(this);
		}

		public virtual void Dispose()
		{
		}
	}
}