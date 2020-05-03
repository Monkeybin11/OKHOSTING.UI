using OKHOSTING.RPC.DataSources;
using OKHOSTING.UI.Test;
using System;

namespace OKHOSTING.UI.Net4.WinForms.RPCTest
{
	public partial class Form1 : Page
	{
		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (App == null)
			{
				App = new App();
			}

			OKHOSTING.RPC.WebSockets.Listener server = new OKHOSTING.RPC.WebSockets.Listener()
			{
				Host = new Uri("ws://0.0.0.0:8181"),
			};

			OKHOSTING.RPC.WebSockets.Client client = new OKHOSTING.RPC.WebSockets.Client()
			{
				Host = new Uri("ws://localhost:8181"),
			};

			server.Start();

			client.Connect();

			OKHOSTING.RPC.Bidireccional.Client bidirClient = new OKHOSTING.RPC.Bidireccional.Client();

			bidirClient.Listener = new OKHOSTING.RPC.Reverse.Async.Listener();
			bidirClient.Listener.Local = new OKHOSTING.RPC.Server();
			bidirClient.Listener.Remote = client;

			OKHOSTING.RPC.Bidireccional.Server bidirServer = new OKHOSTING.RPC.Bidireccional.Server();
			bidirServer.Client = new OKHOSTING.RPC.Reverse.Async.Server();
			bidirServer.Client.InnerServer = new OKHOSTING.RPC.Server();

			App.MainPage = this;
		}
	}
}
