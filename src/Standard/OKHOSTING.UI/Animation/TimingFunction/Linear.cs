using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Animations.TimingFunction
{
	/// <summary>
	/// This class manages a linear transition. The percentage complete for the transition
	/// increases linearly with time.
	/// </summary>
	/// <remarks>
	/// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
	/// </remarks>
	public class Linear : ITimingFunction
    {
        #region Public methods

        /// <summary>
        /// Constructor. You pass in the time (in milliseconds) that the
        /// transition will take.
        /// </summary>
        public Linear(int transitionTime)
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
		/// We return the percentage completed.
		/// </summary>
		public void OnTimer(int time, out double percentage, out bool completed)
		{
			percentage = (time / TransitionTime);
			if (percentage >= 1.0)
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
