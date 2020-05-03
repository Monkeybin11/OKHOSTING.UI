using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Test.Misc
{
	class CalculateSalaryController : Controller
	{
		ITextBox txtName;
		ITextBox txtHourSalary;
		ITextBox txtWorkHours;
		ITextBox txtExtraHours;

		ITextBox txtSalary;
		ITextBox txtTaxes;
		ITextBox txtNetSalary;

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
			grid.RowCount = 13;

			//LabelDatos
			ILabel lblDates = Core.BaitAndSwitch.Create<ILabel>();
			lblDates.Text = "Dates";
			lblDates.Width = 30;
			grid.SetContent(0, 0, lblDates);

			//lblName
			ILabel lblName = Core.BaitAndSwitch.Create<ILabel>();
			lblName.Text = "Name";
			lblName.FontSize = 20;
			grid.SetContent(1, 0, lblName);

			//txtName
			txtName = Core.BaitAndSwitch.Create<ITextBox>();
			txtName.Value = "";
			txtName.FontSize = 20;
			txtName.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(1, 1, txtName);

			//lblHourSalary
			ILabel lblHourSalary = Core.BaitAndSwitch.Create<ILabel>();
			lblHourSalary.Text = "Salary for hour";
			lblHourSalary.FontSize = 20;
			grid.SetContent(2, 0, lblHourSalary);

			//txtHourSalary
			txtHourSalary = Core.BaitAndSwitch.Create<ITextBox>();
			txtHourSalary.Value = "";
			txtHourSalary.FontSize = 20;
			txtHourSalary.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(2, 1, txtHourSalary);

			//lblWorkHours
			ILabel lblWorkHours = Core.BaitAndSwitch.Create<ILabel>();
			lblWorkHours.Text = "Work Hours";
			lblWorkHours.FontSize = 20;
			grid.SetContent(3, 0, lblWorkHours);

			//txtWorkHours
			txtWorkHours = Core.BaitAndSwitch.Create<ITextBox>();
			txtWorkHours.Value = "";
			txtWorkHours.FontSize = 20;
			txtWorkHours.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(3, 1, txtWorkHours);

			//lblExtraHours
			ILabel lblExtraHours = Core.BaitAndSwitch.Create<ILabel>();
			lblExtraHours.Text = "Extra Hours";
			lblExtraHours.FontSize = 20;
			grid.SetContent(4, 0, lblExtraHours);

			//txtExtraHours
			txtExtraHours = Core.BaitAndSwitch.Create<ITextBox>();
			txtExtraHours.Value = "";
			txtExtraHours.FontSize = 20;
			txtExtraHours.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(4, 1, txtExtraHours);

			//lblResultado
			ILabel lblResultado = Core.BaitAndSwitch.Create<ILabel>();
			lblResultado.Text = "Result";
			lblResultado.FontSize = 20;
			grid.SetContent(6, 0, lblResultado);

			//lblSalary
			ILabel lblSalary = Core.BaitAndSwitch.Create<ILabel>();
			lblSalary.Text = "Salary";
			lblSalary.FontSize = 20;
			grid.SetContent(7, 0, lblSalary);

			//txtSalary
			txtSalary = Core.BaitAndSwitch.Create<ITextBox>();
			txtSalary.Value = "";
			txtSalary.FontSize = 20;
			txtSalary.Enabled = false;
			txtSalary.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(7, 1, txtSalary);

			//lblTaxes
			ILabel lblTaxes = Core.BaitAndSwitch.Create<ILabel>();
			lblTaxes.Text = "Taxes";
			lblTaxes.FontSize = 20;
			grid.SetContent(8, 0, lblTaxes);

			//txtTaxes
			txtTaxes = Core.BaitAndSwitch.Create<ITextBox>();
			txtTaxes.Value = "";
			txtTaxes.FontSize = 20;
			txtTaxes.Enabled = false;
			txtTaxes.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(8, 1, txtTaxes);

			//lblNetSalary
			ILabel lblNetSalary = Core.BaitAndSwitch.Create<ILabel>();
			lblNetSalary.Text = "Net Salary";
			lblNetSalary.FontSize = 20;
			grid.SetContent(9, 0, lblNetSalary);

			//txtNetSalary
			txtNetSalary = Core.BaitAndSwitch.Create<ITextBox>();
			txtNetSalary.Value = "";
			txtNetSalary.FontSize = 20;
			txtNetSalary.Enabled = false;
			txtNetSalary.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(9, 1, txtNetSalary);

			//btnCalcular
			IButton btnCalcular = Core.BaitAndSwitch.Create<IButton>();
			btnCalcular.Text = "Calculate";
			btnCalcular.FontSize = 20;
			btnCalcular.Click += btnCalculate_Click;
			grid.SetContent(7, 2, btnCalcular);

			//btnLimpiar
			IButton btnLimpiar = Core.BaitAndSwitch.Create<IButton>();
			btnLimpiar.Text = "Clean";
			btnLimpiar.FontSize = 20;
			btnLimpiar.Click += btnClean_Click;
			grid.SetContent(8, 2, btnLimpiar);

			//btnSalir
			IButton btnClose = Core.BaitAndSwitch.Create<IButton>();
			btnClose.Text = "Close";
			btnClose.FontSize = 20;
			btnClose.Click += btnClose_Click;
			grid.SetContent(9, 2, btnClose);

			// Establishes the content and title of the page.
			Page.Title = "Salary Test";
			Page.Content = grid;
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

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			double salary = (double.Parse(txtWorkHours.Value) * double.Parse(txtHourSalary.Value)) + (double.Parse(txtExtraHours.Value) * (double.Parse(txtHourSalary.Value) * 2));
			double taxes = salary * 0.15;
			double netSalary = salary - taxes;

			txtSalary.Value = salary.ToString();
			txtTaxes.Value = taxes.ToString();
			txtNetSalary.Value = netSalary.ToString();
		}

		private void btnClean_Click(object sender, EventArgs e)
		{
			string limpiar = " ";
			txtName.Value = limpiar;
			txtHourSalary.Value = limpiar;
			txtWorkHours.Value = limpiar;
			txtExtraHours.Value = limpiar;
			txtSalary.Value = limpiar;
			txtTaxes.Value = limpiar;
			txtNetSalary.Value = limpiar;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}
	}
}
