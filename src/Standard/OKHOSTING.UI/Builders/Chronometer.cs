using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Builders
{
	public class Chronometer: IBuilder<ILabel>
	{
		protected readonly Timer Timer = new Timer(TimeSpan.FromSeconds(1));

		protected readonly ILabel Display = BaitAndSwitch.Create<ILabel>();
		
		protected TimeSpan Elapsed { get; set; }

		public readonly bool ShowMilliseconds;

		IControl IBuilder.Control
		{
			get
			{
				return Display;
			}
		}

		public ILabel Control
		{
			get 
			{
				return Display;
			}
		}

		public Chronometer()
		{
			ShowMilliseconds = false;
			Init();
		}

		public Chronometer(bool showMilliseconds)
		{
			ShowMilliseconds = showMilliseconds;
			Init();
		}

		protected void Init()
		{
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

		private void Timer_Elapsed(object sender, EventArgs e)
		{
			Elapsed = Elapsed.Add(Timer.Interval);

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