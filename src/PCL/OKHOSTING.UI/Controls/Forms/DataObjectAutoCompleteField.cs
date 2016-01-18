using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// An ajax autocomplete for searching DataObjects
	/// </summary>
	[Serializable]
	public class DataObjectAutoCompleteField : TextBoxField
	{
		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			//create TextBox from base
			base.CreateValueControl();

			//ajax autocompleter
			AjaxControlToolkit.AutoCompleteExtender autoComplete = new AjaxControlToolkit.AutoCompleteExtender();
			autoComplete.ID = ValueControlId + "_AutoCompleteExtender";
			autoComplete.UseContextKey = true;
			autoComplete.ContextKey = ((DataType)ValueType).UniqueId;
			autoComplete.TargetControlID = ValueControlId;
			autoComplete.ServiceMethod = "SearchDataObjects";
			autoComplete.ServicePath = "/Services/DataObjectAutoCompleteService.asmx";
			autoComplete.CompletionListCssClass = "AutoComplete_List";
			autoComplete.CompletionListItemCssClass = "AutoComplete_ListItem";
			autoComplete.EnableCaching = false;
			AditionalControls.Add(autoComplete);

			//ajax watermark
			AjaxControlToolkit.TextBoxWatermarkExtender watermark = new AjaxControlToolkit.TextBoxWatermarkExtender();
			watermark.WatermarkText = OKHOSTING.Softosis.Core.Globalization.Translator.Current["OKHOSTING.UI.Controls.Forms.DataObjectAutoCompleteField.Write here to search"];
			watermark.ID = ValueControlId + "_TextBoxWatermarkExtender";
			watermark.TargetControlID = ValueControlId;
			watermark.WatermarkCssClass = "AutoComplete_Watermark";
			AditionalControls.Add(watermark);

			//"Show All" button
			/*
			System.Web.UI.HtmlControls.HtmlAnchor showAll = new System.Web.UI.HtmlControls.HtmlAnchor();
			showAll.InnerText = "+";
			showAll.Style.Add("cursor", "pointer");
			showAll.Title = OKHOSTING.Softosis.Core.Globalization.LocalizedDictionary.Current["OKHOSTING.UI.Controls.Forms.DataObjectAutoCompleteField.Show all"];
			showAll.PreRender += new EventHandler(showAll_PreRender);
			AditionalControls.Add(showAll);
			*/
		}

		/*
		/// <summary>
		/// Links the Show All link to the correct ValueControl client id
		/// </summary>
		void showAll_PreRender(object sender, EventArgs e)
		{
			System.Web.UI.HtmlControls.HtmlAnchor showAll = (System.Web.UI.HtmlControls.HtmlAnchor)sender;
			showAll.Attributes.Add("onclick", "document.getElementById('" + ValueControl.ClientID + "').value='" + DataObjectAutoCompleteWebService.ShowAllText + "'; document.getElementById('" + ValueControl.ClientID + "').blur(); ");
		}
		*/

		/// <summary>
		/// Creates a new instance
		/// </summary>
		public DataObjectAutoCompleteField()
		{
		}

		/// <summary>
		/// Creates a new instance based on serialization info
		/// </summary>
		public DataObjectAutoCompleteField(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext ctxt)
			: base(info, ctxt)
		{
		}

		/// <summary>
		/// Assings the Value to the valuecontrol input
		/// </summary>
		internal override void ValueToControl()
		{
			if (!NullValues.IsNull(Value))
			{
				DataObject selected;
				
				selected = (DataObject)Value;
				if (!selected.IsSaved) selected.Select();
				
				ValueControl.Text = selected.ToString() + " (" + TypeConverter.ToString(selected.PrimaryKey) + ")";
			}
			else
			{
				ValueControl.Text = null;
			}
		}

		/// <summary>
		/// Retrieves the user input from the value control and assigns it to Value
		/// </summary>
		internal override void ControlToValue()
		{
			//set value to null by default
			Value = null;

			//null values
			if (string.IsNullOrWhiteSpace(ValueControl.Text))
			{
				return;
			}

			//search primary KeyNotFoundException string at the end of the Text, betewwn parenthesis
			//example: My Company Inc. (id=34)
			try
			{
				string pkString = ValueControl.Text.Substring(ValueControl.Text.IndexOf('(') + 1);
				pkString = pkString.TrimEnd(')');
				pkString = pkString.Trim();

				DataObject dobj = DataObject.From(this.ValueType);
				TypeConverter.ToDataValueInstances(pkString, dobj.PrimaryKey);

				Value = dobj;
			}
			catch { }

			//if last attempt was succesfull, load selected from database and exit
			if (!NullValues.IsNull(Value))
			{
				//if select operation returns null, set value to null again
				if (DataBase.Current.Select((DataObject)Value) == null)
				{
					Value = null;
				}

				//otherwise value is already selected and loaded, so exit
				else
				{
					return;
				}
			}

			//otherwise search in the database for a match
			DataObjectCollection found = DataBase.Current.Search(ValueType, ValueControl.Text);

			//if found a match, get the first result, otherwise, set Value to null
			if (found.Count > 0)
			{
				Value = found[0];
			}
			else
			{
				Value = null;
			}
		}
	}
}