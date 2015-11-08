using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI
{
	/// <summary>
	/// Creates instances of controls and actually creates all UI for the user. 
	/// Inherited classes should create platform-specific controls and implement page navigation
	/// </summary>
	public abstract class App
	{
		public string Name { get; set; }

		public string Version { get; set; }
		public string Author { get; set; }
		public string Copyright { get; set; }



		/// <summary>
		/// Shows a new page to the user
		/// </summary>
		public abstract void ShowPage(IPage page);

		public IPage MainPage { get; set; }


		#region Static

		/// <summary>
		/// Current activator that will be used to create all controls. Set this at the very beginning of your app,
		/// and set a platform-specific Activator
		/// </summary>
		public static App CurrentApp
		{
			get;
			protected set;
		}

		#endregion
	}
}