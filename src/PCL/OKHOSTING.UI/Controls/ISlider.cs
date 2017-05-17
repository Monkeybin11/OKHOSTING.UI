namespace OKHOSTING.UI.Controls
{
	public interface ISlider: IInputControl<double>
	{
		double Minimum { get; set; }
		double Maximum { get; set; }
	}
}