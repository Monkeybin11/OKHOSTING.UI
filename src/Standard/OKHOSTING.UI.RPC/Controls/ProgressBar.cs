namespace OKHOSTING.UI.RPC.Controls
{
	public class ProgressBar : Control
	{
		/// <summary>
		/// Progress value, must be between 0 and 100
		/// </summary>
		public double Value
		{
			get
			{
				return (double) Get(nameof(Value));
			}
			set
			{
				Set(nameof(Value), value);
			}
		}
	}
}