
using OKHOSTING.UI.Test;

namespace OKHOSTING.UI.Text.Xamarin
{
    public partial class App : global::Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();
            var page = new UI.Xamarin.Forms.Page();
            page.App = new UI.App();
            var index = new IndexController(page);
            //index.Page = page;
            MainPage = page;

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
