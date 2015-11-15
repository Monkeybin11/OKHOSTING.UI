using OKHOSTING.UI.Controls;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class TextArea : System.Web.UI.WebControls.TextBox, ITextArea
	{
		public TextArea()
		{
			base.TextMode = System.Web.UI.WebControls.TextBoxMode.MultiLine;
		}

		public string Name
		{
			get
			{
				return base.ID;
			}
			set
			{
				base.ID = value;
			}
		}

		IPage IControl.Page
		{
			get
			{
				return (Page) Page;
			}
		}
	}
}