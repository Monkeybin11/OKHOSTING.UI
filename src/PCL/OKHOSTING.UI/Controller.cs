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
	public abstract class Controller
	{
		/// <summary>
		/// Will be executed when this controller "executes" at first
		/// <para xml:lang="es">Se produce cuando este controlador "ejecuta" un primer metodo.</para>
		/// </summary>
		public virtual void Start()
		{
			Platform.Current.StartController(this);
		}

		/// <summary>
		/// Will be  executed when the window is resized, allowing the controller to re-arrange the page, therefore making it "responsive"
		/// <para xml:lang="es">
		/// Se ejecutara cuando se cambia el tamaño de la ventana, permitiendo que el control vuelva a ordenar la pagina ya que es sencible.
		/// </para>
		/// </summary>
		public virtual void Resize()
		{
		}

		/// <summary>
		/// Will be executed when the controller gets the focus once again, after gibing focus to another control
		/// <para xml:lang="es">
		/// Sera ejecutado cuando el control recibe la atencion una vez mas, despues de dar atencion a otro control.
		/// </para>
		/// </summary>
		public virtual void Refresh()
		{
		}

		/// <summary>
		/// Will be execeuted once the controller has done it's workd. Use this to dispose objects and release memory
		/// <para xml:lang="es">
		/// Sera ejecutada una vez que el control ha hecho su trabajo. Use esto para deshechar objetos y liberar la memoria.
		/// </para>
		/// </summary>
		public virtual void Finish()
		{
			Platform.Current.FinishController();
		}
	}
}