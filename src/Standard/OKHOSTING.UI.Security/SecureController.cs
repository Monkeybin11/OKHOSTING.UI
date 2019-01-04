using OKHOSTING.Security.InApp;

namespace OKHOSTING.UI.Security
{
	public class SecureController: Controller
	{
		public SecureController()
		{
		}

		public SecureController(IPage page) : base(page)
		{
		}

		/// <summary>
		/// Authentication used for this controller
		/// </summary>
		public AuthenticationBase Authentication
		{
			get; set;
		}

		protected override void OnStart()
		{
			//apply security here
			if (Authentication == null)
			{
				throw new AuthorizationException(null, this, "Authentication property can't be null");
			}

			if (Authentication.CurrentSession == null && !(this is Login) && !(this is Register))
			{
				throw new AuthorizationException(null, this, "A session has not yet started");
			}
		}
	}
}