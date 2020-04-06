namespace OKHOSTING.UI.Animation
{
	/// <summary>
	/// A point in time where the property of a control will be changed
	/// </summary>
	public class KeyFrame
	{
		/// <summary>
		/// Specify when the member's value change will happen in percent, 
		/// 0% is the beginning of the animation, 100% is when the animation is complete.
		/// </summary>
		public int Percentage { get; set; }

		/// <summary>
		/// Member of the control that will be updated at this point in time
		/// </summary>
		public Data.MemberExpression Member { get; set; }

		/// <summary>
		/// Value that will be set at the member of the control, at this point in time of the animation
		/// </summary>
		public object Value { get; set; }
	}
}