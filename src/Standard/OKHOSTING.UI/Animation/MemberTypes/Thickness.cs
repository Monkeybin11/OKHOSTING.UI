using System;

namespace OKHOSTING.UI.Animations.MemberTypes
{
	/// <summary>
	/// Class that manages transitions for Thickness properties. For these we
	/// need to transition the Left, Top, Right and Bottom sub-properties independently.
	/// </summary>
	/// <remarks>
	/// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
	/// </remarks>
	internal class Thickness : IMemberType
	{
		/// <summary>
		/// Returns the type we are managing.
		/// </summary>
		public Type GetManagedType()
		{
			return typeof(UI.Thickness);
		}

		/// <summary>
		/// Returns a Copy of the color object passed in.
		/// </summary>
		public object Copy(object o)
		{
			UI.Thickness c = (UI.Thickness) o;
			UI.Thickness result = new UI.Thickness(c.Left, c.Top, c.Right, c.Bottom);

			return result;
		}

		/// <summary>
		/// Creates an intermediate value for the colors depending on the percentage passed in.
		/// </summary>
		public object GetIntermediateValue(object start, object end, double dPercentage)
		{
			UI.Thickness _start = (UI.Thickness) start;
			UI.Thickness _end = (UI.Thickness) end;

			double iStart_Left = _start.Left;
			double iStart_Top = _start.Top;
			double iStart_Right = _start.Right;
			double iStart_Bottom = _start.Bottom;

			double iEnd_Left = _end.Left;
			double iEnd_Top = _end.Top;
			double iEnd_Right = _end.Right;
			double iEnd_Bottom = _end.Bottom;

			double new_Left = Utility.interpolate(iStart_Left, iEnd_Left, dPercentage);
			double new_Top = Utility.interpolate(iStart_Top, iEnd_Top, dPercentage);
			double new_Right = Utility.interpolate(iStart_Right, iEnd_Right, dPercentage);
			double new_Bottom = Utility.interpolate(iStart_Bottom, iEnd_Bottom, dPercentage);

			return new UI.Thickness(new_Left, new_Top, new_Right, new_Bottom);
		}
	}
}
