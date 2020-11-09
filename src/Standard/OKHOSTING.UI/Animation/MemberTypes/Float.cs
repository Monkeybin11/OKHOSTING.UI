using System;

namespace OKHOSTING.UI.Animations.MemberTypes
{
    /// <remarks>
    /// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
    /// </remarks>
    internal class Float : IMemberType
    {
        /// <summary>
        /// Returns the type we're managing.
        /// </summary>
        public Type GetManagedType()
        {
            return typeof(float);
        }

        /// <summary>
        /// Returns a Copy of the float passed in.
        /// </summary>
        public object Copy(object o)
        {
            float f = (float)o;
            return f;
        }

        /// <summary>
        /// Returns the interpolated value for the percentage passed in.
        /// </summary>
        public object GetIntermediateValue(object start, object end, double dPercentage)
        {
            float fStart = (float)start;
            float fEnd = (float)end;
            return Utility.interpolate(fStart, fEnd, dPercentage);
        }
    }
}
