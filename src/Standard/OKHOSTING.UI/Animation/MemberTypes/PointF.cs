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
	internal class PointF : IMemberType
	{
		/// <summary>
		/// Returns the type we are managing.
		/// </summary>
		public Type GetManagedType()
		{
			return typeof(System.Drawing.PointF);
		}

		/// <summary>
		/// Returns a Copy of the color object passed in.
		/// </summary>
		public object Copy(object o)
		{
			System.Drawing.PointF c = (System.Drawing.PointF) o;
			System.Drawing.PointF result = new System.Drawing.PointF(c.X, c.Y);

			return result;
		}

		/// <summary>
		/// Creates an intermediate value for the colors depending on the percentage passed in.
		/// </summary>
		public object GetIntermediateValue(object start, object end, double percentage)
		{
			System.Drawing.PointF _start = (System.Drawing.PointF) start;
			System.Drawing.PointF _end = (System.Drawing.PointF) end;

			float start_X = _start.X;
			float start_Y = _start.Y;

			float end_X = _end.X;
			float end_Y = _end.Y;

			float new_X = Utility.Interpolate(start_X, end_X, percentage);
			float new_Y = Utility.Interpolate(start_Y, end_Y, percentage);

			return new System.Drawing.PointF(new_X, new_Y);
		}
	}
}