using System;
using System.Collections.Generic;
using System.Text;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
    public class ArrobaMediaController : Controller
    {
        //In Variables
        ITextBox txtString;

        //Out Variables
        ITextBox txtLetters;
        ITextBox txtNumbers;
        ITextBox txtVowels;
        ITextBox txtUpperCase;
        ITextBox txtLowerCase;

        protected override void OnStart()
        {
            IGrid grid = Core.BaitAndSwitch.Create<IGrid>();
            grid.Name = "grid";
            grid.ColumnCount = 3;
            grid.RowCount = 15;

            //lblString
            ILabel lblString = Core.BaitAndSwitch.Create<ILabel>();
            lblString.Text = "String";
            lblString.Name = "lblString";
            grid.SetContent(0, 0, lblString);

            //txtString
            txtString = Core.BaitAndSwitch.Create<ITextBox>();
            txtString.Value = "";
            txtString.Name = "txtString";
            txtString.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(0, 1, txtString);

            //lblLetters
            ILabel lblLetters = Core.BaitAndSwitch.Create<ILabel>();
            lblLetters.Text = "Number of Letters";
            lblLetters.Name = "lblLetters";
            grid.SetContent(0, 2, lblLetters);

            //txtLetters
            txtLetters = Core.BaitAndSwitch.Create<ITextBox>();
            txtLetters.Enabled = false;
            txtLetters.Name = "txtLetters";
            txtLetters.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(1, 0, txtLetters);

            //lblNumbers
            ILabel lblNumbers = Core.BaitAndSwitch.Create<ILabel>();
            lblNumbers.Text = "Number of Numbers";
            lblNumbers.Name = "lblNumbers";
            grid.SetContent(1, 1, lblNumbers);

            //txtNumbers
            txtNumbers = Core.BaitAndSwitch.Create<ITextBox>();
            txtNumbers.Enabled = false;
            txtNumbers.Name = "txtNumbers";
            txtNumbers.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(1, 2, txtNumbers);

            //lblVowels
            ILabel lblVowels = Core.BaitAndSwitch.Create<ILabel>();
            lblVowels.Text = "Number of Vowels";
            lblVowels.Name = "lblVowels";
            grid.SetContent(2, 0, lblVowels);

            //txtVowels
            txtVowels = Core.BaitAndSwitch.Create<ITextBox>();
            txtVowels.Enabled = false;
            txtVowels.Name = "txtVowels";
            txtVowels.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(2, 1, txtVowels);

            //lblUpperCase
            ILabel lblUpperCase = Core.BaitAndSwitch.Create<ILabel>();
            lblUpperCase.Text = "Number of Upper Case";
            lblUpperCase.Name = "lblUpperCase";
            grid.SetContent(2, 2, lblUpperCase);

            //txtUpperCase
            txtUpperCase = Core.BaitAndSwitch.Create<ITextBox>();
            txtUpperCase.Enabled = false;
            txtUpperCase.Name = "txtUpperCase";
            txtUpperCase.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(3, 0, txtUpperCase);

            //lblLowerCase
            ILabel lblLowerCase = Core.BaitAndSwitch.Create<ILabel>();
            lblLowerCase.Text = "Number of Lower Case";
            lblLowerCase.Name = "lblLowerCase";
            grid.SetContent(3, 1, lblLowerCase);

            //txtLowerCase
            txtLowerCase = Core.BaitAndSwitch.Create<ITextBox>();
            txtLowerCase.Enabled = false;
            txtLowerCase.Name = "txtLowerCase";
            grid.SetContent(3, 2, txtLowerCase);

            //btnSearch
            IButton btnSearch = Core.BaitAndSwitch.Create<IButton>();
            btnSearch.Text = "Search";
            btnSearch.Name = "btnSearch";
            grid.SetContent(4, 0, btnSearch);

            //btnClean
            IButton btnClean = Core.BaitAndSwitch.Create<IButton>();
            btnClean.Text = "Clean";
            btnClean.Name = "btnClean";
            grid.SetContent(4, 1, btnClean);

            IButton btnExit = Core.BaitAndSwitch.Create<IButton>();
            btnExit.Text = "Exit";
            btnExit.Name = "btnExit";
            btnExit.Click += btnExit_Click;
            grid.SetContent(4, 2, btnExit);

            Page.Title = "@Media";
            Page.Content = grid;

            CSS.Style style = new CSS.Style();
            style.Parse(@"

                #grid
                    {
                        display: grid;
                        grid-template-areas: 
                        ""lblString txtString .""
                        ""lblLetters txtLetters .""
                        ""lblNumbers txtNumbers .""
                        ""lblVowels txtVowels .""
                        ""lblUpperCase txtUpperCase .""
                        ""lblLowerCase txtLowerCase .""
                        ""btnSearch btnClean btnExit""
                        "". . .""
                        "". . .""
                        "". . .""
                        "". . .""
                        "". . .""
                        "". . .""
                        "". . .""
                        "". . ."";
                    }

                    @media only screen and (max-width: 600px)
                    {
                        #grid
                        {
                            display: grid;
                            grid-template-areas: 
                            ""lblString . .""
                            ""txtString . .""
                            ""lblLetters . .""
                            ""txtLetters . .""
                            ""lblNumbers . .""
                            ""txtNumbers . .""
                            ""lblVowels . .""
                            ""txtVowels . .""
                            ""lblUpperCase . .""
                            ""txtUpperCase . .""
                            ""lblLowerCase . .""
                            ""txtLowerCase . .""
                            ""btnSearch . .""
                            ""btnClean . .""
                            ""btnExit . ."";
                        }
                    }

            
            ");
            style.Apply(Page);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

    }
}
