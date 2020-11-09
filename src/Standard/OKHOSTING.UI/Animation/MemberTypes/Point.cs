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
		public object GetIntermediateValue(object start, object end, double percentage)
		{
			System.Drawing.Point _start = (System.Drawing.Point) start;
			System.Drawing.Point _end = (System.Drawing.Point) end;

			int start_X = _start.X;
			int start_Y = _start.Y;

			int end_X = _end.X;
			int end_Y = _end.Y;

			int new_X = Utility.Interpolate(start_X, end_X, percentage);
			int new_Y = Utility.Interpolate(start_Y, end_Y, percentage);

			return new System.Drawing.Point(new_X, new_Y);
		}
	}
}