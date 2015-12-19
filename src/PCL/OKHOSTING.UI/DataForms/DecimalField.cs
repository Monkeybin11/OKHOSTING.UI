using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.DataForms
{
	public class DecimalField : DataField<double>
	{
		public double MinValue { get; set; }
		public double MaxValue { get; set; }

		public override double Value
		{
			get
			{
				throw new NotImplementedException();
			}

			set
			{
				throw new NotImplementedException();
			}
		}
	}
}