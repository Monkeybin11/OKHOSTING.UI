using System;
using System.Linq;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Net4.WebForms.Controls;
using System.Collections.Generic;

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

			if (!IsPostBack)
			{
				return;
			}

			//restore state and launch events
			
			//get last set of controls from session
			Content = (IControl)Session["Content"];

			//keep track of wich IInputControls had ther value updated so we can reaise IInputControl.OnValueChanged
			List<IControl> updatedInputControls = new List<IControl>();

			//restore state
			foreach (string postedValueName in Request.Form.AllKeys.Where(k => !k.StartsWith("__")))
			{
				//get posted value by user
				string postedValue = Request.Form[postedValueName];

				//get control that corresponds to this input
				IControl control = (IControl) ContentHolder.FindControl(postedValueName);

				//update control's value
				if (control is Autocomplete)
				{
					if (((IAutocomplete) control).Value != postedValue)
					{
						updatedInputControls.Add(control);
					}

					((IAutocomplete) control).Value = postedValue;
				}
				else if (control is Calendar)
				{
					if (((ICalendar) control).Value != DateTime.Parse(postedValue))
					{
						updatedInputControls.Add(control);
					}

					((ICalendar) control).Value = DateTime.Parse(postedValue);
				}
				else if (control is CheckBox)
				{
					if (((ICheckBox)control).Value != (postedValue == "checked"))
					{
						updatedInputControls.Add(control);
					}

					((ICheckBox) control).Value = postedValue == "checked";
				}
				else if (control is ListPicker)
				{
					if (((IListPicker) control).Value != postedValue)
					{
						updatedInputControls.Add(control);
					}

					((IListPicker) control).Value = postedValue;
				}
				else if (control is PasswordTextBox)
				{
					if (((IPasswordTextBox) control).Value != postedValue)
					{
						updatedInputControls.Add(control);
					}

					((IPasswordTextBox) control).Value = postedValue;
				}
				else if (control is TextArea)
				{
					if (((ITextArea) control).Value != postedValue)
					{
						updatedInputControls.Add(control);
					}

					((ITextArea) control).Value = postedValue;
				}
				else if (control is TextBox)
				{
					if (((ITextBox) control).Value != postedValue)
					{
						updatedInputControls.Add(control);
					}

					((ITextBox) control).Value = postedValue;
				}
			}

			//raise events

			string eventTarget = Request.Form["__EVENTTARGET"];
			string eventArgument = Request.Form["__EVENTARGUMENT"];

			//raise IInputControl.OnValueChanged events
			foreach (IControl control in updatedInputControls)
			{
				if (control is Autocomplete)
				{
					((Autocomplete) control).RaiseValueChanged();
				}
				else if (control is Calendar)
				{
					((Calendar) control).RaiseValueChanged();
				}
				else if (control is CheckBox)
				{
					((CheckBox) control).RaiseValueChanged();
				}
				else if (control is ListPicker)
				{
					((ListPicker) control).RaiseValueChanged();
				}
				else if (control is PasswordTextBox)
				{
					((PasswordTextBox) control).RaiseValueChanged();
				}
				else if (control is TextArea)
				{
					((TextArea) control).RaiseValueChanged();
				}
				else if (control is TextBox)
				{
					((TextBox) control).RaiseValueChanged();
				}
			}

			foreach (string postedValueName in Request.Form.AllKeys.Where(k => !k.StartsWith("__")))
			{
				//get posted value by user
				string postedValue = Request.Form[postedValueName];

				//get control that corresponds to this input
				IControl control = (IControl) ContentHolder.FindControl(postedValueName);

				if (control is Button && postedValue == postedValueName)
				{
					((Button) control).Raise_Click();
				}
				else if (control is LabelButton && eventTarget == control.Name)
				{
					((LabelButton) control).Raise_Click();
				}
				else if (control is IImageButton && eventTarget == control.Name)
				{
					((ImageButton) control).Raise_Click();
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