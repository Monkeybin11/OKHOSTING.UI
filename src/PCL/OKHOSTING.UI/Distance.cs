namespace OKHOSTING.UI
{
	public class Distance
	{
		public Distance()
		{
		}

		public Distance(decimal value, DistanceUnit unit)
		{
			Value = value;
			Unit = unit;
		}

		public decimal Value { get; set; }
		public DistanceUnit Unit { get; set; }
	}
}