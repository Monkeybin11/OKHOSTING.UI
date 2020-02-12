using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Test
{
	public class CssGrid : Controller
	{
			/// <summary>
			/// Start this instance.
			/// <para xml:lang="es">.
			/// Inicia la instancia de este objeto.
			/// </para>
			/// </summary>
			protected override void OnStart()
			{
            IStack stackPpal = Core.BaitAndSwitch.Create<IStack>();

            IButton btnexit = Core.BaitAndSwitch.Create<IButton>();
            btnexit.Text = "Exit";
            btnexit.Click += btnSalir_Click;
            stackPpal.Children.Add(btnexit);

            //Grid One for grid-column-gap*****************************
            ILabel lblGridColumnGap = Core.BaitAndSwitch.Create<ILabel>();
            lblGridColumnGap.Text = "Grid One for grid-column-gap *****************************";
            lblGridColumnGap.Name = "lblGridColumnGap";
            stackPpal.Children.Add(lblGridColumnGap);

            IGrid gridColumnGap = Core.BaitAndSwitch.Create<IGrid>();
            gridColumnGap.Name = "gridColumnGap";
            gridColumnGap.ColumnCount = 3;
            gridColumnGap.RowCount = 6;
            //gridColumnGap.CellMargin = new Thickness(0, 0, 100, 0);
            stackPpal.Children.Add(gridColumnGap);

            ITextBox txtdate1 = Core.BaitAndSwitch.Create<ITextBox>();
            txtdate1.Value = "";
            //txtdate1.Margin = new Thickness(0, 0, 100, 0);
            txtdate1.Name = "txtdate1";
            gridColumnGap.SetContent(1, 0, txtdate1);

            ITextBox txtdate2 = Core.BaitAndSwitch.Create<ITextBox>();
            txtdate2.Value = "";
            txtdate2.Name = "txtdate2";
            gridColumnGap.SetContent(3, 0, txtdate2);

            ILabel lbdatebirth = Core.BaitAndSwitch.Create<ILabel>();
            lbdatebirth.Text = "year of birth";
            lbdatebirth.Name = "lbdatebirth";
            gridColumnGap.SetContent(0, 0, lbdatebirth);

            ILabel lbcurrentdate = Core.BaitAndSwitch.Create<ILabel>();
            lbcurrentdate.Text = "current year";
            lbcurrentdate.Name = "lbcurrentdate";
            gridColumnGap.SetContent(2, 0, lbcurrentdate);

            ILabel lboutcome = Core.BaitAndSwitch.Create<ILabel>();
            lboutcome.Text = "";
            lboutcome.Name = "lboutcome";
            gridColumnGap.SetContent(4, 0, lboutcome);

            IButton btnCalculate = Core.BaitAndSwitch.Create<IButton>();
            btnCalculate.Text = "Calculate";
            btnCalculate.Name = "btnCalculate";
            gridColumnGap.SetContent(0, 2, btnCalculate);

            //Grid One for grid-row-gap*****************************
            ILabel lblGridRowGap = Core.BaitAndSwitch.Create<ILabel>();
            lblGridRowGap.Text = "Grid One for grid-row-gap *****************************";
            lblGridRowGap.Name = "lblGridRowGap";
            stackPpal.Children.Add(lblGridRowGap);

            IGrid gridRowGap = Core.BaitAndSwitch.Create<IGrid>();
            gridRowGap.ColumnCount = 3;
            gridRowGap.RowCount = 8;
            stackPpal.Children.Add(gridRowGap);

            //lblString
            ILabel lblString = Core.BaitAndSwitch.Create<ILabel>();
            lblString.Text = "String";
            gridRowGap.SetContent(0, 0, lblString);

            //txtString
            ITextBox txtString = Core.BaitAndSwitch.Create<ITextBox>();
            txtString.Value = "";
            txtString.BorderWidth = new Thickness(1, 2, 3, 4);
            gridRowGap.SetContent(0, 1, txtString);

            //lblLetters
            ILabel lblLetters = Core.BaitAndSwitch.Create<ILabel>();
            lblLetters.Text = "Number of Letters";
            gridRowGap.SetContent(1, 0, lblLetters);

            //txtLetters
            ITextBox txtLetters = Core.BaitAndSwitch.Create<ITextBox>();
            txtLetters.Enabled = false;
            txtLetters.BorderWidth = new Thickness(1, 2, 3, 4);
            gridRowGap.SetContent(1, 1, txtLetters);

            //lblNumbers
            ILabel lblNumbers = Core.BaitAndSwitch.Create<ILabel>();
            lblNumbers.Text = "Number of Numbers";
            gridRowGap.SetContent(2, 0, lblNumbers);

            //txtNumbers
            ITextBox txtNumbers = Core.BaitAndSwitch.Create<ITextBox>();
            txtNumbers.Enabled = false;
            txtNumbers.BorderWidth = new Thickness(1, 2, 3, 4);
            gridRowGap.SetContent(2, 1, txtNumbers);

            //lblVowels
            ILabel lblVowels = Core.BaitAndSwitch.Create<ILabel>();
            lblVowels.Text = "Number of Vowels";
            gridRowGap.SetContent(3, 0, lblVowels);

            //txtVowels
            ITextBox txtVowels = Core.BaitAndSwitch.Create<ITextBox>();
            txtVowels.Enabled = false;
            txtVowels.BorderWidth = new Thickness(1, 2, 3, 4);
            gridRowGap.SetContent(3, 1, txtVowels);

            //lblUpperCase
            ILabel lblUpperCase = Core.BaitAndSwitch.Create<ILabel>();
            lblUpperCase.Text = "Number of Upper Case";
            gridRowGap.SetContent(4, 0, lblUpperCase);

            //txtUpperCase
            ITextBox txtUpperCase = Core.BaitAndSwitch.Create<ITextBox>();
            txtUpperCase.Enabled = false;
            txtUpperCase.BorderWidth = new Thickness(1, 2, 3, 4);
            gridRowGap.SetContent(4, 1, txtUpperCase);

            //lblLowerCase
            ILabel lblLowerCase = Core.BaitAndSwitch.Create<ILabel>();
            lblLowerCase.Text = "Number of Lower Case";
            gridRowGap.SetContent(5, 0, lblLowerCase);

            //txtLowerCase
            ITextBox txtLowerCase = Core.BaitAndSwitch.Create<ITextBox>();
            txtLowerCase.Enabled = false;
            gridRowGap.SetContent(5, 1, txtLowerCase);

            //btnSearch
            IButton btnSearch = Core.BaitAndSwitch.Create<IButton>();
            btnSearch.Text = "Search";
            gridRowGap.SetContent(7, 0, btnSearch);

            //btnClean
            IButton btnClean = Core.BaitAndSwitch.Create<IButton>();
            btnClean.Text = "Clean";
            gridRowGap.SetContent(7, 1, btnClean);

            //btnClose
            IButton btnClose = Core.BaitAndSwitch.Create<IButton>();
            btnClose.Text = "Close";
            gridRowGap.SetContent(7, 2, btnClose);

            Page.Content = stackPpal;

            CSS.Style style = new CSS.Style();
            style.Parse(@"

                #lblGridRowGap
                {
                    color: red;
                }

                #lblGridColumnGap
                {
                    color: red;
                }

                #gridColumnGap
                {
                    display: grid;
                    grid-column-gap: 25px;
                    grid-row-gap: 70px;
                    grid-template-areas:
                    ""txtdate1 txtdate2 lbdatebirth""
                    ""lbcurrentdate lboutcome btnCalculate""
                    "". . .""
                    "". . .""
                    "". . .""
                    "". . ."";
               }"
                 );
            style.Apply(Page);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

    }
}