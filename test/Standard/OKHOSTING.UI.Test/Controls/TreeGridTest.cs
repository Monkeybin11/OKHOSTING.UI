using System;
using System.Collections.Generic;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Controls
{
	/// <summary>
	/// It represents an TreeGrid.
	/// </summary>
	public class TreeGridTest : Controller
	{
		const int Columns = 4;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia de este objeto.
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			var container = Core.BaitAndSwitch.Create<IUserControl>();
			container.App = Page.App;

			var treeGrid = new Controllers.TreeGridController(container);
			var headers = new IControl[Columns];

			for (int column = 0; column < Columns; column++)
			{
				var label = Core.BaitAndSwitch.Create<ILabel>();
				label.Text = $"Column {column}";

				headers[column] = label;
			}

			treeGrid.Header = headers;

			var rows = new List<Controllers.TreeGridController.Row>();

			for (int rowIndex = 0; rowIndex < 10; rowIndex++)
			{
				var row = CreateRow($"{rowIndex}");
				rows.Add(row);

				if (rowIndex % 4 == 0)
				{
					var children = new List<Controllers.TreeGridController.Row>();
					
					for (int childRowIndex = 0; childRowIndex < 3; childRowIndex++)
					{
						var child = CreateRow($"{rowIndex}.{childRowIndex}");
						
						children.Add(child);

						if (rowIndex % 2 == 0)
						{
							var children2 = new List<Controllers.TreeGridController.Row>();

							for (int childRowIndex2 = 0; childRowIndex2 < 2; childRowIndex2++)
							{
								children2.Add(CreateRow($"{rowIndex}.{childRowIndex}.{childRowIndex2}"));
							}

							child.Children = children2;
						}
					}
				
					row.Children = children;
				}
			}

			treeGrid.Rows = rows;
			treeGrid.Start();

			var cmdClose = Core.BaitAndSwitch.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += cmdClose_Click;

			var stack = Core.BaitAndSwitch.Create<IStack>();
			stack.Children.Add(container);
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page.
			Page.Title = "Test a TreeGrid";
			Page.Content = stack;
		}

		protected Controllers.TreeGridController.Row CreateRow(string text)
		{
			var row = new Controllers.TreeGridController.Row();
			var content = new IControl[Columns];

			for (int column = 0; column < Columns; column++)
			{
				var label = Core.BaitAndSwitch.Create<ILabel>();
				label.Text = text;

				content[column] = label;
			}
			
			row.Content = content;
			row.Collapsed = true;

			return row;
		}

		/// <summary>
		/// It is the button click event cmdClose, what it does is end this instance.
		/// <para xml:lang="es">
		/// Es el evento clic del boton cmdClose, lo que hace es finalizar esta instancia.
		/// </para>
		/// </summary>
		/// <returns>The close click.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void cmdClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}
	}
}