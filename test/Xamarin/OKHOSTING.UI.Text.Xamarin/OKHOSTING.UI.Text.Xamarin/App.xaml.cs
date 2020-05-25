
using OKHOSTING.UI.Test.Misc;

namespace OKHOSTING.UI.Text.Xamarin
{
    public partial class App : global::Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            var page = new UI.Xamarin.Forms.Page();
            page.App = new UI.App();
            var index = new IndexController();
            index.Page = page;

            index.Start();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
