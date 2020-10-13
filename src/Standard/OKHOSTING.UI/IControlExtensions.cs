namespace OKHOSTING.UI
{
	public static class IControlExtensions
	{
		/// <summary>
		/// Set the control's size to be the same as the page
		/// </summary>
		/// <param name="control">Control which size will be modified</param>
		/// <param name="page">Page from wich the size will be obtained</param>
		public static void CopySize(this IControl control, IPage page)
		{
			control.Width = page.Width;
			control.Height = page.Height;
		}

		/// <summary>
		/// Set the control's size to be the same as the other control
		/// </summary>
		/// <param name="control">Control which size will be modified</param>
		/// <param name="other">Control from wich the size will be obtained</param>
		public static void CopySize(this IControl control, IControl other)
		{
			control.Width = other.Width;
			control.Height = other.Height;
		}
	}
}