﻿using System;
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
	public class Linear : ITransitionType
    {
        #region Public methods

        /// <summary>
        /// Constructor. You pass in the time (in milliseconds) that the
        /// transition will take.
        /// </summary>
        public Linear(int iTransitionTime)
        {
			if (iTransitionTime <= 0)
			{
				throw new Exception("Transition time must be greater than zero.");
			}
			m_dTransitionTime = iTransitionTime;
        }

        #endregion

		#region ITransitionMethod Members

		/// <summary>
		/// We return the percentage completed.
		/// </summary>
		public void OnTimer(int iTime, out double dPercentage, out bool bCompleted)
		{
			dPercentage = (iTime / m_dTransitionTime);
			if (dPercentage >= 1.0)
			{
				dPercentage = 1.0;
				bCompleted = true;
			}
			else
			{
				bCompleted = false;
			}
		}

		#endregion

		#region Private data

		private double m_dTransitionTime = 0.0;

		#endregion
	}
}
