using OKHOSTING.Security.InApp;

namespace OKHOSTING.UI.Security
{
	/// <summary>
	/// Exception that is thrown when a database security violation is performed
	/// </summary>
	public class AuthorizationException : OKHOSTING.Security.InApp.AuthorizationException
	{
		/// <summary>
		/// AuthenticatedController the user was trying to start
		/// </summary>
		public readonly SecureController Controller;

		/// <summary>
		/// Creates a new instance
		/// </summary>
		/// <param name="user">User that performs the security violation</param>
		/// <param name="dtype">DataType that was being accesed by the user</param>
		/// <param name="operation">Operation the user was trying to perform</param>
		public AuthorizationException(User user, SecureController controller): base(user)
		{
			Controller = controller;
		}

		/// <summary>
		/// Creates a new instance
		/// </summary>
		/// <param name="user">User that performs the security violation</param>
		/// <param name="dtype">DataType that was being accesed by the user</param>
		/// <param name="operation">Operation the user was trying to perform</param>
		/// <param name="message">Custom message for this exception</param>
		public AuthorizationException(User user, SecureController controller, string message): base(user, message)
		{
			Controller = controller;
		}

		public override string Message
		{
			get
			{
				return
					base.Message +
					". " +
					"User : " + User +
					", " +
					"Controller : " + Controller;
			}
		}
	}
}