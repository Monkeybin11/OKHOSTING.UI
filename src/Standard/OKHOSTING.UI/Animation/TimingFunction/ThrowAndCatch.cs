using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Animations.TimingFunction
{
    /// <summary>
    /// This transition bounces the property to a destination value and back to the
    /// original value. It is decelerated to the destination and then acclerated back
    /// as if being thrown against gravity and then descending back with gravity.
    /// </summary>
    /// <remarks>
    /// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
    /// </remarks>
    public class ThrowAndCatch : UserDefined
    {
        #region Public methods

        /// <summary>
        /// Constructor. You pass in the total time taken for the bounce.
        /// </summary>
        public ThrowAndCatch(int transitionTime)
        {
            // We create a custom "user-defined" transition to do the work...
            IList<TransitionElement> elements = new List<TransitionElement>();
            elements.Add(new TransitionElement(50, 100, InterpolationMethod.Deceleration));
            elements.Add(new TransitionElement(100, 0, InterpolationMethod.Accleration));
            base.setup(elements, transitionTime);
        }

        #endregion
    }
}
