using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.DataForms
{
	public class DateTimeField: DataField<DateTime>
	{
		public DateTime MinValue { get; set; }
		public DateTime MaxValue { get; set; }

		public override DateTime Value
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