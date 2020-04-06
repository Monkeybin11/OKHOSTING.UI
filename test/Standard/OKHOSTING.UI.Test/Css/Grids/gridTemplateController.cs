using System;
using System.Collections.Generic;
using System.Text;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Css.Grids
{
    public class gridTemplateController : Controller
    {
        protected override void OnStart()
        {
            IStack stackPpal = Core.BaitAndSwitch.Create<IStack>();

            IButton btnExit = Core.BaitAndSwitch.Create<IButton>();
            btnExit.Text = "Exit";
            btnExit.Click += btnExit_Click;
            stackPpal.Children.Add(btnExit);

            ILabel lblGridTemplateOne = Core.BaitAndSwitch.Create<ILabel>();
            lblGridTemplateOne.Text = "*************** grid-template ***************";
            stackPpal.Children.Add(lblGridTemplateOne);

            IGrid GridTemplateOne = Core.BaitAndSwitch.Create<IGrid>();
            GridTemplateOne.Name = "gridTemplateOne";
            GridTemplateOne.ColumnCount = 4;
            GridTemplateOne.RowCount = 4;
            stackPpal.Children.Add(GridTemplateOne);

            ILabel lbl1 = Core.BaitAndSwitch.Create<ILabel>();
            lbl1.Name = "lbl1";
            lbl1.Text = "Primer Label";
            GridTemplateOne.SetContent(0, 0, lbl1);

            ILabel lbl2 = Core.BaitAndSwitch.Create<ILabel>();
            lbl2.Name = "lbl2";
            lbl2.Text = "Segundo label";
            GridTemplateOne.SetContent(1, 0, lbl2);

            ILabel lbl3 = Core.BaitAndSwitch.Create<ILabel>();
            lbl3.Name = "lbl3";
            lbl3.Text = "Tercer label";
            GridTemplateOne.SetContent(2, 0, lbl3);

            ILabel lbl4 = Core.BaitAndSwitch.Create<ILabel>();
            lbl4.Name = "lbl4";
            lbl4.Text = "Cuarto label";
            GridTemplateOne.SetContent(3, 0, lbl4);

            ITextBox txt1 = Core.BaitAndSwitch.Create<ITextBox>();
            txt1.Name = "txt1";
            txt1.Value = "Primer textbox";
            GridTemplateOne.SetContent(0, 1, txt1);

            ITextBox txt2 = Core.BaitAndSwitch.Create<ITextBox>();
            txt2.Name = "txt2";
            txt2.Value = "Segudo textbox";
            GridTemplateOne.SetContent(1, 1, txt2);

            ITextBox txt3 = Core.BaitAndSwitch.Create<ITextBox>();
            txt3.Name = "txt3";
            txt3.Value = "Tercer textbox";
            GridTemplateOne.SetContent(2, 1, txt3);

            ITextBox txt4 = Core.BaitAndSwitch.Create<ITextBox>();
            txt4.Name = "txt4";
            txt4.Value = "cuarto textbox";
            GridTemplateOne.SetContent(3, 1, txt4);

            IButton btn1 = Core.BaitAndSwitch.Create<IButton>();
            btn1.Name = "btn1";
            btn1.Text = "Primer boton";
            GridTemplateOne.SetContent(2, 2, btn1);

            IButton btn2 = Core.BaitAndSwitch.Create<IButton>();
            btn2.Name = "btn2";
            btn2.Text = "Segundo boton";
            GridTemplateOne.SetContent(2, 3, btn2);

            IButton btn3 = Core.BaitAndSwitch.Create<IButton>();
            btn3.Name = "btn3";
            btn3.Text = "Tercer boton";
            GridTemplateOne.SetContent(3, 2, btn3);

            IButton btn4 = Core.BaitAndSwitch.Create<IButton>();
            btn4.Name = "btn4";
            btn4.Text = "Cuarto botn";
            GridTemplateOne.SetContent(3, 3, btn4);

            


            Page.Title = "grid-template";
            Page.Content = stackPpal;

            CSS.Style style = new CSS.Style();
            style.Parse(@"

                #gridTemplateOne
                {
                    display: grid;
                    grid-template: 20px 40px 60px 80px / 80px 60px 40px 20px;
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
