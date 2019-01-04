namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// An IPage that is also a IControl, allowing you to add it as a control, but then assign a controller to it and let it work.
	/// The controller will believe this is the main Page and will work as espected, inside the UserControl.
	/// </summary>
	public interface IUserControl: IPage, IControl
	{
	}
}