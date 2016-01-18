using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using CKEditor.NET;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A field for Html values
	/// </summary>
	[Serializable]
	public class HtmlField : FormField
	{
		/// <summary>
		/// Creates a new instance
		/// </summary>
		public HtmlField()
		{
			ValueType = typeof(string);
			this.TableWide = true;
		}

		///// <summary>
		///// Control that parses the value to web
		///// </summary>
		//protected new FCKeditor ValueControl
		//{
		//    get
		//    {
		//        return (FCKeditor) base.ValueControl;
		//    }
		//    set
		//    {
		//        base.ValueControl = value;
		//    }
		//}

		/// <summary>
		/// Control that parses the value to web
		/// </summary>
		protected new CKEditorControl ValueControl
		{
			get
			{
				return (CKEditorControl)base.ValueControl;
			}
			set
			{
				base.ValueControl = value;
			}
		}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		//protected override void CreateValueControls()
		//{
		//    string appVirtualPath = System.Web.HttpRuntime.AppDomainAppVirtualPath;
		//    if (!appVirtualPath.EndsWith("/")) appVirtualPath += "/";

		//    //html ajax editor
		//    ValueControl = new FCKeditor();
		//    ValueControl.BasePath = appVirtualPath + "UserControls/FCKEditor/";

		//    //if required and  control is a textbox, add validator
		//    if (Required)
		//    {
		//        RequiredFieldValidator validator;

		//        validator = new RequiredFieldValidator();
		//        validator.ControlToValidate = ValueControlId;
		//        validator.ErrorMessage = OKHOSTING.Softosis.Core.Globalization.Translator.Current["Validation.Required field"];
		//        validator.Text = "*";

		//        AditionalControls.Add(validator);
		//    }
		//}

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			string appVirtualPath = System.Web.HttpRuntime.AppDomainAppVirtualPath;
			if (!appVirtualPath.EndsWith("/")) appVirtualPath += "/";

			//html ajax editor
			ValueControl = new CKEditorControl();
			ValueControl.BasePath = appVirtualPath + "UserControls/CKEditor/";
			
			//configure file bbrowser
			CKFinder.FileBrowser browser = new CKFinder.FileBrowser();
			browser.BasePath = appVirtualPath + "UserControls/CKFinder/";
			browser.SetupCKEditor(ValueControl);

			//if required and  control is a textbox, add validator
			if (Required)
			{
				RequiredFieldValidator validator;

				validator = new RequiredFieldValidator();
				validator.ControlToValidate = ValueControlId;
				validator.ErrorMessage = OKHOSTING.Softosis.Core.Globalization.Translator.Current["Validation.Required field"];
				validator.Text = "*";

				AditionalControls.Add(validator);
			}
		}

		/// <summary>
		/// Retrieves values selected by the user and set's the value to the ValueControl
		/// </summary>
		internal override void RetrieveUserInput()
		{
			ValueControl.Text = ValueControlPostValue;
		}
	
		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public HtmlField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt) : base(info, ctxt)
		{
		}

		/// <summary>
		/// Assings the Value to the valuecontrol input
		/// </summary>
		internal override void ValueToControl()
		{
			ValueControl.Text = (string) Value;
		}

		/// <summary>
		/// Retrieves the user input from the value control and assigns it to Value
		/// </summary>
		internal override void ControlToValue()
		{
			Value = System.Web.HttpContext.Current.Server.HtmlDecode(ValueControl.Text);
		}
	}
}