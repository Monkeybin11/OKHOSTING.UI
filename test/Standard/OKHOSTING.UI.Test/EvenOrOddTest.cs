using AngleSharp.Dom;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Test
{
    class EvenOrOddTest : Controller
    {
        ITextBox txtNumbers;
        ITextBox txtResult;

        ICheckBox chbxEven;
        ICheckBox chbxOdd;
        ICheckBox chbxPerfect;

        IButton btnCheck;
        IButton btnClean;
        IButton btnExit;

        ILabel lblNumbers;
        ILabel lblCheck;
        ILabel lblRessult;
        ILabel lblEven;
        ILabel lblOdd;
        ILabel lblPerfect;
       
            
        /// <summary>
        /// Start this instance.
        /// <para xml:lang="es">
        /// Inicia una instancia de este objeto.
        /// </para>
        /// </summary>
        /// 
        protected override void OnStart()
        {
            IGrid grid = Core.BaitAndSwitch.Create<IGrid>();

            grid.ColumnCount = 3;
            grid.RowCount = 6;

            lblNumbers = Core.BaitAndSwitch.Create<ILabel>();
            lblNumbers.Text = "Number;";
            grid.SetContent(0, 0, lblNumbers);

            txtNumbers = Core.BaitAndSwitch.Create<ITextBox>();
            txtNumbers.Value = "";
            grid.SetContent(0, 1, txtNumbers);

            lblCheck = Core.BaitAndSwitch.Create<ILabel>();
            lblCheck.Text = "Check";
            grid.SetContent(1, 0, lblCheck);

            lblEven = Core.BaitAndSwitch.Create<ILabel>();
            lblEven.Text = "Is a Even";
            grid.SetContent(2, 0, lblEven);

            chbxEven = Core.BaitAndSwitch.Create<ICheckBox>();

            Page.Content = grid;
        }
    }
}
