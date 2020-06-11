namespace OKHOSTING.UI
{
	public static class IControlExtensions
	{
		public static void CopySize(this IControl control, IPage page)
		{
			control.Width = page.Width;
			control.Height = page.Height;
		}

		public static void CopySize(this IControl control, IControl other)
		{
			control.Width = other.Width;
			control.Height = other.Height;
		}
	}
}