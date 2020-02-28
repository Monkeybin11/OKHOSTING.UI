using System;
using System.Collections.Generic;
using System.Text;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
    class ColumnGap : Controller
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
            lblSeparator.Text = "ColumnGap*****************************************";
            StackPrincipal.Children.Add(lblSeparator);

            IGrid GridOne = Core.BaitAndSwitch.Create<IGrid>();
            GridOne.Name = "GridTemplate";
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

            ILabel lblSeparator2 = Core.BaitAndSwitch.Create<ILabel>();
            lblSeparator2.Name = "Separator2";
            lblSeparator2.Text = "ColumnGap Example2*****************************************";
            StackPrincipal.Children.Add(lblSeparator2);

            IGrid GridTwo = Core.BaitAndSwitch.Create<IGrid>();
            GridTwo.Name = "GridTemplate2";
            GridTwo.ColumnCount = 4;
            GridTwo.RowCount = 4;
            StackPrincipal.Children.Add(GridTwo);

            ILabel lbel1 = Core.BaitAndSwitch.Create<ILabel>();
            lbel1.Name = "lbel1";
            lbel1.Text = "Primer Label";
            GridTwo.SetContent(0, 0, lbel1);

            ILabel lbel2 = Core.BaitAndSwitch.Create<ILabel>();
            lbel2.Name = "lbel2";
            lbel2.Text = "Segundo label";
            GridTwo.SetContent(0, 1, lbel2);

            ILabel lbel3 = Core.BaitAndSwitch.Create<ILabel>();
            lbel3.Name = "lbel3";
            lbel3.Text = "Tercer label";
            GridTwo.SetContent(0, 2, lbel3);

            ILabel lbel4 = Core.BaitAndSwitch.Create<ILabel>();
            lbel4.Name = "lbel4";
            lbel4.Text = "Cuarto label";
            GridTwo.SetContent(0, 3, lbel4);

            ITextBox txte1 = Core.BaitAndSwitch.Create<ITextBox>();
            txte1.Name = "txte1";
            txte1.Value = "Primer textbox";
            GridTwo.SetContent(1, 0, txte1);

            ITextBox txte2 = Core.BaitAndSwitch.Create<ITextBox>();
            txte2.Name = "txte2";
            txte2.Value = "Segudo textbox";
            GridTwo.SetContent(1, 1, txte2);

            ITextBox txte3 = Core.BaitAndSwitch.Create<ITextBox>();
            txte3.Name = "txte3";
            txte3.Value = "Tercer textbox";
            GridTwo.SetContent(1, 2, txte3);

            ITextBox txte4 = Core.BaitAndSwitch.Create<ITextBox>();
            txte4.Name = "txte4";
            txte4.Value = "cuarto textbox";
            GridTwo.SetContent(1, 3, txte4);

            IButton botn1 = Core.BaitAndSwitch.Create<IButton>();
            botn1.Name = "botn1";
            botn1.Text = "Primer boton";
            GridTwo.SetContent(2, 0, botn1);

            IButton botn2 = Core.BaitAndSwitch.Create<IButton>();
            botn2.Name = "botn2";
            botn2.Text = "Segundo boton";
            GridTwo.SetContent(2, 1, botn2);

            IButton botn3 = Core.BaitAndSwitch.Create<IButton>();
            botn3.Name = "botn3";
            botn3.Text = "Tercer boton";
            GridTwo.SetContent(2, 2, botn3);

            IButton botn4 = Core.BaitAndSwitch.Create<IButton>();
            botn4.Name = "botn4";
            botn4.Text = "Cuarto boton";
            GridTwo.SetContent(2, 3, botn4);

            ILabel lblSeparator3 = Core.BaitAndSwitch.Create<ILabel>();
            lblSeparator3.Name = "Separator3";
            lblSeparator3.Text = "ColumnGap Example3*****************************************";
            StackPrincipal.Children.Add(lblSeparator3);

            IGrid GridTree = Core.BaitAndSwitch.Create<IGrid>();
            GridTree.Name = "GridTemplate3";
            GridTree.ColumnCount = 4;
            GridTree.RowCount = 4;
            StackPrincipal.Children.Add(GridTree);

            ILabel label1 = Core.BaitAndSwitch.Create<ILabel>();
            label1.Name = "label1";
            label1.Text = "Primer Label";
            GridTree.SetContent(0, 0, label1);

            ILabel label2 = Core.BaitAndSwitch.Create<ILabel>();
            label2.Name = "label2";
            label2.Text = "Segundo label";
            GridTree.SetContent(0, 1, label2);

            ILabel label3 = Core.BaitAndSwitch.Create<ILabel>();
            label3.Name = "label3";
            label3.Text = "Tercer label";
            GridTree.SetContent(0, 2, label3);

            ILabel label4 = Core.BaitAndSwitch.Create<ILabel>();
            label4.Name = "label4";
            label4.Text = "Cuarto label";
            GridTwo.SetContent(0, 3, label4);

            ITextBox texte1 = Core.BaitAndSwitch.Create<ITextBox>();
            texte1.Name = "texte1";
            texte1.Value = "Primer textbox";
            GridTree.SetContent(1, 0, texte1);

            ITextBox texte2 = Core.BaitAndSwitch.Create<ITextBox>();
            texte2.Name = "texte2";
            texte2.Value = "Segudo textbox";
            GridTree.SetContent(1, 1, texte2);

            ITextBox texte3 = Core.BaitAndSwitch.Create<ITextBox>();
            texte3.Name = "texte3";
            texte3.Value = "Tercer textbox";
            GridTree.SetContent(1, 2, texte3);

            ITextBox texte4 = Core.BaitAndSwitch.Create<ITextBox>();
            texte4.Name = "texte4";
            texte4.Value = "cuarto textbox";
            GridTwo.SetContent(1, 3, texte4);

            IButton boton1 = Core.BaitAndSwitch.Create<IButton>();
            boton1.Name = "boton1";
            boton1.Text = "Primer boton";
            GridTree.SetContent(2, 0, boton1);

            IButton boton2 = Core.BaitAndSwitch.Create<IButton>();
            boton2.Name = "boton2";
            boton2.Text = "Segundo boton";
            GridTree.SetContent(2, 1, boton2);

            IButton boton3 = Core.BaitAndSwitch.Create<IButton>();
            boton3.Name = "boton3";
            boton3.Text = "Tercer boton";
            GridTree.SetContent(2, 2, boton3);

            IButton boton4 = Core.BaitAndSwitch.Create<IButton>();
            boton4.Name = "boton4";
            boton4.Text = "Cuarto boton";
            GridTree.SetContent(2, 3, boton4);

            ILabel lblSeparator4 = Core.BaitAndSwitch.Create<ILabel>();
            lblSeparator4.Name = "Separator4";
            lblSeparator4.Text = "ColumnGap Example4*****************************************";
            StackPrincipal.Children.Add(lblSeparator4);

            IGrid GridFour = Core.BaitAndSwitch.Create<IGrid>();
            GridFour.Name = "GridTemplate4";
            GridFour.ColumnCount = 4;
            GridFour.RowCount = 4;
            StackPrincipal.Children.Add(GridFour);

            ILabel label01 = Core.BaitAndSwitch.Create<ILabel>();
            label01.Name = "label01";
            label01.Text = "Primer Label";
            GridFour.SetContent(0, 0, label01);

            ILabel label02 = Core.BaitAndSwitch.Create<ILabel>();
            label02.Name = "label02";
            label02.Text = "Segundo label";
            GridFour.SetContent(0, 1, label02);

            ILabel label03 = Core.BaitAndSwitch.Create<ILabel>();
            label03.Name = "label03";
            label03.Text = "Tercer label";
            GridFour.SetContent(0, 2, label03);

            ILabel label04 = Core.BaitAndSwitch.Create<ILabel>();
            label04.Name = "label04";
            label04.Text = "Cuarto label";
            GridFour.SetContent(0, 3, label04);

            ITextBox texte01 = Core.BaitAndSwitch.Create<ITextBox>();
            texte01.Name = "texte01";
            texte01.Value = "Primer textbox";
            GridFour.SetContent(1, 0, texte01);

            ITextBox texte02 = Core.BaitAndSwitch.Create<ITextBox>();
            texte02.Name = "texte02";
            texte02.Value = "Segudo textbox";
            GridFour.SetContent(1, 1, texte02);

            ITextBox texte03 = Core.BaitAndSwitch.Create<ITextBox>();
            texte03.Name = "texte03";
            texte03.Value = "Tercer textbox";
            GridFour.SetContent(1, 2, texte03);

            ITextBox texte04 = Core.BaitAndSwitch.Create<ITextBox>();
            texte04.Name = "texte04";
            texte04.Value = "cuarto textbox";
            GridFour.SetContent(1, 3, texte04);

            IButton boton01 = Core.BaitAndSwitch.Create<IButton>();
            boton01.Name = "boton01";
            boton01.Text = "Primer boton";
            GridFour.SetContent(2, 0, boton01);

            IButton boton02 = Core.BaitAndSwitch.Create<IButton>();
            boton02.Name = "boton02";
            boton02.Text = "Segundo boton";
            GridFour.SetContent(2, 1, boton02);

            IButton boton03 = Core.BaitAndSwitch.Create<IButton>();
            boton03.Name = "boton03";
            boton03.Text = "Tercer boton";
            GridFour.SetContent(2, 2, boton03);

            IButton boton04 = Core.BaitAndSwitch.Create<IButton>();
            boton04.Name = "boton04";
            boton04.Text = "Cuarto boton";
            GridFour.SetContent(2, 3, boton04);


            ILabel lblSeparator5 = Core.BaitAndSwitch.Create<ILabel>();
            lblSeparator5.Name = "Separator5";
            lblSeparator5.Text = "ColumnGap Example5*****************************************";
            StackPrincipal.Children.Add(lblSeparator5);

            IGrid GridFive = Core.BaitAndSwitch.Create<IGrid>();
            GridFive.Name = "GridTemplate5";
            GridFive.ColumnCount = 4;
            GridFive.RowCount = 4;
            StackPrincipal.Children.Add(GridFive);

            ILabel label001 = Core.BaitAndSwitch.Create<ILabel>();
            label001.Name = "label001";
            label001.Text = "Primer Label";
            GridFive.SetContent(0, 0, label001);

            ILabel label002 = Core.BaitAndSwitch.Create<ILabel>();
            label002.Name = "label002";
            label002.Text = "Segundo label";
            GridFive.SetContent(0, 1, label002);

            ILabel label003 = Core.BaitAndSwitch.Create<ILabel>();
            label003.Name = "label003";
            label003.Text = "Tercer label";
            GridFive.SetContent(0, 2, label003);

            ILabel label004 = Core.BaitAndSwitch.Create<ILabel>();
            label004.Name = "label004";
            label004.Text = "Cuarto label";
            GridFive.SetContent(0, 3, label004);

            ITextBox texte001 = Core.BaitAndSwitch.Create<ITextBox>();
            texte001.Name = "texte001";
            texte001.Value = "Primer textbox";
            GridFive.SetContent(1, 0, texte001);

            ITextBox texte002 = Core.BaitAndSwitch.Create<ITextBox>();
            texte002.Name = "texte002";
            texte002.Value = "Segudo textbox";
            GridFive.SetContent(1, 1, texte002);

            ITextBox texte003 = Core.BaitAndSwitch.Create<ITextBox>();
            texte003.Name = "texte003";
            texte003.Value = "Tercer textbox";
            GridFive.SetContent(1, 2, texte003);

            ITextBox texte004 = Core.BaitAndSwitch.Create<ITextBox>();
            texte004.Name = "texte004";
            texte004.Value = "cuarto textbox";
            GridFive.SetContent(1, 3, texte004);

            IButton boton001 = Core.BaitAndSwitch.Create<IButton>();
            boton001.Name = "boton001";
            boton001.Text = "Primer boton";
            GridFive.SetContent(2, 0, boton001);

            IButton boton002 = Core.BaitAndSwitch.Create<IButton>();
            boton002.Name = "boton002";
            boton002.Text = "Segundo boton";
            GridFive.SetContent(2, 1, boton002);

            IButton boton003 = Core.BaitAndSwitch.Create<IButton>();
            boton003.Name = "boton003";
            boton003.Text = "Tercer boton";
            GridFive.SetContent(2, 2, boton003);

            IButton boton004 = Core.BaitAndSwitch.Create<IButton>();
            boton004.Name = "boton004";
            boton004.Text = "Cuarto boton";
            GridFive.SetContent(2, 3, boton004);

            ILabel lblSeparator6 = Core.BaitAndSwitch.Create<ILabel>();
            lblSeparator6.Name = "Separator6";
            lblSeparator6.Text = "ColumnGap Example6*****************************************";
            StackPrincipal.Children.Add(lblSeparator6);

            IGrid GridSix = Core.BaitAndSwitch.Create<IGrid>();
            GridSix.Name = "GridTemplate6";
            GridSix.ColumnCount = 4;
            GridSix.RowCount = 4;
            StackPrincipal.Children.Add(GridSix);

            ILabel label001a = Core.BaitAndSwitch.Create<ILabel>();
            label001a.Name = "label001a";
            label001a.Text = "Primer Label";
            GridSix.SetContent(0, 0, label001a);

            ILabel label002a = Core.BaitAndSwitch.Create<ILabel>();
            label002a.Name = "label002a";
            label002a.Text = "Segundo label";
            GridFive.SetContent(0, 1, label002a);

            ILabel label003a = Core.BaitAndSwitch.Create<ILabel>();
            label003a.Name = "label003a";
            label003a.Text = "Tercer label";
            GridSix.SetContent(0, 2, label003a);

            ILabel label004a = Core.BaitAndSwitch.Create<ILabel>();
            label004a.Name = "label004a";
            label004a.Text = "Cuarto label";
            GridSix.SetContent(0, 3, label004a);

            ITextBox texte001a = Core.BaitAndSwitch.Create<ITextBox>();
            texte001a.Name = "texte001a";
            texte001a.Value = "Primer textbox";
            GridSix.SetContent(1, 0, texte001a);

            ITextBox texte002a = Core.BaitAndSwitch.Create<ITextBox>();
            texte002a.Name = "texte002a";
            texte002a.Value = "Segudo textbox";
            GridSix.SetContent(1, 1, texte002a);

            ITextBox texte003a = Core.BaitAndSwitch.Create<ITextBox>();
            texte003a.Name = "texte003a";
            texte003a.Value = "Tercer textbox";
            GridSix.SetContent(1, 2, texte003a);

            ITextBox texte004a = Core.BaitAndSwitch.Create<ITextBox>();
            texte004a.Name = "texte004a";
            texte004a.Value = "cuarto textbox";
            GridSix.SetContent(1, 3, texte004a);

            IButton boton001a = Core.BaitAndSwitch.Create<IButton>();
            boton001a.Name = "boton001a";
            boton001a.Text = "Primer boton";
            GridSix.SetContent(2, 0, boton001a);

            IButton boton002a = Core.BaitAndSwitch.Create<IButton>();
            boton002a.Name = "boton002a";
            boton002a.Text = "Segundo boton";
            GridSix.SetContent(2, 1, boton002a);

            IButton boton003a = Core.BaitAndSwitch.Create<IButton>();
            boton003a.Name = "boton003a";
            boton003a.Text = "Tercer boton";
            GridSix.SetContent(2, 2, boton003a);

            IButton boton004a = Core.BaitAndSwitch.Create<IButton>();
            boton004a.Name = "boton004a";
            boton004a.Text = "Cuarto boton";
            GridSix.SetContent(2, 3, boton004a);

            ILabel lblSeparator7 = Core.BaitAndSwitch.Create<ILabel>();
            lblSeparator7.Name = "Separator7";
            lblSeparator7.Text = "ColumnGap Example7*****************************************";
            StackPrincipal.Children.Add(lblSeparator7);

            IGrid GridSeven = Core.BaitAndSwitch.Create<IGrid>();
            GridSeven.Name = "GridTemplate7";
            GridSeven.ColumnCount = 4;
            GridSeven.RowCount = 4;
            StackPrincipal.Children.Add(GridSeven);

            ILabel label001b = Core.BaitAndSwitch.Create<ILabel>();
            label001b.Name = "label001b";
            label001b.Text = "Primer Label";
            GridSeven.SetContent(0, 0, label001b);

            ILabel label002b = Core.BaitAndSwitch.Create<ILabel>();
            label002b.Name = "label002b";
            label002b.Text = "Segundo label";
            GridSeven.SetContent(0, 1, label002b);

            ILabel label003b = Core.BaitAndSwitch.Create<ILabel>();
            label003b.Name = "label003b";
            label003b.Text = "Tercer label";
            GridSeven.SetContent(0, 2, label003b);

            ILabel label004b = Core.BaitAndSwitch.Create<ILabel>();
            label004b.Name = "label004b";
            label004b.Text = "Cuarto label";
            GridSeven.SetContent(0, 3, label004b);

            ITextBox texte001b = Core.BaitAndSwitch.Create<ITextBox>();
            texte001b.Name = "texte001b";
            texte001b.Value = "Primer textbox";
            GridSeven.SetContent(1, 0, texte001b);

            ITextBox texte002b = Core.BaitAndSwitch.Create<ITextBox>();
            texte002a.Name = "texte002b";
            texte002a.Value = "Segudo textbox";
            GridSeven.SetContent(1, 1, texte002b);

            ITextBox texte003b = Core.BaitAndSwitch.Create<ITextBox>();
            texte003a.Name = "texte003b";
            texte003a.Value = "Tercer textbox";
            GridSeven.SetContent(1, 2, texte003b);

            ITextBox texte004b = Core.BaitAndSwitch.Create<ITextBox>();
            texte004b.Name = "texte004b";
            texte004b.Value = "cuarto textbox";
            GridSeven.SetContent(1, 3, texte004b);

            IButton boton001b = Core.BaitAndSwitch.Create<IButton>();
            boton001b.Name = "boton001b";
            boton001b.Text = "Primer boton";
            GridSeven.SetContent(2, 0, boton001b);

            IButton boton002b = Core.BaitAndSwitch.Create<IButton>();
            boton002b.Name = "boton002b";
            boton002b.Text = "Segundo boton";
            GridSeven.SetContent(2, 1, boton002b);

            IButton boton003b = Core.BaitAndSwitch.Create<IButton>();
            boton003b.Name = "boton003b";
            boton003b.Text = "Tercer boton";
            GridSeven.SetContent(2, 2, boton003b);

            IButton boton004b = Core.BaitAndSwitch.Create<IButton>();
            boton004b.Name = "boton004b";
            boton004b.Text = "Cuarto boton";
            GridSeven.SetContent(2, 3, boton004b);

            ILabel lblSeparator8 = Core.BaitAndSwitch.Create<ILabel>();
            lblSeparator8.Name = "Separator8";
            lblSeparator8.Text = "ColumnGap Example8*****************************************";
            StackPrincipal.Children.Add(lblSeparator8);

            IGrid GridEight = Core.BaitAndSwitch.Create<IGrid>();
            GridEight.Name = "GridTemplate8";
            GridEight.ColumnCount = 4;
            GridEight.RowCount = 4;
            StackPrincipal.Children.Add(GridEight);

            ILabel label001c = Core.BaitAndSwitch.Create<ILabel>();
            label001c.Name = "label001c";
            label001c.Text = "Primer Label";
            GridEight.SetContent(0, 0, label001c);

            ILabel label002c = Core.BaitAndSwitch.Create<ILabel>();
            label002c.Name = "label002c";
            label002c.Text = "Segundo label";
            GridEight.SetContent(0, 1, label002c);

            ILabel label003c = Core.BaitAndSwitch.Create<ILabel>();
            label003c.Name = "label003c";
            label003c.Text = "Tercer label";
            GridEight.SetContent(0, 2, label003c);

            ILabel label004c = Core.BaitAndSwitch.Create<ILabel>();
            label004c.Name = "label004c";
            label004c.Text = "Cuarto label";
            GridEight.SetContent(0, 3, label004c);

            ITextBox texte001c = Core.BaitAndSwitch.Create<ITextBox>();
            texte001c.Name = "texte001c";
            texte001c.Value = "Primer textbox";
            GridEight.SetContent(1, 0, texte001c);

            ITextBox texte002c = Core.BaitAndSwitch.Create<ITextBox>();
            texte002c.Name = "texte002c";
            texte002c.Value = "Segudo textbox";
            GridEight.SetContent(1, 1, texte002c);

            ITextBox texte003c = Core.BaitAndSwitch.Create<ITextBox>();
            texte003a.Name = "texte003c";
            texte003a.Value = "Tercer textbox";
            GridEight.SetContent(1, 2, texte003c);

            ITextBox texte004c = Core.BaitAndSwitch.Create<ITextBox>();
            texte004c.Name = "texte004c";
            texte004c.Value = "cuarto textbox";
            GridEight.SetContent(1, 3, texte004c);

            IButton boton001c = Core.BaitAndSwitch.Create<IButton>();
            boton001c.Name = "boton001c";
            boton001c.Text = "Primer boton";
            GridEight.SetContent(2, 0, boton001c);

            IButton boton002c = Core.BaitAndSwitch.Create<IButton>();
            boton002c.Name = "boton002c";
            boton002c.Text = "Segundo boton";
            GridEight.SetContent(2, 1, boton002c);

            IButton boton003c = Core.BaitAndSwitch.Create<IButton>();
            boton003c.Name = "boton003c";
            boton003c.Text = "Tercer boton";
            GridEight.SetContent(2, 2, boton003c);

            IButton boton004c = Core.BaitAndSwitch.Create<IButton>();
            boton004c.Name = "boton004c";
            boton004c.Text = "Cuarto boton";
            GridEight.SetContent(2, 3, boton004c);

            ILabel lblSeparator9 = Core.BaitAndSwitch.Create<ILabel>();
            lblSeparator9.Name = "Separator9";
            lblSeparator9.Text = "ColumnGap Example9*****************************************";
            StackPrincipal.Children.Add(lblSeparator9);

            IGrid GridNine = Core.BaitAndSwitch.Create<IGrid>();
            GridNine.Name = "GridTemplate9";
            GridNine.ColumnCount = 4;
            GridNine.RowCount = 4;
            StackPrincipal.Children.Add(GridNine);

            ILabel label001d = Core.BaitAndSwitch.Create<ILabel>();
            label001d.Name = "label001d";
            label001d.Text = "Primer Label";
            GridNine.SetContent(0, 0, label001d);

            ILabel label002d = Core.BaitAndSwitch.Create<ILabel>();
            label002d.Name = "label002d";
            label002d.Text = "Segundo label";
            GridNine.SetContent(0, 1, label002d);

            ILabel label003d = Core.BaitAndSwitch.Create<ILabel>();
            label003d.Name = "label003d";
            label003d.Text = "Tercer label";
            GridNine.SetContent(0, 2, label003d);

            ILabel label004d = Core.BaitAndSwitch.Create<ILabel>();
            label004d.Name = "label004d";
            label004d.Text = "Cuarto label";
            GridNine.SetContent(0, 3, label004d);

            ITextBox texte001d = Core.BaitAndSwitch.Create<ITextBox>();
            texte001d.Name = "texte001d";
            texte001d.Value = "Primer textbox";
            GridNine.SetContent(1, 0, texte001d);

            ITextBox texte002d = Core.BaitAndSwitch.Create<ITextBox>();
            texte002d.Name = "texte002d";
            texte002d.Value = "Segudo textbox";
            GridNine.SetContent(1, 1, texte002d);

            ITextBox texte003d = Core.BaitAndSwitch.Create<ITextBox>();
            texte003d.Name = "texte003d";
            texte003d.Value = "Tercer textbox";
            GridNine.SetContent(1, 2, texte003d);

            ITextBox texte004d = Core.BaitAndSwitch.Create<ITextBox>();
            texte004d.Name = "texte004d";
            texte004d.Value = "cuarto textbox";
            GridNine.SetContent(1, 3, texte004d);

            IButton boton001d = Core.BaitAndSwitch.Create<IButton>();
            boton001d.Name = "boton001d";
            boton001d.Text = "Primer boton";
            GridNine.SetContent(2, 0, boton001d);

            IButton boton002d = Core.BaitAndSwitch.Create<IButton>();
            boton002d.Name = "boton002d";
            boton002d.Text = "Segundo boton";
            GridNine.SetContent(2, 1, boton002d);

            IButton boton003d = Core.BaitAndSwitch.Create<IButton>();
            boton003d.Name = "boton003d";
            boton003d.Text = "Tercer boton";
            GridNine.SetContent(2, 2, boton003d);

            IButton boton004d = Core.BaitAndSwitch.Create<IButton>();
            boton004d.Name = "boton004d";
            boton004d.Text = "Cuarto boton";
            GridNine.SetContent(2, 3, boton004d);

            ILabel lblSeparator10 = Core.BaitAndSwitch.Create<ILabel>();
            lblSeparator10.Name = "Separator10";
            lblSeparator10.Text = "ColumnGap Example10*****************************************";
            StackPrincipal.Children.Add(lblSeparator10);

            IGrid GridTe = Core.BaitAndSwitch.Create<IGrid>();
            GridTe.Name = "GridTemplate10";
            GridTe.ColumnCount = 4;
            GridTe.RowCount = 4;
            StackPrincipal.Children.Add(GridTe);

            ILabel label001e = Core.BaitAndSwitch.Create<ILabel>();
            label001e.Name = "label001e";
            label001e.Text = "Primer Label";
            GridTe.SetContent(0, 0, label001e);

            ILabel label002e = Core.BaitAndSwitch.Create<ILabel>();
            label002e.Name = "label002e";
            label002e.Text = "Segundo label";
            GridTe.SetContent(0, 1, label002e);

            ILabel label003e = Core.BaitAndSwitch.Create<ILabel>();
            label003e.Name = "label003e";
            label003e.Text = "Tercer label";
            GridTe.SetContent(0, 2, label003e);

            ILabel label004e = Core.BaitAndSwitch.Create<ILabel>();
            label004e.Name = "label004e";
            label004e.Text = "Cuarto label";
            GridTe.SetContent(0, 3, label004e);

            ITextBox texte001e = Core.BaitAndSwitch.Create<ITextBox>();
            texte001e.Name = "texte001e";
            texte001e.Value = "Primer textbox";
            GridTe.SetContent(1, 0, texte001e);

            ITextBox texte002e = Core.BaitAndSwitch.Create<ITextBox>();
            texte002e.Name = "texte002e";
            texte002e.Value = "Segudo textbox";
            GridTe.SetContent(1, 1, texte002e);

            ITextBox texte003e = Core.BaitAndSwitch.Create<ITextBox>();
            texte003e.Name = "texte003e";
            texte003e.Value = "Tercer textbox";
            GridTe.SetContent(1, 2, texte003e);

            ITextBox texte004e = Core.BaitAndSwitch.Create<ITextBox>();
            texte004e.Name = "texte004e";
            texte004e.Value = "cuarto textbox";
            GridTe.SetContent(1, 3, texte004e);

            IButton boton001e = Core.BaitAndSwitch.Create<IButton>();
            boton001e.Name = "boton001e";
            boton001e.Text = "Primer boton";
            GridTe.SetContent(2, 0, boton001e);

            IButton boton002e = Core.BaitAndSwitch.Create<IButton>();
            boton002e.Name = "boton002e";
            boton002e.Text = "Segundo boton";
            GridTe.SetContent(2, 1, boton002e);

            IButton boton003e = Core.BaitAndSwitch.Create<IButton>();
            boton003e.Name = "boton003e";
            boton003e.Text = "Tercer boton";
            GridTe.SetContent(2, 2, boton003e);

            IButton boton004e = Core.BaitAndSwitch.Create<IButton>();
            boton004e.Name = "boton004e";
            boton004e.Text = "Cuarto boton";
            GridTe.SetContent(2, 3, boton004e);

            CSS.Style style = new CSS.Style();
            style.Parse(@"

                #GridTemplate
                {
                    display: grid;
                    grid-column-gap: 50px;
                }

                #GridTemplate2
                {
                    display: grid;
                    grid-column-gap: 50 px;
                }

                #GridTemplate3
                {
                    display: grid;
                    grid-column-gap: 50px  ;
                }

                #GridTemplate4
                {
                    display: grid;
                    grid-column-gap: 50px 20px;
                }

                #GridTemplate5
                {
                    display: grid;
                    grid-column-gap: 80px;
                }

                #GridTemplate6
                {
                    display: grid;
                    grid-column-gap: 100px;
                }

                #GridTemplate7
                {
                    display: grid;
                    grid-column-gap: 25px;
                }

                #GridTemplate8
                {
                    display: grid;
                    grid-column-gap: 75px;
                }

                #GridTemplate9
                {
                    display: grid;
                    grid-column-gap: 60px;
                }

                #GridTemplate10
                {
                    display: grid;
                    grid-column-gap: 90px;
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
