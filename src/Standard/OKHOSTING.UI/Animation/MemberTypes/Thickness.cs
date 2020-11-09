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
		public object GetIntermediateValue(object start, object end, double percentage)
		{
			UI.Thickness _start = (UI.Thickness) start;
			UI.Thickness _end = (UI.Thickness) end;

			double start_Left = _start.Left;
			double start_Top = _start.Top;
			double start_Right = _start.Right;
			double start_Bottom = _start.Bottom;

			double end_Left = _end.Left;
			double end_Top = _end.Top;
			double end_Right = _end.Right;
			double end_Bottom = _end.Bottom;

			double new_Left = Utility.Interpolate(start_Left, end_Left, percentage);
			double new_Top = Utility.Interpolate(start_Top, end_Top, percentage);
			double new_Right = Utility.Interpolate(start_Right, end_Right, percentage);
			double new_Bottom = Utility.Interpolate(start_Bottom, end_Bottom, percentage);

			return new UI.Thickness(new_Left, new_Top, new_Right, new_Bottom);
		}
	}
}
