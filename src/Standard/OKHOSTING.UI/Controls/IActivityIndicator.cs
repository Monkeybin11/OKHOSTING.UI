using System.Drawing;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// Visual control used to indicate that a task is being executed
	/// </summary>
	public interface IActivityIndicator: IControl
	{
		bool IsRunning { get; set; }
		Color Color { get; set; }
	}
}