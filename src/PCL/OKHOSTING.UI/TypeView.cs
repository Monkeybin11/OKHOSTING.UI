using OKHOSTING.Data.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI
{
	public class TypeView: View
	{
		Type Type;
		IEnumerable<MemberExpression> Members;
		IEnumerable<ValidatorBase> Validators;
	}
}
