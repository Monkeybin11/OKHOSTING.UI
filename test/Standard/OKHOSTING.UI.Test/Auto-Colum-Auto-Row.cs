using System;
using System.Collections.Generic;
using System.Text;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
    public class Auto_Colum_Auto_Row : Controller
    {
        protected override void OnStart()
        {
            IStack StackPrincipal = Core.BaitAndSwitch.Create<IStack>();

            ILabel lblGridAutorow = Core.BaitAndSwitch.Create<ILabel>();
            lblGridAutorow.Text = "***************grid-auto-rows ***************";
            StackPrincipal.Children.Add(lblGridAutorow);

            IButton btnExit = Core.BaitAndSwitch.Create<IButton>();
            btnExit.Text = "Exit";
            btnExit.Click += btnExit_Click;
            StackPrincipal.Children.Add(btnExit);

            IGrid AutoRow = Core.BaitAndSwitch.Create<IGrid>();
            AutoRow.Name = "AutoRow";
            AutoRow.ColumnCount = 4;
            AutoRow.RowCount = 4;
            StackPrincipal.Children.Add(AutoRow);


            ILabel lbl1l = Core.BaitAndSwitch.Create<ILabel>();
            lbl1l.Name = "lbl1";
            lbl1l.Text = "Primer Label";
            AutoRow.SetContent(0, 0, lbl1l);

            ILabel lbl2l = Core.BaitAndSwitch.Create<ILabel>();
            lbl2l.Name = "lbl2";
            lbl2l.Text = "Segundo label";
            AutoRow.SetContent(1, 0, lbl2l);

            ILabel lbl3l = Core.BaitAndSwitch.Create<ILabel>();
            lbl3l.Name = "lbl3";
            lbl3l.Text = "Tercer label";
            AutoRow.SetContent(2, 0, lbl3l);

            ILabel lbl4l = Core.BaitAndSwitch.Create<ILabel>();
            lbl4l.Name = "lbl4";
            lbl4l.Text = "Cuarto label";
            AutoRow.SetContent(3, 0, lbl4l);

            ITextBox txt1t = Core.BaitAndSwitch.Create<ITextBox>();
            txt1t.Name = "txt1";
            txt1t.Value = "Primer textbox";
            AutoRow.SetContent(0, 1, txt1t);

            ITextBox txt2t = Core.BaitAndSwitch.Create<ITextBox>();
            txt2t.Name = "txt2";
            txt2t.Value = "Segudo textbox";
            AutoRow.SetContent(1, 1, txt2t);

            ITextBox txt3t = Core.BaitAndSwitch.Create<ITextBox>();
            txt3t.Name = "txt3";
            txt3t.Value = "Tercer textbox";
            AutoRow.SetContent(2, 1, txt3t);

            ITextBox txt4t = Core.BaitAndSwitch.Create<ITextBox>();
            txt4t.Name = "txt4";
            txt4t.Value = "cuarto textbox";
            AutoRow.SetContent(3, 1, txt4t);

            IButton btn1b = Core.BaitAndSwitch.Create<IButton>();
            btn1b.Name = "btn1";
            btn1b.Text = "Primer boton";
            AutoRow.SetContent(2, 2, btn1b);

            IButton btn2b = Core.BaitAndSwitch.Create<IButton>();
            btn2b.Name = "btn2";
            btn2b.Text = "Segundo boton";
            AutoRow.SetContent(2, 3, btn2b);

            IButton btn3b = Core.BaitAndSwitch.Create<IButton>();
            btn3b.Name = "btn3";
            btn3b.Text = "Tercer boton";
            AutoRow.SetContent(3, 2, btn3b);

            IButton btn4b = Core.BaitAndSwitch.Create<IButton>();
            btn4b.Name = "btn4";
            btn4b.Text = "Cuarto botn";
            AutoRow.SetContent(3, 3, btn4b);

            ILabel lblGridAutoColumn = Core.BaitAndSwitch.Create<ILabel>();
            lblGridAutoColumn.Text = "***************grid-auto-column ***************";
            StackPrincipal.Children.Add(lblGridAutoColumn);

            IGrid AutoColumn = Core.BaitAndSwitch.Create<IGrid>();
            AutoColumn.Name = "AutoColumn";
            AutoColumn.ColumnCount = 4;
            AutoColumn.RowCount = 4;
            StackPrincipal.Children.Add(AutoColumn);

            ILabel label1 = Core.BaitAndSwitch.Create<ILabel>();
            label1.Name = "label1";
            label1.Text = "Primer Label";
            AutoColumn.SetContent(0, 0, label1);

            ILabel label2 = Core.BaitAndSwitch.Create<ILabel>();
            label2.Name = "label2";
            label2.Text = "Segundo label";
            AutoColumn.SetContent(1, 0, label2);

            ILabel label3 = Core.BaitAndSwitch.Create<ILabel>();
            label3.Name = "label3";
            label3.Text = "Tercer label";
            AutoColumn.SetContent(2, 0, label1);

            ILabel label4 = Core.BaitAndSwitch.Create<ILabel>();
            label4.Name = "label4";
            label4.Text = "Cuarto label";
            AutoColumn.SetContent(3, 0, label4);

            ITextBox text1 = Core.BaitAndSwitch.Create<ITextBox>();
            text1.Name = "text1";
            text1.Value = "Primer textbox";
            AutoColumn.SetContent(0, 1, text1);

            ITextBox text2 = Core.BaitAndSwitch.Create<ITextBox>();
            text2.Name = "text2";
            text2.Value = "Segudo textbox";
            AutoColumn.SetContent(1, 1, text2);

            ITextBox text3 = Core.BaitAndSwitch.Create<ITextBox>();
            text3.Name = "text3";
            text3.Value = "Tercer textbox";
            AutoColumn.SetContent(2, 1, text3);

            ITextBox text4 = Core.BaitAndSwitch.Create<ITextBox>();
            text4.Name = "text4";
            text4.Value = "cuarto textbox";
            AutoColumn.SetContent(3, 1, text4);

            IButton button1 = Core.BaitAndSwitch.Create<IButton>();
            button1.Name = "button1";
            button1.Text = "Primer boton";
            AutoColumn.SetContent(2, 2, button1);

            IButton button2 = Core.BaitAndSwitch.Create<IButton>();
            button2.Name = "button2";
            button2.Text = "Segundo boton";
            AutoColumn.SetContent(2, 3, button2);

            IButton button3 = Core.BaitAndSwitch.Create<IButton>();
            button3.Name = "button3";
            button3.Text = "Tercer boton";
            AutoColumn.SetContent(3, 2, button3);

            IButton button4 = Core.BaitAndSwitch.Create<IButton>();
            button4.Name = "button4";
            button4.Text = "Cuarto boton";
            AutoColumn.SetContent(3, 3, button4);

            ILabel lblGridAutoColumnAndAutoRow = Core.BaitAndSwitch.Create<ILabel>();
            lblGridAutoColumnAndAutoRow.Text = "***************grid-auto-column-and-auto-row***************";
            StackPrincipal.Children.Add(lblGridAutoColumnAndAutoRow);

            IGrid AutoColumnAutoColumn = Core.BaitAndSwitch.Create<IGrid>();
            AutoColumnAutoColumn.Name = "AutoColumnAndAutoRow";
            AutoColumnAutoColumn.ColumnCount = 4;
            AutoColumnAutoColumn.RowCount = 4;
            StackPrincipal.Children.Add(AutoColumnAutoColumn);

            ILabel label1l = Core.BaitAndSwitch.Create<ILabel>();
            label1l.Name = "label1l";
            label1l.Text = "Primer Label";
            AutoColumnAutoColumn.SetContent(0, 0, label1l);

            ILabel label2l = Core.BaitAndSwitch.Create<ILabel>();
            label2l.Name = "label2l";
            label2l.Text = "Segundo label";
            AutoColumnAutoColumn.SetContent(1, 0, label2l);

            ILabel label3l = Core.BaitAndSwitch.Create<ILabel>();
            label3l.Name = "label3l";
            label3l.Text = "Tercer label";
            AutoColumnAutoColumn.SetContent(2, 0, label1l);

            ILabel label4l = Core.BaitAndSwitch.Create<ILabel>();
            label4l.Name = "label4l";
            label4l.Text = "Cuarto label";
            AutoColumnAutoColumn.SetContent(3, 0, label4l);

            ITextBox text1t = Core.BaitAndSwitch.Create<ITextBox>();
            text1t.Name = "txt1t";
            text1t.Value = "Primer textbox";
            AutoColumnAutoColumn.SetContent(0, 1, text1t);

            ITextBox text2t = Core.BaitAndSwitch.Create<ITextBox>();
            text2t.Name = "text2t";
            text2t.Value = "Segudo textbox";
            AutoColumnAutoColumn.SetContent(1, 1, text2t);

            ITextBox text3t = Core.BaitAndSwitch.Create<ITextBox>();
            text3t.Name = "txt3t";
            text3t.Value = "Tercer textbox";
            AutoColumnAutoColumn.SetContent(2, 1, text3t);

            ITextBox text4t = Core.BaitAndSwitch.Create<ITextBox>();
            text4t.Name = "txt4t";
            text4t.Value = "cuarto textbox";
            AutoColumnAutoColumn.SetContent(3, 1, text4t);

            IButton button1b = Core.BaitAndSwitch.Create<IButton>();
            button1b.Name = "button1b";
            button1b.Text = "Primer boton";
            AutoColumnAutoColumn.SetContent(2, 2, button1b);

            IButton button2b = Core.BaitAndSwitch.Create<IButton>();
            button2b.Name = "button2b";
            button2b.Text = "Segundo boton";
            AutoColumnAutoColumn.SetContent(2, 3, button2b);

            IButton button3b = Core.BaitAndSwitch.Create<IButton>();
            button3b.Name = "button3b";
            button3b.Text = "Tercer boton";
            AutoColumnAutoColumn.SetContent(3, 2, button3b);

            IButton button4b = Core.BaitAndSwitch.Create<IButton>();
            button4b.Name = "btn4b";
            button4b.Text = "Cuarto botn";
            AutoColumnAutoColumn.SetContent(3, 3, button4b);

            Page.Title = "grid-template";
            Page.Content = StackPrincipal;

            CSS.Style style = new CSS.Style();
            style.Parse(@"

                #AutoRow
                    {
                        display: grid;
                        grid-template-rows: 40px 40px 40px;
                        grid-auto-rows: 50px;
                        
                    }

                #AutoColumn
                    {
                        display: grid;
                        grid-template-columns: 80px 80px;
                        grid-auto-columns: 120px;
                    }

                #AutoColumnAndAutoRow
                    {  
                        display: grid;
                        grid-template-rows: 40px 40px 40px;
                        grid-auto-rows: 50px;
                        grid-template-columns: 80px 80px;
                        grid-auto-columns: 120px;
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
