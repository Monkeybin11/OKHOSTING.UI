using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.DataForms
{
	public class IntegerField : DataField<int>
	{
		public int MinValue { get; set; }
		public int MaxValue { get; set; }

		public override int Value
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