using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Animation
{
	/// <summary>
	/// Defines how to animate a control
	/// </summary>
	public class Animation
	{
		/// <summary>
		/// Page where this animation will be running
		/// </summary>
		public IPage Page { get; set; }
		
		/// <summary>
		/// Specifies a delay before the animation will start
		/// </summary>
		public TimeSpan Delay { get; set; }

		/// <summary>
		/// Specifies whether or not the animation should play in reverse on alternate cycles
		/// </summary>
		public Direction Direction { get; set; } = Direction.Forward;

		/// <summary>
		/// Specifies how much time an animation takes to complete
		/// </summary>
		public TimeSpan Duration { get; set; }

		/// <summary>
		/// Specifies how many times an animation should be played
		/// </summary>
		public int Iterations { get; set; } = 1;

		/// <summary>
		/// Specifies what values are applied by the animation outside the time it is executing
		/// </summary>
		public FillMode FillMode { get; set; } = FillMode.Initial;

		/// <summary>
		/// Specifies the speed curve of the animation
		/// </summary>
		public Core.Math.Easings.Functions TimingFunction { get; set; }

		/// <summary>
		/// Points in time that represent the actual changes in the controls that must
		/// be performed at diferent points in time. At least 2 keyframes are needed for 
		/// and the 0 and 100 respectively, representing the beginig and end of the animation
		/// </summary>
		public ICollection<KeyFrame> KeyFrames { get; set; }

		/// <summary>
		/// Apply the animation on a control at this moment
		/// </summary>
		public virtual async Task Start(IControl control, IPage page)
		{
			int counter = 0;
			var frames = KeyFrames.ToArray();

			while (counter < Iterations || Iterations == -1)
			{
				await Task.Delay(Delay);

				for (int i = 0; i < frames.Length; i++)
				{
					var frame = frames[i];

					foreach (var change in frame.Changes)
					{
						page.InvokeOnMainThread(() => change.Key.SetValue(control, change.Value));
					}

					if (i < frames.Length - 1)
					{
						var nextFrame = frames[i + 1];
						double percentageDiff = nextFrame.Percentage - frame.Percentage;

						await Task.Delay((int) (percentageDiff / 100 * Duration.TotalMilliseconds));
					}
				}

				counter++;
			}
		}

		/// <summary>
		/// Gets a list of values that represent a gradient from one value to another
		/// </summary>
		/// <param name="from">Initial value</param>
		/// <param name="to">Final value</param>
		/// <param name="steps">
		/// How many steps must be taken to go from the initial
		/// value to the final value, how big are the increments
		/// </param>
		public IEnumerable<double> GetGradient(float from, float to, ulong steps)
		{
			//constants
			float diff = to - from;
			float stepValue = diff / steps;
			float normalizedStepValue = 1 / steps;

			//variables
			float step = from;
			float normalizedStep = 0;

			while (step < to)
			{
				//var easingValue = Core.Math.Easings.Interpolate(normalizedStep, TimingFunction);
				//var denormalizedEasingValue = stepValue * easingValue;

				//yield return step * denormalizedEasingValue;
				yield return step;

				step += stepValue;
				normalizedStep += normalizedStepValue;

				if ((from < to && step > to) || (from > to && step < to))
				{
					yield break;
				}
			}
		}


		/// <summary>
		/// Gets a list of values that represent a gradient from one color to another
		/// </summary>
		/// <param name="from">Initial color</param>
		/// <param name="to">Final color</param>
		/// <param name="steps">
		/// How many steps must be taken to go from the initial
		/// value to the final value, how big are the increments
		/// </param>
		public static IEnumerable<Color> GetGradients(Color start, Color end, int steps)
		{
			int stepA = ((end.A - start.A) / (steps - 1));
			int stepR = ((end.R - start.R) / (steps - 1));
			int stepG = ((end.G - start.G) / (steps - 1));
			int stepB = ((end.B - start.B) / (steps - 1));

			for (int i = 0; i < steps; i++)
			{
				yield return Color.FromArgb(start.A + (stepA * i),
											start.R + (stepR * i),
											start.G + (stepG * i),
											start.B + (stepB * i));
			}
		}
	}
}