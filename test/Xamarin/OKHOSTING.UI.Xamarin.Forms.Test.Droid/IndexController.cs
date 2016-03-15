using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OKHOSTING.UI;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Xamarin.Forms.Test.Droid
{
    public class IndexController : Controller
    {
        public override void Start()
        {
            base.Start();

            IStack stack = Platform.Current.Create<IStack>();

            IButton play = Platform.Current.Create<IButton>();
            play.Text = "play";
            play.Click += Play_Click;
            stack.Children.Add(play);

            IButton pause = Platform.Current.Create<IButton>();
            pause.Text = "pause";
            pause.Click += Pause_Click;
            stack.Children.Add(pause);

            IButton stop = Platform.Current.Create<IButton>();
            stop.Text = "stop";
            stop.Click += Stop_Click;
            stack.Children.Add(stop);

            Platform.Current.Page.Title = "straming";
            Platform.Current.Page.Content = stack;
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(StreamingBackgroundService.ActionStop);
            global::Xamarin.Forms.Forms.Context.StartService(intent);
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(StreamingBackgroundService.ActionPause);
            global::Xamarin.Forms.Forms.Context.StartService(intent);
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(StreamingBackgroundService.ActionPlay);
            global::Xamarin.Forms.Forms.Context.StartService(intent);
        }
    }
}