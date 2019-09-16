using System;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.RPC.Controls
{
	public class Slider: Control, ISlider
	{
		public double Minimum
		{
			get
			{
				return (double) Get(nameof(Minimum));
			}
			set
			{
				Set(nameof(Minimum), value);
			}
		}

		public double Maximum
		{
			get
			{
				return (double) Get(nameof(Maximum));
			}
			set
			{
				Set(nameof(Maximum), value);
			}
		}

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

		public event EventHandler<double> ValueChanged
		{
			add
			{
				AddHybridEventHandler(nameof(ValueChanged), value);
			}
			remove
			{
				RemoveHybridEventHandler(nameof(ValueChanged), value);
			}
		}
	}
}