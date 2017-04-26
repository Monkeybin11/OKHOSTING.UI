using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Remote.Client
{
	public class RemoteController: Controller
	{
		public readonly Uri Host;

		public RemoteController(Uri host)
		{
			if (host == null)
			{
				throw new ArgumentNullException(nameof(host));
			}

			Host = host;
		}

		public override void Start()
		{
			base.Start();
		}
	}
}