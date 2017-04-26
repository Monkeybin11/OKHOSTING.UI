using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Controls
{
	public interface IVideoPlayer: IControl
	{
		void Play();
		void Pause();
		void Stop();

		Uri Source
		{
			get;
			set;
		}
	}
}