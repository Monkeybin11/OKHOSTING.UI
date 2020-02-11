﻿using OKHOSTING.UI.Controls;
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
            IGrid grid = Core.BaitAndSwitch.Create<IGrid>();
            grid.ColumnCount = 3;
            grid.RowCount = 3;
            grid.Name = "grid";

            IButton BtnClose = Core.BaitAndSwitch.Create<IButton>();
            BtnClose.Text = "Close";
            BtnClose.Name = "Close";
            grid.SetContent(0, 0, BtnClose);

            ICalendar Ccalendar = Core.BaitAndSwitch.Create<ICalendar>();
            Ccalendar.Name = "Calendar";
            grid.SetContent(0, 1, Ccalendar);

            IDatePicker Pdate = Core.BaitAndSwitch.Create<IDatePicker>();
            Pdate.Name = "DatePicker";
            grid.SetContent(0, 2, Pdate);

            ILabelButton ListP = Core.BaitAndSwitch.Create<ILabelButton>();
            ListP.Text = "ListPicker";
            grid.SetContent(1, 0, ListP);

            IButton Image = Core.BaitAndSwitch.Create<IButton>();
            Image.Name = "Picture";
            Image.Text = "texto";
            grid.SetContent(1, 1, Image);

            ILabel Label1 = Core.BaitAndSwitch.Create<ILabel>();
            Label1.Text = "Welcome";
            Label1.Name = "Label1";
            grid.SetContent(1, 2, Label1);

            ILabelButton labelbutton = Core.BaitAndSwitch.Create<ILabelButton>();
            labelbutton.Name = "labelButton";
            labelbutton.Text = "Button";
            grid.SetContent(2, 0, labelbutton);

            IListPicker picker = Core.BaitAndSwitch.Create<IListPicker>();
            picker.Name = "picker";
            grid.SetContent(2, 1, picker);

            ILabel label2 = Core.BaitAndSwitch.Create<ILabel>();
            label2.Text = "Label2";
            label2.Name = "Label2";
            grid.SetContent(2, 2, label2);

            Page.Title = "Hi friend";
            Page.Content = grid;

            CSS.Style style = new CSS.Style();
            style.Parse(@"

                #grid 
                {
                    display: grid;
                    grid-template-areas: 
                    "". Close Close""
                    "". Calendar Label1""
                    "". labelButton Label2"";
                    grid-template-rows: 100px;
                    grid-auto-rows: 200px;
                    grid-template-columns: 150px 200px 100px;
               }"
                 );
            style.Apply(Page);
        }
    }
}