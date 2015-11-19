using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layouts;
using OKHOSTING.UI.Net4.WebForms.Controls;
using OKHOSTING.UI.Net4.WebForms.Controls.Layouts;

namespace OKHOSTING.UI.Net4.WebForms
{
	public partial class Page : System.Web.UI.Page, IPage
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Controller.CurrentPage = this;
			Controller.CurrentController.Start();
		}

		public T Create<T>() where T : class, IControl
		{
			if (typeof(T) == typeof(IButton))
			{
				return new Button() as T;
			}

			if (typeof(T) == typeof(ILabel))
			{
				return new Label() as T;
			}

			if (typeof(T) == typeof(ITextBox))
			{
				return new TextBox() as T;
			}

			if (typeof(T) == typeof(IPasswordTextBox))
			{
				return new PasswordTextBox() as T;
			}

			if (typeof(T) == typeof(IGrid))
			{
				return new Grid() as T;
			}

			throw new NotSupportedException();
		}

		public IControl Content
		{
			get
			{
				if (base.Form.Controls.Count == 0)
				{
					return null;
				}

				return (IControl) base.Form.Controls[0];
			}
			set
			{
				Form.Controls.Clear();

				if (value != null)
				{
					Form.Controls.Add((System.Web.UI.Control) value);
				}
			}
		}
	}
}