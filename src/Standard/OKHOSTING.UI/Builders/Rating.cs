using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;

namespace OKHOSTING.UI.Builders
{
	public class Rating : IBuilder<IFlow>
	{
		protected readonly IFlow Flow = BaitAndSwitch.Create<IFlow>();
		protected readonly IImageButton On, Off;

		public IFlow Control => Flow;
		IControl IBuilder.Control => Flow;

		int _Value;

		public int Value 
		{
			get
			{
				return _Value;
			}
			set 
			{
				_Value = value;
				Refresh();
			}
		}

		public readonly int MaxValue;

		public Rating(int maxValue, int value, IImageButton off, IImageButton on)
		{
			if (value < 1)
			{
				throw new ArgumentOutOfRangeException(nameof(value), "Arugment 'value' must be greather than zero");
			}

			if (value > maxValue)
			{
				throw new ArgumentOutOfRangeException(nameof(value), "Arugment 'value' must be lower than maxValue");
			}

			if (maxValue < 3)
			{
				throw new ArgumentOutOfRangeException(nameof(maxValue), "Arugment 'maxValue' must be greather than 2");
			}

			if (off == null)
			{
				throw new ArgumentNullException(nameof(off));
			}
			
			if (on == null)
			{
				throw new ArgumentNullException(nameof(on));
			}

			MaxValue = maxValue;
			Value = value;
			Off = off;
			On = on;

			Refresh();
		}

		private void button_Click(object sender, EventArgs e)
		{
			var button = (IImageButton) sender;
			var newValue = (int) button.Tag;

			Value = newValue;
		}

		protected virtual void Refresh()
		{
			Flow.Children.Clear();

			for (int i = 1; i <= MaxValue; i++)
			{
				IImageButton button;

				if (i < Value)
				{
					button = (IImageButton) Off.Clone();
				}
				else
				{
					button = (IImageButton) On.Clone();
				}

				button.Click += button_Click;
				button.Tag = i;

				Flow.Children.Add(button);
			}
		}
	}
}