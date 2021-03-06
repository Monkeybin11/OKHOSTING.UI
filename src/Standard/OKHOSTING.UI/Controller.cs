﻿using System;

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
		/// True if the controller has already started (even if it has already finished as well)
		/// </summary>
		public bool IsStarted { get; protected set; }

		/// <summary>
		/// True if the controller has already finished
		/// </summary>
		public bool IsFinished { get; protected set; }

		public event EventHandler Finished;

		/// <summary>
		/// Gets the Page that is currently being displayed to the user
		/// <para xml:lang="es">Obtiene la pagina que actualmente se esta mostrando al usuario</para>
		/// </summary>
		public virtual IPage Page
		{
			get;
			set;
		}

		/// <summary>
		/// Starts the execution of this controller on the page
		/// <para xml:lang="es">Arranca la ejecucion de este controlador en la pagina</para>
		/// </summary>
		public virtual void Start()
		{
			Page.App.StartController(this);
			IsStarted = true;
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

		public virtual void Dispose()
		{
			if (!IsFinished)
			{
				Finish();
			}
		}

		/// <summary>
		/// Finishes the execution of this controller
		/// <para xml:lang="es">
		/// Finaliza la ejecucion de este controlador
		/// </para>
		/// </summary>
		public virtual void Finish()
		{
			Page.App.FinishController(Page);
			IsFinished = true;
			Finished?.Invoke(this, new EventArgs());
		}

		/// <summary>
		/// Will be executed when this controller "executes" at first
		/// <para xml:lang="es">Se produce cuando este controlador "ejecuta" un primer metodo.</para>
		/// </summary>
		internal protected abstract void OnStart();
	}
}