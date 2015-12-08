namespace OKHOSTING.UI
{
	/// <summary>
	/// Represents a top, bottom, left right value. Can be used for margins, paddings, borders, etc.
	/// </summary>
	public struct Thickness
	{
		public Thickness(double uniformLength)
		{
			Left = Right = Top = Bottom = uniformLength;
		}

		public Thickness(double? left = null, double? top = null, double? right = null, double? bottom = null)
		{
			Left = left;
			Right = right;
			Top = top;
			Bottom = bottom;
		}

		public double? Bottom { get; set; }
		public double? Left { get; set; }
		public double? Right { get; set; }
		public double? Top { get; set; }
	}
}