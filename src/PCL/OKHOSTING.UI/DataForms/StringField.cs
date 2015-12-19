using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.DataForms
{
	public class StringField : DataField<string>
	{
		public string RegexValidation { get; set; }
	}
}