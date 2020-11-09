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
		public object GetIntermediateValue(object start, object end, double dPercentage)
		{
			System.Drawing.PointF _start = (System.Drawing.PointF) start;
			System.Drawing.PointF _end = (System.Drawing.PointF) end;

			float iStart_X = _start.X;
			float iStart_Y = _start.Y;

			float iEnd_X = _end.X;
			float iEnd_Y = _end.Y;

			float new_X = Utility.interpolate(iStart_X, iEnd_X, dPercentage);
			float new_Y = Utility.interpolate(iStart_Y, iEnd_Y, dPercentage);

			return new System.Drawing.PointF(new_X, new_Y);
		}
	}
}