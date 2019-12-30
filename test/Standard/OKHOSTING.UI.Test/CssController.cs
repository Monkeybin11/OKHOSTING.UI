using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Test
{
    class CssController : Controller
    {

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia de este objeto.
		/// </para>
		/// </summary>
		/// 

		protected override void OnStart()
		{
			

			//Create an Grid with specified columns and rows.
			IGrid grid = Core.BaitAndSwitch.Create<IGrid>();
			grid.ColumnCount = 3;
			grid.RowCount = 8;

			ILabel lblOne = Core.BaitAndSwitch.Create<ILabel>();
			lblOne.Text = "This is a CSS test";
			lblOne.Name = "lblOne";
			lblOne.CssClass = "container";
			grid.SetContent(0, 0, lblOne);


			IButton btnClose = Core.BaitAndSwitch.Create<IButton>();
			btnClose.Text = "Close";
			btnClose.Name = "btnClose";
			btnClose.CssClass = "container";
			btnClose.Click += btnClose_Click;
			grid.SetContent(1, 0, btnClose);

			Page.Title = "Choose one control to test";
			Page.Content = grid;


			CSS.Style style = new CSS.Style();
			style.Parse(
			@"
			.alert
			{
				font-weight: bold;
				font-size: 20px;
				color: red;
			}

			.container
			{
				text-align: center;
				line-height: 100%;
				font-family: Arial;
			}

			#lblOne
			{
				margin: 20px;
				color: blue;
			}

			#btnClose
			{
				text-align: center;
				height: 30px;
			}
			");

			style.Apply(Page);
		}

		/// <summary>
		/// It is the button click event cmd Color, what it does is change the background color of the stack.
		/// <para xml:lang="es">
		/// Es el evento clic del boton cmdColor, lo que hace es cambiar el color de fondo del stack.
		/// </para>
		/// </summary>
		/// <returns>The set color click.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		/// 

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}

	}
}
