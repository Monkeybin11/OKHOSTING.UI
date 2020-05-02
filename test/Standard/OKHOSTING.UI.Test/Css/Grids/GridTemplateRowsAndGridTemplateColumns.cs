using System;
using System.Collections.Generic;
using System.Text;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Css.Grids
{
	public class GridTemplateRowsAndGridTemplateColumns : Controller
	{
		protected override void OnStart()
		{
			IStack stackPpal = Core.BaitAndSwitch.Create<IStack>();

			IButton btnExit = Core.BaitAndSwitch.Create<IButton>();
			btnExit.Text = "Exit";
			btnExit.Click += btnExit_Click;
			stackPpal.Children.Add(btnExit);

			//****************** grid-template-rows ******************
			ILabel lblGridTemplateRows = Core.BaitAndSwitch.Create<ILabel>();
			lblGridTemplateRows.Text = "****************** grid-template-rows ******************";
			stackPpal.Children.Add(lblGridTemplateRows);

			IGrid gridTemplateRows = Core.BaitAndSwitch.Create<IGrid>();
			gridTemplateRows.ColumnCount = 3;
			gridTemplateRows.RowCount = 13;
			gridTemplateRows.Name = "gridTemplateRows";
			stackPpal.Children.Add(gridTemplateRows);

			//LabelDatos
			ILabel lblDatesR = Core.BaitAndSwitch.Create<ILabel>();
			lblDatesR.Text = "Dates";
			lblDatesR.Width = 30;
			gridTemplateRows.SetContent(0, 0, lblDatesR);

			//lblName
			ILabel lblNameR = Core.BaitAndSwitch.Create<ILabel>();
			lblNameR.Text = "Name";
			lblNameR.FontSize = 20;
			gridTemplateRows.SetContent(1, 0, lblNameR);

			//txtName
			ITextBox txtNameR = Core.BaitAndSwitch.Create<ITextBox>();
			txtNameR.Value = "";
			txtNameR.FontSize = 20;
			gridTemplateRows.SetContent(1, 1, txtNameR);

			//lblHourSalary
			ILabel lblHourSalaryR = Core.BaitAndSwitch.Create<ILabel>();
			lblHourSalaryR.Text = "Salary for hour";
			lblHourSalaryR.FontSize = 20;
			gridTemplateRows.SetContent(2, 0, lblHourSalaryR);

			//txtHourSalary
			ITextBox txtHourSalaryR = Core.BaitAndSwitch.Create<ITextBox>();
			txtHourSalaryR.Value = "";
			txtHourSalaryR.FontSize = 20;
			gridTemplateRows.SetContent(2, 1, txtHourSalaryR);

			//lblWorkHours
			ILabel lblWorkHoursR = Core.BaitAndSwitch.Create<ILabel>();
			lblWorkHoursR.Text = "Work Hours";
			lblWorkHoursR.FontSize = 20;
			gridTemplateRows.SetContent(3, 0, lblWorkHoursR);

			//txtWorkHours
			ITextBox txtWorkHoursR = Core.BaitAndSwitch.Create<ITextBox>();
			txtWorkHoursR.Value = "";
			txtWorkHoursR.FontSize = 20;
			gridTemplateRows.SetContent(3, 1, txtWorkHoursR);

			//lblExtraHours
			ILabel lblExtraHoursR = Core.BaitAndSwitch.Create<ILabel>();
			lblExtraHoursR.Text = "Extra Hours";
			lblExtraHoursR.FontSize = 20;
			gridTemplateRows.SetContent(4, 0, lblExtraHoursR);

			//txtExtraHours
			ITextBox txtExtraHoursR = Core.BaitAndSwitch.Create<ITextBox>();
			txtExtraHoursR.Value = "";
			txtExtraHoursR.FontSize = 20;
			gridTemplateRows.SetContent(4, 1, txtExtraHoursR);

			//lblResultado
			ILabel lblResultadoR = Core.BaitAndSwitch.Create<ILabel>();
			lblResultadoR.Text = "Result";
			lblResultadoR.FontSize = 20;
			gridTemplateRows.SetContent(6, 0, lblResultadoR);

			//lblSalary
			ILabel lblSalaryR = Core.BaitAndSwitch.Create<ILabel>();
			lblSalaryR.Text = "Salary";
			lblSalaryR.FontSize = 20;
			gridTemplateRows.SetContent(7, 0, lblSalaryR);

			//txtSalary
			ITextBox txtSalaryR = Core.BaitAndSwitch.Create<ITextBox>();
			txtSalaryR.Value = "";
			txtSalaryR.FontSize = 20;
			txtSalaryR.Enabled = false;
			gridTemplateRows.SetContent(7, 1, txtSalaryR);

			//lblTaxes
			ILabel lblTaxesR = Core.BaitAndSwitch.Create<ILabel>();
			lblTaxesR.Text = "Taxes";
			lblTaxesR.FontSize = 20;
			gridTemplateRows.SetContent(8, 0, lblTaxesR);

			//txtTaxes
			ITextBox txtTaxesR = Core.BaitAndSwitch.Create<ITextBox>();
			txtTaxesR.Value = "";
			txtTaxesR.FontSize = 20;
			txtTaxesR.Enabled = false;
			gridTemplateRows.SetContent(8, 1, txtTaxesR);

			//lblNetSalary
			ILabel lblNetSalaryR = Core.BaitAndSwitch.Create<ILabel>();
			lblNetSalaryR.Text = "Net Salary";
			lblNetSalaryR.FontSize = 20;
			gridTemplateRows.SetContent(9, 0, lblNetSalaryR);

			//txtNetSalary
			ITextBox txtNetSalaryR = Core.BaitAndSwitch.Create<ITextBox>();
			txtNetSalaryR.Value = "";
			txtNetSalaryR.FontSize = 20;
			txtNetSalaryR.Enabled = false;
			gridTemplateRows.SetContent(9, 1, txtNetSalaryR);

			//btnCalcular
			IButton btnCalcularR = Core.BaitAndSwitch.Create<IButton>();
			btnCalcularR.Text = "Calculate";
			btnCalcularR.FontSize = 20;
			gridTemplateRows.SetContent(7, 2, btnCalcularR);

			//btnLimpiar
			IButton btnLimpiarR = Core.BaitAndSwitch.Create<IButton>();
			btnLimpiarR.Text = "Clean";
			btnLimpiarR.FontSize = 20;
			gridTemplateRows.SetContent(8, 2, btnLimpiarR);

			//btnSalir
			IButton btnCloseR = Core.BaitAndSwitch.Create<IButton>();
			btnCloseR.Text = "Close";
			btnCloseR.FontSize = 20;
			gridTemplateRows.SetContent(9, 2, btnCloseR);

			//****************** grid-template-columns ******************
			ILabel lblGridTemplateColumns = Core.BaitAndSwitch.Create<ILabel>();
			lblGridTemplateColumns.Text = "****************** grid-template-columns ******************";
			stackPpal.Children.Add(lblGridTemplateColumns);

			IGrid gridTemplateColumns = Core.BaitAndSwitch.Create<IGrid>();
			gridTemplateColumns.ColumnCount = 3;
			gridTemplateColumns.RowCount = 13;
			gridTemplateColumns.Name = "gridTemplateColumns";
			stackPpal.Children.Add(gridTemplateColumns);

			//LabelDatos
			ILabel lblDatesC = Core.BaitAndSwitch.Create<ILabel>();
			lblDatesC.Text = "Dates";
			lblDatesC.Width = 30;
			gridTemplateColumns.SetContent(0, 0, lblDatesC);

			//lblName
			ILabel lblNameC = Core.BaitAndSwitch.Create<ILabel>();
			lblNameC.Text = "Name";
			lblNameC.FontSize = 20;
			gridTemplateColumns.SetContent(1, 0, lblNameC);

			//txtName
			ITextBox txtNameC = Core.BaitAndSwitch.Create<ITextBox>();
			txtNameC.Value = "";
			txtNameC.FontSize = 20;
			gridTemplateColumns.SetContent(1, 1, txtNameC);

			//lblHourSalary
			ILabel lblHourSalaryC = Core.BaitAndSwitch.Create<ILabel>();
			lblHourSalaryC.Text = "Salary for hour";
			lblHourSalaryC.FontSize = 20;
			gridTemplateColumns.SetContent(2, 0, lblHourSalaryC);

			//txtHourSalary
			ITextBox txtHourSalaryC = Core.BaitAndSwitch.Create<ITextBox>();
			txtHourSalaryC.Value = "";
			txtHourSalaryC.FontSize = 20;
			gridTemplateColumns.SetContent(2, 1, txtHourSalaryC);

			//lblWorkHours
			ILabel lblWorkHours = Core.BaitAndSwitch.Create<ILabel>();
			lblWorkHours.Text = "Work Hours";
			lblWorkHours.FontSize = 20;
			gridTemplateColumns.SetContent(3, 0, lblWorkHours);

			//txtWorkHours
			ITextBox txtWorkHoursC = Core.BaitAndSwitch.Create<ITextBox>();
			txtWorkHoursC.Value = "";
			txtWorkHoursC.FontSize = 20;
			gridTemplateColumns.SetContent(3, 1, txtWorkHoursC);

			//lblExtraHours
			ILabel lblExtraHoursC = Core.BaitAndSwitch.Create<ILabel>();
			lblExtraHoursC.Text = "Extra Hours";
			lblExtraHoursC.FontSize = 20;
			gridTemplateColumns.SetContent(4, 0, lblExtraHoursC);

			//txtExtraHours
			ITextBox txtExtraHoursC = Core.BaitAndSwitch.Create<ITextBox>();
			txtExtraHoursC.Value = "";
			txtExtraHoursC.FontSize = 20;
			gridTemplateColumns.SetContent(4, 1, txtExtraHoursC);

			//lblResultado
			ILabel lblResultadoC = Core.BaitAndSwitch.Create<ILabel>();
			lblResultadoC.Text = "Result";
			lblResultadoC.FontSize = 20;
			gridTemplateColumns.SetContent(6, 0, lblResultadoC);

			//lblSalary
			ILabel lblSalaryC = Core.BaitAndSwitch.Create<ILabel>();
			lblSalaryC.Text = "Salary";
			lblSalaryC.FontSize = 20;
			gridTemplateColumns.SetContent(7, 0, lblSalaryC);

			//txtSalary
			ITextBox txtSalaryC = Core.BaitAndSwitch.Create<ITextBox>();
			txtSalaryC.Value = "";
			txtSalaryC.FontSize = 20;
			txtSalaryC.Enabled = false;
			gridTemplateColumns.SetContent(7, 1, txtSalaryC);

			//lblTaxes
			ILabel lblTaxesC = Core.BaitAndSwitch.Create<ILabel>();
			lblTaxesC.Text = "Taxes";
			lblTaxesC.FontSize = 20;
			gridTemplateColumns.SetContent(8, 0, lblTaxesC);

			//txtTaxes
			ITextBox txtTaxesC = Core.BaitAndSwitch.Create<ITextBox>();
			txtTaxesC.Value = "";
			txtTaxesC.FontSize = 20;
			txtTaxesC.Enabled = false;
			gridTemplateColumns.SetContent(8, 1, txtTaxesC);

			//lblNetSalary
			ILabel lblNetSalaryC = Core.BaitAndSwitch.Create<ILabel>();
			lblNetSalaryC.Text = "Net Salary";
			lblNetSalaryC.FontSize = 20;
			gridTemplateColumns.SetContent(9, 0, lblNetSalaryC);

			//txtNetSalary
			ITextBox txtNetSalaryC = Core.BaitAndSwitch.Create<ITextBox>();
			txtNetSalaryC.Value = "";
			txtNetSalaryC.FontSize = 20;
			txtNetSalaryC.Enabled = false;
			gridTemplateColumns.SetContent(9, 1, txtNetSalaryC);

			//btnCalcular
			IButton btnCalcularC = Core.BaitAndSwitch.Create<IButton>();
			btnCalcularC.Text = "Calculate";
			btnCalcularC.FontSize = 20;
			gridTemplateColumns.SetContent(7, 2, btnCalcularC);

			//btnLimpiar
			IButton btnLimpiarC = Core.BaitAndSwitch.Create<IButton>();
			btnLimpiarC.Text = "Clean";
			btnLimpiarC.FontSize = 20;
			gridTemplateColumns.SetContent(8, 2, btnLimpiarC);

			//btnSalir
			IButton btnCloseC = Core.BaitAndSwitch.Create<IButton>();
			btnCloseC.Text = "Close";
			btnCloseC.FontSize = 20;
			gridTemplateColumns.SetContent(9, 2, btnCloseC);

			//****************** grid-template-rows ******************
			ILabel lblGridTemplateRowsAndColumns = Core.BaitAndSwitch.Create<ILabel>();
			lblGridTemplateRowsAndColumns.Text = "****************** grid-template-rows and grid-template-columns ******************";
			stackPpal.Children.Add(lblGridTemplateRowsAndColumns);

			IGrid gridTemplateRowsAndColumns = Core.BaitAndSwitch.Create<IGrid>();
			gridTemplateRowsAndColumns.ColumnCount = 3;
			gridTemplateRowsAndColumns.RowCount = 13;
			gridTemplateRowsAndColumns.Name = "gridTemplateRowsAndColumns";
			stackPpal.Children.Add(gridTemplateRowsAndColumns);

			//LabelDatos
			ILabel lblDatesRC = Core.BaitAndSwitch.Create<ILabel>();
			lblDatesRC.Text = "Dates";
			lblDatesRC.Width = 30;
			gridTemplateRowsAndColumns.SetContent(0, 0, lblDatesRC);

			//lblName
			ILabel lblNameRC = Core.BaitAndSwitch.Create<ILabel>();
			lblNameRC.Text = "Name";
			lblNameRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(1, 0, lblNameRC);

			//txtName
			ITextBox txtNameRC = Core.BaitAndSwitch.Create<ITextBox>();
			txtNameRC.Value = "";
			txtNameRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(1, 1, txtNameRC);

			//lblHourSalary
			ILabel lblHourSalaryRC = Core.BaitAndSwitch.Create<ILabel>();
			lblHourSalaryRC.Text = "Salary for hour";
			lblHourSalaryRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(2, 0, lblHourSalaryRC);

			//txtHourSalary
			ITextBox txtHourSalaryRC = Core.BaitAndSwitch.Create<ITextBox>();
			txtHourSalaryRC.Value = "";
			txtHourSalaryRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(2, 1, txtHourSalaryRC);

			//lblWorkHours
			ILabel lblWorkHoursRC = Core.BaitAndSwitch.Create<ILabel>();
			lblWorkHoursRC.Text = "Work Hours";
			lblWorkHoursRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(3, 0, lblWorkHoursRC);

			//txtWorkHours
			ITextBox txtWorkHoursRC = Core.BaitAndSwitch.Create<ITextBox>();
			txtWorkHoursRC.Value = "";
			txtWorkHoursRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(3, 1, txtWorkHoursRC);

			//lblExtraHours
			ILabel lblExtraHoursRC = Core.BaitAndSwitch.Create<ILabel>();
			lblExtraHoursRC.Text = "Extra Hours";
			lblExtraHoursRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(4, 0, lblExtraHoursRC);

			//txtExtraHours
			ITextBox txtExtraHoursRC = Core.BaitAndSwitch.Create<ITextBox>();
			txtExtraHoursRC.Value = "";
			txtExtraHoursRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(4, 1, txtExtraHoursRC);

			//lblResultado
			ILabel lblResultadoRC = Core.BaitAndSwitch.Create<ILabel>();
			lblResultadoRC.Text = "Result";
			lblResultadoRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(6, 0, lblResultadoRC);

			//lblSalary
			ILabel lblSalaryRC = Core.BaitAndSwitch.Create<ILabel>();
			lblSalaryRC.Text = "Salary";
			lblSalaryRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(7, 0, lblSalaryRC);

			//txtSalary
			ITextBox txtSalaryRC = Core.BaitAndSwitch.Create<ITextBox>();
			txtSalaryRC.Value = "";
			txtSalaryRC.FontSize = 20;
			txtSalaryRC.Enabled = false;
			gridTemplateRowsAndColumns.SetContent(7, 1, txtSalaryRC);

			//lblTaxes
			ILabel lblTaxesRC = Core.BaitAndSwitch.Create<ILabel>();
			lblTaxesRC.Text = "Taxes";
			lblTaxesRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(8, 0, lblTaxesRC);

			//txtTaxes
			ITextBox txtTaxesRC = Core.BaitAndSwitch.Create<ITextBox>();
			txtTaxesRC.Value = "";
			txtTaxesRC.FontSize = 20;
			txtTaxesRC.Enabled = false;
			gridTemplateRowsAndColumns.SetContent(8, 1, txtTaxesRC);

			//lblNetSalary
			ILabel lblNetSalaryRC = Core.BaitAndSwitch.Create<ILabel>();
			lblNetSalaryRC.Text = "Net Salary";
			lblNetSalaryRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(9, 0, lblNetSalaryRC);

			//txtNetSalary
			ITextBox txtNetSalaryRC = Core.BaitAndSwitch.Create<ITextBox>();
			txtNetSalaryRC.Value = "";
			txtNetSalaryRC.FontSize = 20;
			txtNetSalaryRC.Enabled = false;
			gridTemplateRowsAndColumns.SetContent(9, 1, txtNetSalaryRC);

			//btnCalcular
			IButton btnCalcularRC = Core.BaitAndSwitch.Create<IButton>();
			btnCalcularRC.Text = "Calculate";
			btnCalcularRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(7, 2, btnCalcularRC);

			//btnLimpiar
			IButton btnLimpiarRC = Core.BaitAndSwitch.Create<IButton>();
			btnLimpiarRC.Text = "Clean";
			btnLimpiarRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(8, 2, btnLimpiarRC);

			//btnSalir
			IButton btnCloseRC = Core.BaitAndSwitch.Create<IButton>();
			btnCloseRC.Text = "Close";
			btnCloseRC.FontSize = 20;
			gridTemplateRowsAndColumns.SetContent(9, 2, btnCloseRC);

			Page.Title = "grid-template-rows And grid-template-columns";
			Page.Content = stackPpal;



			CSS.Style style = new CSS.Style();
			style.Parse(@"
				#gridTemplateRows
				{
					display: grid;
					grid-template-rows: 500px 200px 500px 200px 500px 200px 500px 200px 500px 200px 500px 200px 100px;
			   }
				 
				#gridTemplateColumns {
					display: grid;
					grid-template-columns: 400px 500px 200px;
				}				  
  
				#gridTemplateRowsAndColumns
				  {
				
				   display: grid;
				  grid-template-rows: 100px 200px 100px 200px 100px 200px 100px 200px 100px 200px 100px 200px 100px;
				   grid-template-columns: 300px 200px 100px;
 
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
