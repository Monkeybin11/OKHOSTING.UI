using OKHOSTING.Data;
using System.Collections.Generic;

namespace OKHOSTING.UI.Animation
{
	/// <summary>
	/// A point in time where the property of a control will be changed
	/// </summary>
	public class KeyFrame
	{
		public KeyFrame()
		{
		}

		public KeyFrame(int percentage)
		{
			Percentage = percentage;
		}

		public KeyFrame(int percentage, MemberExpression member, object value)
		{
			Percentage = percentage;
			Changes.Add(member, value);
		}

		/// <summary>
		/// Specify when the member's value change will happen in percent, 
		/// 0% is the beginning of the animation, 100% is when the animation is complete.
		/// </summary>
		public int Percentage { get; set; }

		/// <summary>
		/// Changes that will be performed on the animated control. 
		/// Each item has the member that will be modified and the value that will be given to the member
		/// </summary>
		public Dictionary<MemberExpression, object> Changes = new Dictionary<MemberExpression, object>();
	}
}