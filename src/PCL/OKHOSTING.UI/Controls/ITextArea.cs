using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Controls
{
	/// <summary>
	/// A multiline textbox
	/// </summary>
	public interface ITextArea : IControl
	{ 
		string Text { get; set; }
	}
}