namespace OKHOSTING.UI.Controls.Builders
{
	/// <summary>
	/// A class that builds a control or group of controls with a predefined behaviour,
	/// this is not as complex as a controller, since this does not "start" or "end", it just
	/// builds a control or group of controls that do something more complex than just being a control
	/// </summary>
	public interface IBuilder<T> where T : IControl
	{
		T Content
		{
			get;
		}
	}
}