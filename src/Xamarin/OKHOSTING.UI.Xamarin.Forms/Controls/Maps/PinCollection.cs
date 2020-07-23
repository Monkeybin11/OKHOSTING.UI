using OKHOSTING.UI.Controls.Maps;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Xamarin.Forms.Controls.Maps
{
	public class PinCollection : Data.ListBase<Pin>, IList<Pin>
	{
		protected readonly Map Map;

		public PinCollection(Map map)
		{
			Map = map;
		}

		public override bool IsReadOnly => false;

		public override void Add(Pin item)
		{
			Map.Pins.Add(Map.Parse(item));
		}

		public override bool Contains(Pin item)
		{
			return Map.Pins.Contains(Map.Parse(item));
		}

		public override IEnumerator<Pin> GetEnumerator()
		{
			foreach (var pin in Map.Pins)
			{
				yield return Map.Parse(pin);
			}
		}

		public override bool Remove(Pin item)
		{
			return Map.Pins.Remove(Map.Parse(item));
		}
	}
}