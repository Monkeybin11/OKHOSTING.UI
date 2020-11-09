using System;

namespace OKHOSTING.UI.Animations.MemberTypes
{
	/// <summary>
	/// Class that manages transitions for Position properties. For these we
	/// need to transition the X and Y sub-properties independently.
	/// </summary>
	/// <remarks>
	/// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
	/// </remarks>
	internal class Point : IMemberType
	{
		/// <summary>
		/// Returns the type we are managing.
		/// </summary>
		public Type GetManagedType()
		{
			return typeof(System.Drawing.Point);
		}

		/// <summary>
		/// Returns a Copy of the color object passed in.
		/// </summary>
		public object Copy(object o)
		{
			System.Drawing.Point c = (System.Drawing.Point) o;
			System.Drawing.Point result = new System.Drawing.Point(c.X, c.Y);

			return result;
		}

		/// <summary>
		/// Creates an intermediate value for the colors depending on the percentage passed in.
		/// </summary>
		public object GetIntermediateValue(object start, object end, double dPercentage)
		{
			System.Drawing.Point _start = (System.Drawing.Point) start;
			System.Drawing.Point _end = (System.Drawing.Point) end;

			int iStart_X = _start.X;
			int iStart_Y = _start.Y;

			int iEnd_X = _end.X;
			int iEnd_Y = _end.Y;

			int new_X = Utility.interpolate(iStart_X, iEnd_X, dPercentage);
			int new_Y = Utility.interpolate(iStart_Y, iEnd_Y, dPercentage);

			return new System.Drawing.Point(new_X, new_Y);
		}
	}
}