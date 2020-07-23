using System.Collections.Generic;

namespace OKHOSTING.UI.Controls.Maps
{
	public interface IMap: IControl
	{
		MapSpan VisibleRegion { get; set; }
		ICollection<Pin> Pins { get; }
	}
}