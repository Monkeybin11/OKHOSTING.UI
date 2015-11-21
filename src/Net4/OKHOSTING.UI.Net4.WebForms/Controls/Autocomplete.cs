using OKHOSTING.UI.Controls;
using System;

namespace OKHOSTING.UI.Net4.WebForms.Controls
{
	public class Autocomplete : System.Web.UI.WebControls.Panel, IAutocomplete
	{
		protected readonly System.Web.UI.WebControls.TextBox InnerTextBox;
		protected readonly AjaxControlToolkit.AutoCompleteExtender InnerAutoCompleteExtender;
		protected readonly AjaxControlToolkit.TextBoxWatermarkExtender InnerWatermarkExtender;

		public Autocomplete()
		{
			//set a default id so we ensure the extender's TargetControlID is set
			InnerTextBox = new System.Web.UI.WebControls.TextBox();
			InnerTextBox.ID = "Autocomplete_InnerTextBox_" + new Random().Next();
			base.Controls.Add(InnerTextBox);

			//ajax autocompleter
			InnerAutoCompleteExtender = new AjaxControlToolkit.AutoCompleteExtender();
			InnerAutoCompleteExtender.ID = base.UniqueID + "_AutoCompleteExtender";
			InnerAutoCompleteExtender.TargetControlID = InnerTextBox.ID;
			InnerAutoCompleteExtender.UseContextKey = true;
			InnerAutoCompleteExtender.ServiceMethod = "Search";
			InnerAutoCompleteExtender.ServicePath = "/Services/AutoCompleteService.asmx";
			//InnerAutoCompleteExtender.CompletionListCssClass = "AutoComplete_List";
			//InnerAutoCompleteExtender.CompletionListItemCssClass = "AutoComplete_ListItem";
			InnerAutoCompleteExtender.EnableCaching = false;
			base.Controls.Add(InnerAutoCompleteExtender);

			//ajax watermark
			InnerWatermarkExtender = new AjaxControlToolkit.TextBoxWatermarkExtender();
			InnerWatermarkExtender.WatermarkText = "Search";
			InnerWatermarkExtender.ID = base.UniqueID + "_TextBoxWatermarkExtender";
			InnerWatermarkExtender.TargetControlID = InnerTextBox.ID;
			//InnerWatermarkExtender.WatermarkCssClass = "AutoComplete_Watermark";
			base.Controls.Add(InnerWatermarkExtender);

			Name = "Autocomplete_" + new Random().Next();
			InnerAutoCompleteExtender.ContextKey = Name;
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

		public string Text
		{
			get
			{
				return InnerTextBox.Text;
			}
			set
			{
				InnerTextBox.Text = value;
			}
		}

		public event EventHandler<AutocompleteSearchEventArgs> Searching;

		public AutocompleteSearchEventArgs OnSearching(string text)
		{
			AutocompleteSearchEventArgs e = new AutocompleteSearchEventArgs(text);

			if (Searching != null)
			{
				Searching(this, e);
			}

			return e;
        }
	}
}