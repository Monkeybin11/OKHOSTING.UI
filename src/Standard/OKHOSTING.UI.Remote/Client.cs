using OKHOSTING.RPC;
using System;

namespace OKHOSTING.UI.Remote
{
	public class Client
	{
		public void Start()
		{
			ClientBase client = Core.BaitAndSwitch.Create<ClientBase>();
			client.Bidireccional = true;
			client.Execute(() => Core.BaitAndSwitch.Create<Server>(), new Variable("server"));
			client.Execute<Server, Operation>(server => server.Start());
		}
	}
}