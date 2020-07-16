using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OKHOSTING.UI.Net4.WebForms.Syncfusion.Startup))]
namespace OKHOSTING.UI.Net4.WebForms.Syncfusion
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			ConfigureAuth(app);
		}
	}
}
