using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Controllers
{
	public class Chronometer: Controller
	{
		protected readonly Timer Timer = new Timer(TimeSpan.FromSeconds(1));
		
		public ILabel Display { get; protected set; }

		public bool ShowMilliseconds { get; set; } = false;

		public TimeSpan Elapsed 
		{ 
			get;
			protected set;
		}

		public Chronometer()
		{
		}

		public Chronometer(IPage page) : base(page)
		{
		}

		public void Stop()
		{
			Timer.Stop();
		}

		public void Resume()
		{
			Timer.Start().Wait();
		}
		
		public void Reset()
		{
			Timer.Stop();
			Elapsed = TimeSpan.Zero;
			UpdateDisplay();
		}

		protected internal override void OnStart()
		{
			Display = BaitAndSwitch.Create<ILabel>();

			if (ShowMilliseconds)
			{
				Timer.Interval = TimeSpan.FromMilliseconds(1);
			}
			else
			{ 
				Timer.Interval = TimeSpan.FromSeconds(1);
			}

			Timer.Elapsed += Timer_Elapsed;
		}

		private void Timer_Elapsed(object sender, EventArgs e)
		{
			if (ShowMilliseconds)
			{
				Elapsed = Elapsed.Add(TimeSpan.FromMilliseconds(1));
			}
			else
			{
				Elapsed = Elapsed.Add(TimeSpan.FromSeconds(1));
			}

			UpdateDisplay();
		}

		protected void UpdateDisplay()
		{
			string format;

			if (ShowMilliseconds)
			{
				format = "hh:mm:ss:fff";
			}
			else
			{
				format = "hh:mm:ss";
			}

			Display.Text = Elapsed.ToString(format);
		}
	}
}