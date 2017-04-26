using MediaPlayer;
using System;
using System.Collections.Generic;
using System.Text;
using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Xamarin.iOS.Controls
{
	public class VideoPlayer : MPMoviePlayerController, UI.Controls.IVideoPlayer
	{
		public Color BorderColor
		{
			get;
			set;
		}

		public Thickness BorderWidth
		{
			get;
			set;
		}

		public bool Enabled
		{
			get;
			set;
		}

		public double? Height
		{
			get;
			set;
		}

		public HorizontalAlignment HorizontalAlignment
		{
			get
			{
			}
			set;
		}

		public Thickness Margin
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public Uri Source
		{
			get;
			set;
		}

		public object Tag
		{
			get;
			set;
		}

		public VerticalAlignment VerticalAlignment
		{
			get;
			set;
		}

		public bool Visible
		{
			get;
			set;
		}

		public double? Width
		{
			get;
			set;
		}

		Color IControl.BackgroundColor
		{
			get;
			set;
		}
	}
}