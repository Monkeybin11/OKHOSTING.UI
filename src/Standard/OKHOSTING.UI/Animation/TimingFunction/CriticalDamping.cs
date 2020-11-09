using System;

namespace OKHOSTING.UI.Animations.TimingFunction
{
	/// <summary>
	/// This transition animates with an exponential decay. This has a damping effect
	/// similar to the motion of a needle on an electomagnetically controlled dial.
	/// </summary>
	/// <remarks>
	/// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
	/// </remarks>
	public class CriticalDamping : ITimingFunction
	{
		#region Public methods

		/// <summary>
		/// Constructor. You pass in the time that the transition 
		/// will take (in milliseconds).
		/// </summary>
		public CriticalDamping(int transitionTime)
		{
			if (transitionTime <= 0)
			{
				throw new Exception("Transition time must be greater than zero.");
			}

			TransitionTime = transitionTime;
		}

		#endregion

		#region ITransitionMethod Members

		/// <summary>
		/// </summary>
		public void OnTimer(int time, out double percentage, out bool completed)
		{
			// We find the percentage time elapsed...
			double elapsed = time / TransitionTime;
			percentage = (1.0 - Math.Exp(-1.0 * elapsed * 5)) / 0.993262053;

			if (elapsed >= 1.0)
			{
				percentage = 1.0;
				completed = true;
			}
			else
			{
				completed = false;
			}
		}

		#endregion

		#region Private data

		private double TransitionTime = 0.0;

		#endregion
	}
}
