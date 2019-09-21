using System;
using System.Collections.Generic;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Represents a user session in an application, that can be used in web and windows environments
	/// for storing custom session values
	/// <para xml:lang="es">
	/// Representa una sesion de usuario en una aplicacion, que se puede utilizar en la web y entornos de windows 
	/// para almacenar valores de sesión personalizados.
	/// </para>
	/// </summary>
	public class Session: Dictionary<string, object>, IDisposable
	{
		/// <summary>
		/// Creates a new session instance and invokes OnSession_Start
		/// <para xml:lang="es">
		/// Crea una nueva instancia de la sesión e invoca OnSession_Start
		/// </para>
		/// </summary>
		/// <param name="id">Session ID for the current session
		/// <para xml:lang="es">ID de sesión para la sesión actual.</para>
		/// </param>
		private Session(string id)
		{
			this.SessionId = id;
		}

		/// <summary>
		/// Destroys the current session instance and invokes OnSession_End
		/// <para xml:lang="es">
		/// Destruye la instancia de la sesión actual e invoca OnSession_End
		/// </para>
		/// </summary>
		~Session()
		{
			//End();
		}

		/// <summary>
		/// Gets the unique identifier for the session.
		/// <para xml:lang="es">
		/// Obtiene el identificador unico para la sesión.
		/// </para>
		/// </summary>
		public readonly string SessionId;

		/// <summary>
		/// Returns the current sesion Id
		/// <para xml:lang="es">
		/// Regresa el Id de la sesión actual.
		/// </para>
		/// </summary>
		public override string ToString()
		{
			return this.SessionId;
		}

		/// <summary>
		/// End this instance.
		/// <para xml:lang="es">
		/// Finaliza esta instancia.
		/// </para>
		/// </summary>
		public void End()
		{
			OnSessionEnd();
		}

		/// <summary>
		/// Invoked when a new session is started. Raises Session_Start event and invokes DataType.OnSessionStart() in all loaded DataTypes
		/// <para xml:lang="es">
		/// Se invoca cuando se inicia una nueva sesión. Lanza el evento Session_Start e invoca DataType.OnSessionStart() en todos los tipos de datos cargados.
		/// </para>
		/// </summary>
		protected virtual void OnSessionStart()
		{
			Session_Start?.Invoke(this, new EventArgs());
		}

		/// <summary>
		/// Invoked when a session is ended. Raises Session_End event and invokes DataType.OnSessionEnd() in all loaded DataTypes
		/// <para xml:lang="es">
		/// Se invoca cuando se termina una sesión. Lanza el evento Session_End  e invoca DataType.OnSessionEnd() en todos los tipod de datos cargados.
		/// </para>
		/// </summary>
		protected virtual void OnSessionEnd()
		{
			//raise events
			Session_End?.Invoke(this, new EventArgs());

			//clear all session data
			this.Clear();

			//remove from the sessions collection
			Sessions.Remove(this.SessionId);

			////remove cookie if we are in a web context
			//if (HttpContext.Current != null)
			//{
			//	HttpCookie sessionCookie = HttpContext.Current.Request.Cookies["Session.Id"];

			//	if (sessionCookie != null)
			//	{
			//		sessionCookie.Expires = DateTime.Now.AddDays(-1);
			//		HttpContext.Current.Response.Cookies.Add(sessionCookie);
			//	}
			//}
		}

		/// <summary>
		/// Session identifier provider.
		/// <para xml:lang="es">Proveedor de Id de sesión.</para>
		/// </summary>
		public class SessionIdProvider
		{
			public virtual string GetCurrentSessionId()
			{
				//return 1 always for desktop and mobile applications
				//override this method on web so you return a diferent id for each user
				return "1";
			}
		}

		#region Static

		/// <summary>
		/// Initiates the static session collection
		/// <para xml:lang="es">Inicia la coleccion de sesión estatica.</para>
		/// </summary>
		static Session()
		{
			Sessions = new Dictionary<string, Session>();
			IdProvider = new SessionIdProvider();
		}

		/// <summary>
		/// Gets or sets the identifier provider.
		/// <para xml:lang="es">Obtiene o establece el proveedor de id de sesión</para>
		/// </summary>
		public static SessionIdProvider IdProvider { get; set; }

		/// <summary>
		/// Stores the databases objects currently loaded
		/// <para xml:lang="es">
		/// Almacena las bases de datos de objetos actualmente cargados.
		/// </para>
		/// </summary>
		private static readonly Dictionary<string, Session> Sessions;

		/// <summary>
		/// Retrieve the Session associated to the current process
		/// <para xml:lang="es">
		/// Recupara la sesión asociada al proceso actual.
		/// </para>
		/// </summary>
		public static Session Current
		{
			get
			{
				//Getting the session ID
				string id = IdProvider.GetCurrentSessionId();

				//Retrieving the Session if it's defined, otherwise creating 
				//the session saves in databases collection and retrieving
				if (Sessions.ContainsKey(id))
				{
					return Sessions[id];
				}
				else
				{
					//Loading the Session
					Session current = new Session(id);

					//Storing the Session Object in Sessions collection
					lock(Sessions)
					{
						Sessions.Add(id, current);
					}

					//call OnSession_Start to raise Session_Start event
					current.OnSessionStart();

					//Retrieving Session recently created
					return current;
				}
			}
		}

		/// <summary>
		/// Raised when a new session is started.
		/// <para xml:lang="es">
		/// Se genera cuando se inicia una nueva sesión.
		/// </para>
		/// </summary>
		public static event EventHandler Session_Start;

		/// <summary>
		/// Raised when a session is ended.
		/// <para xml:lang="es">
		/// Se genera cuando se termina una sesión.
		/// </para>
		/// </summary>
		public static event EventHandler Session_End;

		#endregion

		#region IDisposable Members

		/// <summary>
		/// Releases resources for the current session.
		/// <para xml:lang="es">
		/// Libera los recursos de la sesión actual.
		/// </para>
		/// </summary>
		void IDisposable.Dispose()
		{
			base.Clear();
		}

		#endregion
	}
}