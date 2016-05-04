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

		/// <summary>
		/// Restores Page state (content & title) and launch events
		/// </summary>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			//assign as current page
			Platform.Current.Page = this;

			//load javascript dependencies
			Page.ClientScript.RegisterClientScriptInclude("jquery", ResolveUrl("~/js/jquery.js"));
			Page.ClientScript.RegisterClientScriptInclude("jquery-ui", ResolveUrl("~/js/jquery-ui.js"));
			Page.ClientScript.RegisterClientScriptInclude("PageSize", ResolveUrl("~/js/PageSize.js"));

			//if this is the first request, get page size
			if (!IsPostBack && Width == 0 && Height == 0)
			{
				string pageSizeJS = @"
				<script type='text/javascript'>
					$(document).ready
					(
						function()
						{
							SetPageSize();
						}
					);
				</script>";

				//register javascripts
				Page.ClientScript.RegisterStartupScript(this.GetType(), "SetPageSize", pageSizeJS);

				return;
			}

			//create placeholder for content
			if (ContentHolder == null)
			{
				ContentHolder = new System.Web.UI.WebControls.PlaceHolder();
				ContentHolder.ID = "phContent";
				base.Form.Controls.Clear();
				base.Form.Controls.Add(ContentHolder);
			}

			//there is no controller assigned, exit
			if (Platform.Current.Controller == null)
			{
				return;
			}

			//get title and content from the state, in case it has a different Page instance
			if (Platform.Current.PageState != null)
			{
				Title = Platform.Current.PageState.Title;
				Content = Platform.Current.PageState.Content;
			}

			//if there is no postback, exit now and skip recovering state and launching events
			if (!IsPostBack)
			{
				return;
			}

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
				if (control is Autocomplete && ((IAutocomplete)control).Value != postedValue)
				{
					updatedInputControls.Add(control);
					((IAutocomplete) control).Value = postedValue;
				}
				else if (control is Calendar && ((ICalendar) control).Value != DateTime.Parse(postedValue))
				{
					updatedInputControls.Add(control);
					((ICalendar) control).Value = DateTime.Parse(postedValue);
				}
				else if (control is ListPicker && ((IListPicker) control).Value != postedValue)
				{
					updatedInputControls.Add(control);
					((IListPicker) control).Value = postedValue;
				}
				else if (control is PasswordTextBox && ((IPasswordTextBox) control).Value != postedValue)
				{
					updatedInputControls.Add(control);
					((IPasswordTextBox) control).Value = postedValue;
				}
				else if (control is TextArea && ((ITextArea) control).Value != postedValue)
				{
					updatedInputControls.Add(control);
					((ITextArea) control).Value = postedValue;
				}
				else if (control is TextBox && ((ITextBox) control).Value != postedValue)
				{ 
					updatedInputControls.Add(control);
					((ITextBox) control).Value = postedValue;
				}
			}

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

			//raise button click events
			foreach (string postedValueName in Request.Form.AllKeys.Where(k => !k.StartsWith("__")))
			{
				//get posted value by user
				string postedValue = Request.Form[postedValueName];

				//get control that corresponds to this input
				IControl control = (IControl) ContentHolder.FindControl(postedValueName);

				if (control is Button && postedValue == ((Button) control).Text)
				{
					((Button) control).Raise_Click();
				}
			}

			//raise labelbutton, checkbox & image click events

			string eventTarget = Request.Form["__EVENTTARGET"];
			string eventArgument = Request.Form["__EVENTARGUMENT"];

			//get control that corresponds to this input
			if (!string.IsNullOrWhiteSpace(eventTarget))
			{
				IControl control = (IControl) ContentHolder.FindControl(eventTarget);

				if (control is LabelButton)
				{
					((LabelButton) control).Raise_Click();
				}
				else if (control is IImageButton)
				{
					((ImageButton) control).Raise_Click();
				}
				else if (control is ICheckBox)
				{
					((ICheckBox) control).Value = !((ICheckBox) control).Value;
					((CheckBox) control).RaiseValueChanged();
				}
			}
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
				if (!OKHOSTING.UI.Session.Current.ContainsKey(typeof(Page) + ".Width"))
				{
					OKHOSTING.UI.Session.Current[typeof(Page) + ".Width"] = (double) 0;
				}

				return (double) OKHOSTING.UI.Session.Current[typeof(Page) + ".Width"];
			}
		}

		public double Height
		{
			get
			{
				if (!OKHOSTING.UI.Session.Current.ContainsKey(typeof(Page) + ".Height"))
				{
					OKHOSTING.UI.Session.Current[typeof(Page) + ".Height"] = (double) 0;
				}

				return (double) OKHOSTING.UI.Session.Current[typeof(Page) + ".Height"];
			}
		}

		protected override void OnPreRender(EventArgs e)
		{
			//save page state
			if (Platform.Current.PageState != null)
			{
				Platform.Current.PageState.Title = Title;
				Platform.Current.PageState.Content = Content;
			}

			base.OnPreRender(e);
		}
	}
}