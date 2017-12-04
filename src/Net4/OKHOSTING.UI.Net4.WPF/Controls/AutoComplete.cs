using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OKHOSTING.UI.Net4.WPF.Controls
{
    public class AutoComplete : WpfAutoCompleteControls.Editors.AutoCompleteTextBox
    {
        public event EventHandler<AutocompleteSearchEventArgs> Searching;

        public AutocompleteSearchEventArgs OnSearching(string text)
        {
            var e = new AutocompleteSearchEventArgs(text);

            Searching?.Invoke(this, e);

            return e;
        }

        //string ITextControl.FontFamily
        //{
        //    get
        //    {
        //        return base.FontFamily.FamilyNames.ToString();
        //    }
        //    set
        //    {
        //        base.FontFamily = new System.Drawing.Font(value, (float)base.FontSize);
        //    }
        //}

        //Color ITextControl.FontColor
        //{
        //    get; set;
        //}

        //bool ITextControl.Bold
        //{
        //    get
        //    {
        //        return base.Font.Bold;
        //    }
        //    set
        //    {
        //        base.Font = new System.Drawing.Font(Font.Name, base.Font.Size, value ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
        //    }
        //}
    }
}
