using System;

namespace OKHOSTING.UI.Animations.MemberTypes
{
	/// <summary>
	/// Class that manages transitions for Color properties. For these we
	/// need to transition the R, G, B and A sub-properties independently.
	/// </summary>
	/// <remarks>
	/// Based on a great project by Uwe Keim https://github.com/UweKeim/dot-net-transitions
	/// </remarks>
	internal class Color : IMemberType
	{
		/// <summary>
		/// Returns the type we are managing.
		/// </summary>
		public Type GetManagedType()
		{
			return typeof(System.Drawing.Color);
		}

		/// <summary>
		/// Returns a Copy of the color object passed in.
		/// </summary>
		public object Copy(object o)
		{
			System.Drawing.Color c = (System.Drawing.Color)o;
			System.Drawing.Color result = System.Drawing.Color.FromArgb(c.ToArgb());
			return result;
		}

		/// <summary>
		/// Creates an intermediate value for the colors depending on the percentage passed in.
		/// </summary>
		public object GetIntermediateValue(object start, object end, double dPercentage)
		{
			System.Drawing.Color startColor = (System.Drawing.Color)start;
			System.Drawing.Color endColor = (System.Drawing.Color)end;

			// We interpolate the R, G, B and A components separately...
			int iStart_R = startColor.R;
			int iStart_G = startColor.G;
			int iStart_B = startColor.B;
			int iStart_A = startColor.A;

			int iEnd_R = endColor.R;
			int iEnd_G = endColor.G;
			int iEnd_B = endColor.B;
			int iEnd_A = endColor.A;

			int new_R = Utility.interpolate(iStart_R, iEnd_R, dPercentage);
			int new_G = Utility.interpolate(iStart_G, iEnd_G, dPercentage);
			int new_B = Utility.interpolate(iStart_B, iEnd_B, dPercentage);
			int new_A = Utility.interpolate(iStart_A, iEnd_A, dPercentage);

			return System.Drawing.Color.FromArgb(new_A, new_R, new_G, new_B);
		}
	}
}
