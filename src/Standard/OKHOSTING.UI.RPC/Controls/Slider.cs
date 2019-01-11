using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.RPC.Controls
{
	public class Slider: Control, ISlider
	{
		public double Minimum { get; set; }
		public double Maximum { get; set; }
		public double Value { get; set; }

		public event EventHandler<double> ValueChanged;
	}
}