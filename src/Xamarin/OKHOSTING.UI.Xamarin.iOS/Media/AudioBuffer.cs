using AudioToolbox;
using System;
using System.Collections.Generic;

namespace OKHOSTING.UI.Xamarin.iOS.Media
{
	/// <summary>
	/// A Class to hold the AudioBuffer with all setting together
	/// </summary>
	internal class AudioBuffer
	{
		public IntPtr Buffer { get; set; }

		public List<AudioStreamPacketDescription> PacketDescriptions { get; set; }

		public int CurrentOffset { get; set; }

		public bool IsInUse { get; set; }
	}
}