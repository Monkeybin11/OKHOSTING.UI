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
            Controller.CurrentPage = this;

			if (Controller.CurrentController == null)
			{
				new Test.LoginController().Start();
			}
			else
			{
				Controller.CurrentController.Start();
			}

			base.OnLoad(e);
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

			if (typeof(T) == typeof(IAutocomplete))
			{
				return new Autocomplete() as T;
			}

			if (typeof(T) == typeof(IListPicker))
			{
				return new ListPicker() as T;
			}

			if (typeof(T) == typeof(IHyperLink))
			{
				return new HyperLink() as T;
			}

			if (typeof(T) == typeof(ITextArea))
			{
				return new TextArea() as T;
			}

			if (typeof(T) == typeof(IBooleanPicker))
			{
				return new BooleanPicker() as T;
			}

			if (typeof(T) == typeof(IImage))
			{
				return new Image() as T;
			}

			if (typeof(T) == typeof(IPasswordTextBox))
			{
				return new PasswordTextBox() as T;
			}

			if (typeof(T) == typeof(IStack))
			{
				return new Stack() as T;
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
				if (phContent.Controls.Count == 0)
				{
					return null;
				}

				return (IControl) phContent.Controls[0];
			}
			set
			{
				phContent.Controls.Clear();

				if (value != null)
				{
					phContent.Controls.Add((System.Web.UI.Control) value);
				}
			}
		}

		public double Width
		{
			get
			{
				return (double) OKHOSTING.UI.Session.Current[typeof(Page) + ".Width"];
			}
		}

		public double Height
		{
			get
			{
				return (double) OKHOSTING.UI.Session.Current[typeof(Page) + ".Height"];
			}
		}
	}
}