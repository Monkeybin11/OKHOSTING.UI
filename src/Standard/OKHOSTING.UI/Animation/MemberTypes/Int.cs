using System;

namespace OKHOSTING.UI.Animations.MemberTypes
{
	/// <summary>
	/// Manages transitions for int properties.
	/// </summary>
	/// <remarks>
	/// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
	/// </remarks>
	internal class Int : IMemberType
    {
		/// <summary>
		/// Returns the type we are managing.
		/// </summary>
		public Type GetManagedType()
		{
			return typeof(int);
		}

		/// <summary>
		/// Returns a Copy of the int passed in.
		/// </summary>
		public object Copy(object o)
		{
			int value = (int)o;
			return value;
		}

		/// <summary>
		/// Returns the value between the start and end for the percentage passed in.
		/// </summary>
		public object GetIntermediateValue(object start, object end, double percentage)
		{
			int _start = (int)start;
			int _end = (int)end;
			return Utility.Interpolate(_start, _end, percentage);
		}
	}
}
