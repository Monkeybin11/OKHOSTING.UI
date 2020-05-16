namespace OKHOSTING.UI.Builders
{
	/// <summary>
	/// A class that builds a control or group of controls with a predefined behaviour,
	/// this is not as complex as a controller, since this does not "start" or "end", it just
	/// builds a control or container of controls that do something more complex than just being a control
	/// </summary>
	public interface IBuilder
	{
		/// <summary>
		/// The control that has been built and is ready to be used
		/// </summary>
		IControl Control
		{
			get;
		}
	}

	/// <summary>
	/// A class that builds a control or group of controls with a predefined behaviour,
	/// this is not as complex as a controller, since this does not "start" or "end", it just
	/// builds a control or container of controls that do something more complex than just being a control
	/// </summary>
	public interface IBuilder<T> : IBuilder where T : IControl
	{
		/// <summary>
		/// The control that has been built and is ready to be used
		/// </summary>
		new T Control
		{
			get;
		}
	}
}