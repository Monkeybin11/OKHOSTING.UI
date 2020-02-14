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

			IStack stack = Core.BaitAndSwitch.Create<IStack>();

			ILabelButton GridRowGapAndColumnGapController = Core.BaitAndSwitch.Create<ILabelButton>();
			GridRowGapAndColumnGapController.Text = "grid-row-gap and grid-column-gap Controller";
			GridRowGapAndColumnGapController.Margin = new Thickness(0, 0, 0, 50);
			GridRowGapAndColumnGapController.Click += (object sender, EventArgs e) => new GridRowGapAndColumnGapController() { Page = Page }.Start();
			stack.Children.Add(GridRowGapAndColumnGapController);

			ILabelButton GridTemplateRowsAndGridTemplateColumnsController = Core.BaitAndSwitch.Create<ILabelButton>();
			GridTemplateRowsAndGridTemplateColumnsController.Text = "grid-template-rows And grid-template-columns Controller";
			GridTemplateRowsAndGridTemplateColumnsController.Margin = new Thickness(0, 0, 0, 50);
			GridTemplateRowsAndGridTemplateColumnsController.Click += (object sender, EventArgs e) => new GridTemplateRowsAndGridTemplateColumns() { Page = Page }.Start();
			stack.Children.Add(GridTemplateRowsAndGridTemplateColumnsController);

			ILabelButton gridTemplateAreas = Core.BaitAndSwitch.Create<ILabelButton>();
			gridTemplateAreas.Text = "grid-template-areas";
			gridTemplateAreas.Margin = new Thickness(0, 0, 0, 50);
			gridTemplateAreas.Click += (object sender, EventArgs e) => new GridTemplateAreas() { Page = Page }.Start();
			stack.Children.Add(gridTemplateAreas);

			ILabelButton gridTemplate = Core.BaitAndSwitch.Create<ILabelButton>();
			gridTemplate.Text = "Grid-Template";
			gridTemplate.Margin = new Thickness(0, 0, 0, 50); 
			gridTemplate.Click += (object sender, EventArgs e) => new gridTemplateController() { Page = Page }.Start();
			stack.Children.Add(gridTemplate);


			IButton btnExit = Core.BaitAndSwitch.Create<IButton>();
			btnExit.Text = "Exit";
			btnExit.Click += btnExit_Click;
			stack.Children.Add(btnExit);

			Page.Content = stack;
		}

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Finish();
        }

    }
}