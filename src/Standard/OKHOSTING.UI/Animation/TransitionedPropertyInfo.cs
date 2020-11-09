namespace OKHOSTING.UI.Animations
{
	/// <summary>
	/// Holds information about one property on one taregt object that we are performing a transition on...
	/// </summary>
	internal class TransitionedMember
	{
		public object startValue;
		public object endValue;
		public object target;
		public Data.MemberExpression Member;
		public IMemberType managedType;

		public TransitionedMember copy()
		{
			TransitionedMember info = new TransitionedMember();
			info.startValue = startValue;
			info.endValue = endValue;
			info.target = target;
			info.Member = Member;
			info.managedType = managedType;
			return info;
		}
	}
}