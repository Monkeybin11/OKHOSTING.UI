namespace OKHOSTING.UI
{
	public class Measure
	{
		public Measure()
		{
		}

		public Measure(decimal value, MeasureUnit unit)
		{
			Value = value;
			Unit = unit;
		}

		public decimal Value { get; set; }
		public MeasureUnit Unit { get; set; }
	}
}