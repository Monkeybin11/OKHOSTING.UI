using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI
{
	public class MemberView: View
	{
		public MemberInfo Member { get; set; }
		public bool ReadOnly{ get; set; }
	}
}