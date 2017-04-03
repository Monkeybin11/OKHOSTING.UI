using System.Collections.Generic;

namespace OKHOSTING.UI.Controls.Layout
{
	/// <summary>
	/// A flow layout puts all its children controls one right next to the other, in a sequential way,
	/// in the same order as they appear in the collection
	/// </summary>
	public interface IFlow : IControl
	{
		IList<IControl> Children { get; }
	}
}