using System;
using System.Collections.Generic;
using System.Text;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
   public class GridTemplateAreas : Controller
    {
        protected override void OnStart()
        {
            IStack StackPrincipal = Core.BaitAndSwitch.Create<IStack>();

            Page.Content = StackPrincipal;

            IButton Salir = Core.BaitAndSwitch.Create<IButton>();
            Salir.Text = "Exit";
            Salir.Click += btnExit_Click;
            StackPrincipal.Children.Add(Salir);

            ILabel lblSeparator = Core.BaitAndSwitch.Create<ILabel>();
            lblSeparator.Name = "Separator";
            lblSeparator.Text = "grid-template-areas*****************************************";
            StackPrincipal.Children.Add(lblSeparator);

            IGrid GridOne = Core.BaitAndSwitch.Create<IGrid>();
            GridOne.Name = "GridTemplateAreas";
            GridOne.ColumnCount = 4;
            GridOne.RowCount = 4;
            StackPrincipal.Children.Add(GridOne);


            ILabel lbl1 = Core.BaitAndSwitch.Create<ILabel>();
            lbl1.Name = "lbl1";
            lbl1.Text = "Primer Label";
            GridOne.SetContent(0, 0, lbl1);

            ILabel lbl2 = Core.BaitAndSwitch.Create<ILabel>();
            lbl2.Name = "lbl2";
            lbl2.Text = "Segundo label";
            GridOne.SetContent(0, 1, lbl2);

            ILabel lbl3 = Core.BaitAndSwitch.Create<ILabel>();
            lbl3.Name = "lbl3";
            lbl3.Text = "Tercer label";
            GridOne.SetContent(0, 2, lbl3);

            ILabel lbl4 = Core.BaitAndSwitch.Create<ILabel>();
            lbl4.Name = "lbl4";
            lbl4.Text = "Cuarto label";
            GridOne.SetContent(0, 3, lbl4);

            ITextBox txt1 = Core.BaitAndSwitch.Create<ITextBox>();
            txt1.Name = "txt1";
            txt1.Value = "Primer textbox";
            GridOne.SetContent(1, 0, txt1);

            ITextBox txt2 = Core.BaitAndSwitch.Create<ITextBox>();
            txt2.Name = "txt2";
            txt2.Value = "Segudo textbox";
            GridOne.SetContent(1, 1, txt2);

            ITextBox txt3 = Core.BaitAndSwitch.Create<ITextBox>();
            txt3.Name = "txt3";
            txt3.Value = "Tercer textbox";
            GridOne.SetContent(1, 2, txt3);

            ITextBox txt4 = Core.BaitAndSwitch.Create<ITextBox>();
            txt4.Name = "txt4";
            txt4.Value = "cuarto textbox";
            GridOne.SetContent(1, 3, txt4);

            IButton btn1 = Core.BaitAndSwitch.Create<IButton>();
            btn1.Name = "btn1";
            btn1.Text = "Primer boton";
            GridOne.SetContent(2, 0, btn1);

            IButton btn2 = Core.BaitAndSwitch.Create<IButton>();
            btn2.Name = "btn2";
            btn2.Text = "Segundo boton";
            GridOne.SetContent(2, 1, btn2);

            IButton btn3 = Core.BaitAndSwitch.Create<IButton>();
            btn3.Name = "btn3";
            btn3.Text = "Tercer boton";
            GridOne.SetContent(2, 2, btn3);

            IButton btn4 = Core.BaitAndSwitch.Create<IButton>();
            btn4.Name = "btn4";
            btn4.Text = "Cuarto boton";
            GridOne.SetContent(2, 3, btn4);

            CSS.Style style = new CSS.Style();
            style.Parse(@"
             
			#GridTemplateAreas *
			{
				width: 100px;
				height: 100px;
				border: 1px solid black;
				background-color: #445588;
			}

            #GridTemplateAreas
            {
				Display: grid;
				grid-template-areas: 
				""txt1 txt1 txt3 .""
				"" .   lbl2 txt3 .""
				""lbl1 lbl1 txt3 .""
				""lbl1 lbl1 txt3 ."";
				grid-auto-columns: 200px;
				grid-auto-rows: 200px;
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
