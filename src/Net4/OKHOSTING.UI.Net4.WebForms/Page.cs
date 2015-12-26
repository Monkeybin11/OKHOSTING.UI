using System;
using System.Linq;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Net4.WebForms.Controls;

namespace OKHOSTING.UI.Net4.WebForms
{
	public partial class Page : System.Web.UI.Page, IPage
	{
		protected System.Web.UI.WebControls.PlaceHolder ContentHolder;

		protected override void OnInit(EventArgs e)
		{
			if (ContentHolder == null)
			{
				ContentHolder = new System.Web.UI.WebControls.PlaceHolder();
				ContentHolder.ID = "pcContent";
				base.Form.Controls.Clear();
				base.Form.Controls.Add(ContentHolder);
			}

			//restore state and launch events
			if (IsPostBack)
			{
				//get last set of controls from session
				Content = (IControl) Session["Content"];

				string eventTarget = Request.Form["__EVENTTARGET"];
				string eventArgument = Request.Form["__EVENTARGUMENT"];

				foreach (string postedValueName in Request.Form.AllKeys.Where(k => !k.StartsWith("__")))
				{
					string postedValue = Request.Form[postedValueName];

					IControl control = (IControl) ContentHolder.FindControl(postedValueName);

					//get posted values and update controls

					if (control is TextBox)
					{
						((TextBox) control).Text = postedValue;
					}

					if (control is ListPicker)
					{
						((ListPicker) control).SelectedValue = postedValue;
					}

					if (control is CheckBox)
					{
						((CheckBox) control).Checked = postedValue == "checked";
					}

					if (control is TextArea)
					{
						((TextArea)control).Text = postedValue;
					}

					if (control is PasswordTextBox)
					{
						((PasswordTextBox)control).Text = postedValue;
					}

					if (control is Autocomplete)
					{
						((IAutocomplete) control).Text = postedValue;
					}

					//LabelButton was clicked
					if (control is LabelButton && eventTarget == control.Name)
					{
						((LabelButton) control).Raise_Click();
					}

					//Button was clicked
					if (control is Button && postedValue == postedValueName)
					{
						((Button) control).Raise_Click();
					}

					//handle other events like ILabelButton.Click  or IListPicker.SelectedValueChanged
					if (!string.IsNullOrWhiteSpace(eventTarget))
					{
						if (postedValueName == eventTarget)
						{
						}
					}
				}
			}

			base.OnInit(e);
		}

		public IControl Content
		{
			get
			{
				if (ContentHolder.Controls.Count == 0)
				{
					return null;
				}

				return (IControl) ContentHolder.Controls[0];
			}
			set
			{
				ContentHolder.Controls.Clear();

				if (value != null)
				{
					ContentHolder.Controls.Add((System.Web.UI.Control) value);
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

		protected override void OnPreRenderComplete(EventArgs e)
		{
			base.OnPreRenderComplete(e);

			//save state
			Session["Content"] = Content;
		}
	}
}