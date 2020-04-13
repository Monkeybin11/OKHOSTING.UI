using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace OKHOSTING.UI.RPC.Animation
{
	/// <summary>
	/// Defines how to animate a control
	/// </summary>
	public class Animation : OKHOSTING.RPC.Bidireccional.ServerObject
	{
		/// <summary>
		/// Page where this animation will be running
		/// </summary>
		public IPage Page
		{
			get
			{
				return (IPage) Get(nameof(Page));
			}
			set
			{
				Set(nameof(Page), value);
			}
		}

		/// <summary>
		/// Specifies a delay before the animation will start
		/// </summary>
		public TimeSpan Delay
		{
			get
			{
				return (TimeSpan) Get(nameof(Delay));
			}
			set
			{
				Set(nameof(Delay), value);
			}
		}

		/// <summary>
		/// Specifies whether or not the animation should play in reverse on alternate cycles
		/// </summary>
		public Direction Direction
		{
			get
			{
				return (Direction) Get(nameof(Direction));
			}
			set
			{
				Set(nameof(Direction), value);
			}
		}

		/// <summary>
		/// Specifies how much time an animation takes to complete
		/// </summary>
		public TimeSpan Duration
		{
			get
			{
				return (TimeSpan) Get(nameof(Duration));
			}
			set
			{
				Set(nameof(Duration), value);
			}
		}

		/// <summary>
		/// Specifies how many times an animation should be played
		/// </summary>
		public int Iterations
		{
			get
			{
				return (int) Get(nameof(Iterations));
			}
			set
			{
				Set(nameof(Iterations), value);
			}
		}

		/// <summary>
		/// Specifies what values are applied by the animation outside the time it is executing
		/// </summary>
		public FillMode FillMode
		{
			get
			{
				return (FillMode) Get(nameof(FillMode));
			}
			set
			{
				Set(nameof(FillMode), value);
			}
		}


		/// <summary>
		/// Specifies the speed curve of the animation
		/// </summary>
		public Core.Math.Easings.Functions TimingFunction
		{
			get
			{
				return (Core.Math.Easings.Functions) Get(nameof(TimingFunction));
			}
			set
			{
				Set(nameof(TimingFunction), value);
			}
		}

		/// <summary>
		/// Points in time that represent the actual changes in the controls that must
		/// be performed at diferent points in time. At least 2 keyframes are needed for 
		/// and the 0 and 100 respectively, representing the beginig and end of the animation
		/// </summary>
		public ICollection<UI.Animation.KeyFrame> KeyFrames
		{
			get
			{
				return (ICollection<UI.Animation.KeyFrame>) Get(nameof(KeyFrames));
			}
			set
			{
				Set(nameof(KeyFrames), value);
			}
		}

		/// <summary>
		/// Apply the animation on a control at this moment
		/// </summary>
		public virtual async Task Start(IControl control, IPage page)
		{
			await Task.Run(() => Invoke(nameof(Start), control, page));
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
			return (IEnumerable<double>) Invoke(nameof(GetGradient), from, to, steps));
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
		public IEnumerable<Color> GetGradients(Color start, Color end, int steps)
		{
			return (IEnumerable<Color>) Invoke(nameof(GetGradients), start, end, steps));
		}
	}
}