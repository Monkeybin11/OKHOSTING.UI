namespace OKHOSTING.UI.Controls
{
	public interface IProgressBar : IControl
	{
		/// <summary>
		/// Progress value, must be between 0 and 100
		/// </summary>
		double Value { get; set; }
	}
}