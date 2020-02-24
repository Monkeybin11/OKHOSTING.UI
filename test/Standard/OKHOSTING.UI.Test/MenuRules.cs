using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Text;

namespace OKHOSTING.UI.Test
{
	public class MenuRules : Controller

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

			ILabelButton Template = Core.BaitAndSwitch.Create<ILabelButton>();
			Template.Text = "Template";
			Template.Click += (object sender, EventArgs e) => new TestControllers() { Page = Page }.Start();
			stack.Children.Add(Template);

			ILabelButton TemplateAreas = Core.BaitAndSwitch.Create<ILabelButton>();
			TemplateAreas.Text = "Template Areas";
			TemplateAreas.Click += (object sender, EventArgs e) => new TemplateAreas() { Page = Page }.Start();
			stack.Children.Add(TemplateAreas);

			ILabelButton TemplateColumns = Core.BaitAndSwitch.Create<ILabelButton>();
			TemplateColumns.Text = "Template Columns";
			TemplateColumns.Click += (object sender, EventArgs e) => new TemplateColumns() { Page = Page }.Start();
			stack.Children.Add(TemplateColumns);

			ILabelButton TemplateRows = Core.BaitAndSwitch.Create<ILabelButton>();
			TemplateRows.Text = "Template Rows";
			TemplateRows.Click += (object sender, EventArgs e) => new TemplateRows() { Page = Page }.Start();
			stack.Children.Add(TemplateRows);

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
