using System;
using System.Collections.Generic;
using System.Text;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
    public class ArrobaMediaController : Controller
    {
       
        protected override void OnStart()
        {
            Refresh();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

        public override void Refresh()
        {
            base.Refresh();

            IGrid grid = Core.BaitAndSwitch.Create<IGrid>();

            //buttons
            IButton btnSearch = Core.BaitAndSwitch.Create<IButton>();
            IButton btnClean = Core.BaitAndSwitch.Create<IButton>();
            IButton btnExit = Core.BaitAndSwitch.Create<IButton>();

            //Static variables
            ILabel lblString = Core.BaitAndSwitch.Create<ILabel>();
            ILabel lblLetters = Core.BaitAndSwitch.Create<ILabel>();
            ILabel lblNumbers = Core.BaitAndSwitch.Create<ILabel>();
            ILabel lblVowels = Core.BaitAndSwitch.Create<ILabel>();
            ILabel lblUpperCase = Core.BaitAndSwitch.Create<ILabel>();
            ILabel lblLowerCase = Core.BaitAndSwitch.Create<ILabel>();
            ILabel lblwhitpage = Core.BaitAndSwitch.Create<ILabel>();

            //In Variables
            ITextBox txtString = Core.BaitAndSwitch.Create<ITextBox>();

            //Out Variables
            ITextBox txtLetters = Core.BaitAndSwitch.Create<ITextBox>();
            ITextBox txtNumbers = Core.BaitAndSwitch.Create<ITextBox>();
            ITextBox txtVowels = Core.BaitAndSwitch.Create<ITextBox>();
            ITextBox txtUpperCase = Core.BaitAndSwitch.Create<ITextBox>();
            ITextBox txtLowerCase = Core.BaitAndSwitch.Create<ITextBox>();


            grid.Name = "grid";
            grid.ColumnCount = 4;
            grid.RowCount = 15;


            //whit page
            lblwhitpage.Text = "************************* Whith";
            lblwhitpage.Name = "Ancho de pagina";
            grid.SetContent(0, 0, lblwhitpage);

            //lblString
            lblString.Text = "String";
            lblString.Name = "lblString";
            grid.SetContent(0, 1, lblString);

            //txtString
            txtString.Value = "";
            txtString.Name = "txtString";
            txtString.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(0, 2, txtString);

            //lblLetters
            lblLetters.Text = "Number of Letters";
            lblLetters.Name = "lblLetters";
            grid.SetContent(0, 3, lblLetters);

            //txtLetters
            txtLetters.Enabled = false;
            txtLetters.Name = "txtLetters";
            txtLetters.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(1, 0, txtLetters);

            //lblNumbers
            lblNumbers.Text = "Number of Numbers";
            lblNumbers.Name = "lblNumbers";
            grid.SetContent(1, 1, lblNumbers);

            //txtNumbers
            txtNumbers.Enabled = false;
            txtNumbers.Name = "txtNumbers";
            txtNumbers.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(1, 2, txtNumbers);

            //lblVowels
            lblVowels.Text = "Number of Vowels";
            lblVowels.Name = "lblVowels";
            grid.SetContent(2, 0, lblVowels);

            //txtVowels
            txtVowels.Enabled = false;
            txtVowels.Name = "txtVowels";
            txtVowels.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(2, 1, txtVowels);

            //lblUpperCase
            lblUpperCase.Text = "Number of Upper Case";
            lblUpperCase.Name = "lblUpperCase";
            grid.SetContent(2, 2, lblUpperCase);

            //txtUpperCase
            txtUpperCase.Enabled = false;
            txtUpperCase.Name = "txtUpperCase";
            txtUpperCase.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(3, 0, txtUpperCase);

            //lblLowerCase
            lblLowerCase.Text = "Number of Lower Case";
            lblLowerCase.Name = "lblLowerCase";
            grid.SetContent(3, 1, lblLowerCase);

            //txtLowerCase
            txtLowerCase.Enabled = false;
            txtLowerCase.Name = "txtLowerCase";
            grid.SetContent(3, 2, txtLowerCase);

            //btnSearch
            btnSearch.Text = "Search";
            btnSearch.Name = "btnSearch";
            grid.SetContent(4, 0, btnSearch);

            //btnClean
            btnClean.Text = "Clean";
            btnClean.Name = "btnClean";
            grid.SetContent(4, 1, btnClean);

            //btnExit
            btnExit.Text = "Exit";
            btnExit.Name = "btnExit";
            btnExit.Click += btnExit_Click;
            grid.SetContent(4, 2, btnExit);

            Page.Title = "@Media";
            Page.Content = grid;

            CSS.Style style = new CSS.Style();
            style.Parse(

   //#grid
   //    {
   //        display: grid;
   //        grid-template-areas: 
   //            ""lblString . .""
   //            ""txtString . .""
   //            ""lblLetters . .""
   //            ""txtLetters . .""
   //            ""lblNumbers . .""
   //            ""txtNumbers . .""
   //            ""lblVowels . .""
   //            ""txtVowels . .""
   //            ""lblUpperCase . .""
   //            ""txtUpperCase . .""
   //            ""lblLowerCase . .""
   //            ""txtLowerCase . .""
   //            ""btnSearch . .""
   //            ""btnClean . .""
   //            ""btnExit . ."";
   //    }

   //    @media only screen and (max-width: 500px)
   //    {
   //        #grid
   //        {
   //            display: grid;
   //            grid-template-areas: 
   //            ""lblString . .""
   //            ""txtString . .""
   //            ""lblLetters . .""
   //            ""txtLetters . .""
   //            ""lblNumbers . .""
   //            ""txtNumbers . .""
   //            ""lblVowels . .""
   //            ""txtVowels . .""
   //            ""lblUpperCase . .""
   //            ""txtUpperCase . .""
   //            ""lblLowerCase . .""
   //            ""txtLowerCase . .""
   //            ""btnSearch . .""
   //            ""btnClean . .""
   //            ""btnExit . ."";
   //        }
   //    }

   //#grid
   //                   display: grid;
   //                     grid-row-gap:
   //                        ""lblString . .""
   //                        ""txtString . .""
   //                        ""lblLetters . .""
   //                        ""txtLetters . .""
   //                        ""lblNumbers . .""
   //                        ""txtNumbers . .""
   //                        ""lblVowels . .""
   //                        ""txtVowels . .""
   //                        ""lblUpperCase . .""
   //                        ""txtUpperCase . .""
   //                        ""lblLowerCase . .""
   //                        ""txtLowerCase . .""
   //                        ""btnSearch . .""
   //                        ""btnClean . .""
   //                        ""btnExit . ."";


   //           @media only screen and (min-width: 600px)
   //                            {
   //                                #grid
   //                                {
   //                                    display: grid;
   //                                    grid-row-gap: 

   //                                    ""lblString . .""
   //                                    ""txtString . .""
   //                                    ""lblLetters . .""
   //                                    ""txtLetters . .""
   //                                    ""lblNumbers . .""
   //                                    ""txtNumbers . .""
   //                                    ""lblVowels . .""
   //                                    ""txtVowels . .""
   //                                    ""lblUpperCase . .""
   //                                    ""txtUpperCase . .""
   //                                    ""lblLowerCase . .""
   //                                    ""txtLowerCase . .""
   //                                    ""btnSearch . .""
   //                                    ""btnClean . .""
   //                                    ""btnExit . ."";
   //                                }
   //                }

   //                    @"
   //         #Grid
   //      {
   //          display grid;
   //          grid-row-gap:
   //              ""lblString . .""
   //              ""txtString . .""
   //              ""lblLetters . .""
   //              ""txtLetters . .""
   //              ""lblNumbers . .""
   //              ""txtNumbers . .""
   //              ""lblVowels . .""
   //              ""txtVowels . .""
   //              ""lblUpperCase . .""
   //              ""txtUpperCase . .""
   //              ""lblLowerCase . .""
   //              ""txtLowerCase . .""
   //              ""btnSearch . .""
   //              ""btnClean . .""
   //                ""btnExit . ."";
   //       }


   //@media only screen and (max-width: 1000px)
   //          {
   //              #grid
   //              {
   //                  display: grid;
   //                  grid-row-gap: 
   //                  ""lblString . .""
   //                  ""txtString . .""
   //                  ""lblLetters . .""
   //                  ""txtLetters . .""
   //                  ""lblNumbers . .""
   //                  ""txtNumbers . .""
   //                  ""lblVowels . .""
   //                  ""txtVowels . .""
   //                  ""lblUpperCase . .""
   //                  ""txtUpperCase . .""
   //                  ""lblLowerCase . .""
   //                  ""txtLowerCase . .""
   //                  ""btnSearch . .""
   //                  ""btnClean . .""
   //                  ""btnExit . ."";
   //            }
   //          }


   ////         #grid
   ////      {
   ////          display grid;
   ////          grid-column-gap
   ////              ""lblString . .""
   ////              ""txtString . .""
   ////              ""lblLetters . .""
   ////              ""txtLetters . .""
   ////              ""lblNumbers . .""
   ////              ""txtNumbers . .""
   ////              ""lblVowels . .""
   ////              ""txtVowels . .""
   ////              ""lblUpperCase . .""
   ////              ""txtUpperCase . .""
   ////              ""lblLowerCase . .""
   ////              ""txtLowerCase . .""
   ////              ""btnSearch . .""
   ////              ""btnClean . .""
   ////                ""btnExit . ."";
   ////       }


   ////@media only screen and (min-width: 500px)
   ////          {
   ////              #grid
   ////              {
   ////                  grid-column-gap;
   ////                  grid-row-gap: 
   ////                  ""lblString . .""
   ////                  ""txtString . .""
   ////                  ""lblLetters . .""
   ////                  ""txtLetters . .""
   ////                  ""lblNumbers . .""
   ////                  ""txtNumbers . .""
   ////                  ""lblVowels . .""
   ////                  ""txtVowels . .""
   ////                  ""lblUpperCase . .""
   ////                  ""txtUpperCase . .""
   ////                  ""lblLowerCase . .""
   ////                  ""txtLowerCase . .""
   ////                  ""btnSearch . .""
   ////                  ""btnClean . .""
   ////                  ""btnExit . ."";
   ////            }
   ////          }

   //            @"

   //                #grid
   //                 {
   //            display: grid;
   //                grid-template-rows
   //                         ""lblString. .""
   //                         ""txtString. .""
   //                         ""lblLetters. .""
   //                         ""txtLetters. .""
   //                         ""lblNumbers. .""
   //                         ""txtNumbers. .""
   //                         ""lblVowels. .""
   //                         ""txtVowels. .""
   //                         ""lblUpperCase. .""
   //                         ""txtUpperCase. .""
   //                         ""lblLowerCase. .""
   //                         ""txtLowerCase. .""
   //                         ""btnSearch. .""
   //                         ""btnClean. .""
   //                         ""btnExit. ."";
   //            }


   //            @media only screen and(max-width: 600px)
   //                 {
   //                    # grid
   //                {
   //                display: grid;
   //                    grid-template-rows
   //                         ""lblString. .""
   //                         ""txtString. .""
   //                         ""lblLetters. .""
   //                         ""txtLetters. .""
   //                         ""lblNumbers. .""
   //                         ""txtNumbers. .""
   //                         ""lblVowels. .""
   //                         ""txtVowels. .""
   //                         ""lblUpperCase. .""
   //                         ""txtUpperCase. .""
   //                         ""lblLowerCase. .""
   //                         ""txtLowerCase. .""
   //                         ""btnSearch. .""
   //                         ""btnClean. .""
   //                         ""btnExit. ."";
   //                }
   //            }

   //");
   //            style.Apply(Page);



   //  @"
   //#grid
   //    {
   //        display: grid;
   //        grid-template-columns: 
   //            ""lblString . .""
   //            ""txtString . .""
   //            ""lblLetters . .""
   //            ""txtLetters . .""
   //            ""lblNumbers . .""
   //            ""txtNumbers . .""
   //            ""lblVowels . .""
   //            ""txtVowels . .""
   //            ""lblUpperCase . .""
   //            ""txtUpperCase . .""
   //            ""lblLowerCase . .""
   //            ""txtLowerCase . .""
   //            ""btnSearch . .""
   //            ""btnClean . .""
   //            ""btnExit . ."";
   //    }

   //    @media only screen and (min-width: 300px)
   //    {
   //        #grid
   //        {
   //            display: grid;
   //            grid-template-columns:  
   //            ""lblString . .""
   //            ""txtString . .""
   //            ""lblLetters . .""
   //            ""txtLetters . .""
   //            ""lblNumbers . .""
   //            ""txtNumbers . .""
   //            ""lblVowels . .""
   //            ""txtVowels . .""
   //            ""lblUpperCase . .""
   //            ""txtUpperCase . .""
   //            ""lblLowerCase . .""
   //            ""txtLowerCase . .""
   //            ""btnSearch . .""
   //            ""btnClean . .""
   //            ""btnExit . ."";
   //        }
   //    }

   @"
            #grid
                {
                    display: grid;
                    grid-template-columns: 40px 60px 80px;
                        
                }

                @media only screen and (max-width: 10px)
                {
                   #grid 
                    {
                        display: grid;
                        grid-template-columns: 40px 100px;
                    }
                }

");
            style.Apply(Page);
        }

    }
}
