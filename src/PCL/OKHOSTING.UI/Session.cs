using System;
using System.Collections.Generic;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Represents a user session in an application, that can be used in web and windows environments
	/// for storing custom session values
	/// </summary>
	public class Session: Dictionary<string, object>, IDisposable
	{
		/// <summary>
		/// Creates a new session instance and invokes OnSession_Start
		/// </summary>
		/// <param name="id">Session ID for the current session</param>
		private Session(string id)
		{
			this.SessionId = id;
		}

		/// <summary>
		/// Destroys the current session instance and invokes OnSession_End
		/// </summary>
		~Session()
		{
			//End();
		}

		/// <summary>
		/// Gets the unique identifier for the session.
		/// </summary>
		public readonly string SessionId;

		/// <summary>
		/// Returns the current sesion Id
		/// </summary>
		public override string ToString()
		{
			return this.SessionId;
		}

		public void End()
		{
			OnSessionEnd();
		}

		/// <summary>
		/// Invoked when a new session is started. Raises Session_Start event and invokes DataType.OnSessionStart() in all loaded DataTypes
		/// </summary>
		protected virtual void OnSessionStart()
		{
			if (Session_Start != null)
			{
				Session_Start(this, new EventArgs());
			}
		}

		/// <summary>
		/// Invoked when a session is ended. Raises Session_End event and invokes DataType.OnSessionEnd() in all loaded DataTypes
		/// </summary>
		protected virtual void OnSessionEnd()
		{
			//raise events
			if (Session_End != null)
			{
				Session_End(this, new EventArgs());
			}

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
		/// </summary>
		static Session()
		{
			Sessions = new Dictionary<string, Session>();
			IdProvider = new SessionIdProvider();
		}

		public static SessionIdProvider IdProvider { get; set; }

		/// <summary>
		/// Stores the databases objects currently loaded
		/// </summary>
		private static readonly Dictionary<string, Session> Sessions;

		/// <summary>
		/// Retrieve the Session associated to the current process
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
		/// Raised when a new session is started
		/// </summary>
		public static event EventHandler Session_Start;

		/// <summary>
		/// Raised when a session is ended
		/// </summary>
		public static event EventHandler Session_End;

		#endregion

		#region IDisposable Members

		void IDisposable.Dispose()
		{
			base.Clear();
		}

		#endregion
	}
}