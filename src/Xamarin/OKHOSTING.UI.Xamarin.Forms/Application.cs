using System;

namespace OKHOSTING.UI.Xamarin.Forms
{
	/// <summary>
	/// Application.
	/// <para xml:lang="es">La aplicacion en ejecución</para>
	/// </summary>
	public class Application : global::Xamarin.Forms.Application
	{
		/// <summary>
		/// Initializes a new instance of the Application class.
		/// <para xml:lang="es">Inicializa una nueva instancia de la clase Application</para>
		/// </summary>
		public Application ()
		{
			Platform.Page = new Page();
			MainPage = (global::Xamarin.Forms.Page) Platform.Page;
		}

		/// <summary>
		/// Ons the start.
		/// <para xml:lang="es">Inicia la aplicacion.</para>
		/// </summary>
		/// <returns>The start.</returns>
		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		/// <summary>
		/// Ons the sleep.
		/// <para xml:lang="es">Suspende la aplicacion.</para>
		/// </summary>
		/// <returns>The sleep.</returns>
		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		/// <summary>
		/// Ons the resume.
		/// </summary>
		/// <returns>The resume.</returns>
		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}