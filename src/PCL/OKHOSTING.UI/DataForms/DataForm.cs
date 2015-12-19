using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.DataForms
{
	public class DataForm: Controller
	{
		public readonly List<DataField> Fields = new List<DataField>();

		public override void Start()
		{
			base.Start();
		}

		public override void Resize()
		{
			base.Resize();
		}
	}
}