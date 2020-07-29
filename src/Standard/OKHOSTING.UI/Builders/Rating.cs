using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Linq;

namespace OKHOSTING.UI.Builders
{
	public class Rating : IBuilder<IFlow>
	{
		protected readonly IFlow Flow = BaitAndSwitch.Create<IFlow>();

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
		public readonly int Height;

		public Rating(int maxValue, int value, int height)
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

			MaxValue = maxValue;
			Height = height;

			for (int i = 1; i <= MaxValue; i++)
			{
				IImageButton button = BaitAndSwitch.Create<IImageButton>();

				button.Click += button_Click;
				button.Tag = i;
				button.Width = button.Height = Height;

				Flow.Children.Add(button);
			}


			Value = value;
		}

		private void button_Click(object sender, EventArgs e)
		{
			var button = (IImageButton) sender;
			var newValue = (int) button.Tag;

			Value = newValue;
		}

		protected virtual void Refresh()
		{
			var buttons = Flow.Children.ToArray();

			for (int i = 1; i <= MaxValue; i++)
			{
				var button = (IImageButton) buttons[i - 1];

				if (i > Value)
				{
					button.LoadFromBytes(Resources.Images.StarGray);
				}
				else
				{
					button.LoadFromBytes(Resources.Images.StarYellow);
				}
			}
		}
	}
}