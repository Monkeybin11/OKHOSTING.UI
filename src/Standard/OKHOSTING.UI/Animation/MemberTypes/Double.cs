using System;

namespace OKHOSTING.UI.Animations.MemberTypes
{
	/// <summary>
	/// Manages transitions for double properties.
	/// </summary>
	/// <remarks>
	/// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
	/// </remarks>
	internal class Double : IMemberType
	{
		/// <summary>
		///  Returns the type managed by this class.
		/// </summary>
		public Type GetManagedType()
		{
			return typeof(double);
		}

		/// <summary>
		/// Returns a Copy of the double passed in.
		/// </summary>
		public object Copy(object o)
		{
			double d = (double)o;
			return d;
		}

		/// <summary>
		/// Returns the value between start and end for the percentage passed in.
		/// </summary>
		public object GetIntermediateValue(object start, object end, double dPercentage)
		{
			double dStart = (double)start;
			double dEnd = (double)end;
			return Utility.interpolate(dStart, dEnd, dPercentage);
		}
	}
}
