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
			GridRowGapAndColumnGapController.Click += (object sender, EventArgs e) => new GridRowGapAndColumnGapController() { Page = Page }.Start();
			stack.Children.Add(GridRowGapAndColumnGapController);

			ILabelButton GridTemplateRowsAndGridTemplateColumnsController = Core.BaitAndSwitch.Create<ILabelButton>();
			GridTemplateRowsAndGridTemplateColumnsController.Text = "grid-template-rows And grid-template-columns Controller";
			GridTemplateRowsAndGridTemplateColumnsController.Click += (object sender, EventArgs e) => new GridTemplateRowsAndGridTemplateColumns() { Page = Page }.Start();
			stack.Children.Add(GridTemplateRowsAndGridTemplateColumnsController);

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