using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Test
{
    class CalcularSueldoController : Controller
    {
        ITextBox txtNombre;
        ITextBox txtSueldoHora;
        ITextBox txtHorasTrabajadas;
        ITextBox txtHorasExtra;

        ITextBox txtSueldo;
        ITextBox txtImpuesto;
        ITextBox txtSueldoNeto;

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
            ILabel lblDatos = Core.BaitAndSwitch.Create<ILabel>();
            lblDatos.Text = "Datos";
            lblDatos.Width = 30;
            grid.SetContent(0, 0, lblDatos);

            //lblNombre
            ILabel lblNombre = Core.BaitAndSwitch.Create<ILabel>();
            lblNombre.Text = "Nombre";
            lblNombre.FontSize = 20;
            grid.SetContent(1, 0, lblNombre);

            //txtNombre
            txtNombre = Core.BaitAndSwitch.Create<ITextBox>();
            txtNombre.Value = "";
            txtNombre.FontSize = 20;
            txtNombre.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(1, 1, txtNombre);

            //lblSueldoHora
            ILabel lblSueldoHora = Core.BaitAndSwitch.Create<ILabel>();
            lblSueldoHora.Text = "Sueldo por Hora";
            lblSueldoHora.FontSize = 20;
            grid.SetContent(2, 0, lblSueldoHora);

            //txtSueldoHora
            txtSueldoHora = Core.BaitAndSwitch.Create<ITextBox>();
            txtSueldoHora.Value = "";
            txtSueldoHora.FontSize = 20;
            txtSueldoHora.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(2, 1, txtSueldoHora);

            //lblHorasTrabajadas
            ILabel lblHorasTrabajadas = Core.BaitAndSwitch.Create<ILabel>();
            lblHorasTrabajadas.Text = "Horas Trabajadas";
            lblHorasTrabajadas.FontSize = 20;
            grid.SetContent(3, 0, lblHorasTrabajadas);

            //txtHorasTrabajadas
            txtHorasTrabajadas = Core.BaitAndSwitch.Create<ITextBox>();
            txtHorasTrabajadas.Value = "";
            txtHorasTrabajadas.FontSize = 20;
            txtHorasTrabajadas.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(3, 1, txtHorasTrabajadas);

            //lblHorasExtras
            ILabel lblHorasExtras = Core.BaitAndSwitch.Create<ILabel>();
            lblHorasExtras.Text = "Horas Extras";
            lblHorasExtras.FontSize = 20;
            grid.SetContent(4, 0, lblHorasExtras);

            //txtHorasExtras
            txtHorasExtra = Core.BaitAndSwitch.Create<ITextBox>();
            txtHorasExtra.Value = "";
            txtHorasExtra.FontSize = 20;
            txtHorasExtra.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(4, 1, txtHorasExtra);

            //lblResultado
            ILabel lblResultado = Core.BaitAndSwitch.Create<ILabel>();
            lblResultado.Text = "Resultado";
            lblResultado.FontSize = 20;
            grid.SetContent(6, 0, lblResultado);

            //lblSueldo
            ILabel lblSueldo = Core.BaitAndSwitch.Create<ILabel>();
            lblSueldo.Text = "Sueldo";
            lblSueldo.FontSize = 20;
            grid.SetContent(7, 0, lblSueldo);

            //txtSueldo
            txtSueldo = Core.BaitAndSwitch.Create<ITextBox>();
            txtSueldo.Value = "";
            txtSueldo.FontSize = 20;
            txtSueldo.Enabled = false;
            txtSueldo.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(7, 1, txtSueldo);

            //lblImpuesto
            ILabel lblImpuesto = Core.BaitAndSwitch.Create<ILabel>();
            lblImpuesto.Text = "Impuesto";
            lblImpuesto.FontSize = 20;
            grid.SetContent(8, 0, lblImpuesto);

            //txtImpuesto
            txtImpuesto = Core.BaitAndSwitch.Create<ITextBox>();
            txtImpuesto.Value = "";
            txtImpuesto.FontSize = 20;
            txtImpuesto.Enabled = false;
            txtImpuesto.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(8, 1, txtImpuesto);

            //lblSueldoNeto
            ILabel lblSueldoNeto = Core.BaitAndSwitch.Create<ILabel>();
            lblSueldoNeto.Text = "Sueldo Neto";
            lblSueldoNeto.FontSize = 20;
            grid.SetContent(9, 0, lblSueldoNeto);

            //txtSueldoNeto
            txtSueldoNeto = Core.BaitAndSwitch.Create<ITextBox>();
            txtSueldoNeto.Value = "";
            txtSueldoNeto.FontSize = 20;
            txtSueldoNeto.Enabled = false;
            txtSueldoNeto.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(9, 1, txtSueldoNeto);

            //btnCalcular
            IButton btnCalcular = Core.BaitAndSwitch.Create<IButton>();
            btnCalcular.Text = "Calcular";
            btnCalcular.FontSize = 20;
            btnCalcular.Click += btnCalcular_Click;
            grid.SetContent(7, 2, btnCalcular);

            //btnLimpiar
            IButton btnLimpiar = Core.BaitAndSwitch.Create<IButton>();
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.FontSize = 20;
            btnLimpiar.Click += btnLimpiar_Click;
            grid.SetContent(8, 2, btnLimpiar);

            //btnSalir
            IButton btnSalir = Core.BaitAndSwitch.Create<IButton>();
            btnSalir.Text = "Salir";
            btnSalir.FontSize = 20;
            btnSalir.Click += btnSalir_Click;
            grid.SetContent(9, 2, btnSalir);

            // Establishes the content and title of the page.
            Page.Title = "Test Sueldo";
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

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            double sueldo = (double.Parse(txtHorasTrabajadas.Value) * double.Parse(txtSueldoHora.Value)) + (double.Parse(txtHorasExtra.Value) * (double.Parse(txtSueldoHora.Value) * 2));
            double impuesto = sueldo * 0.15;
            double sueldoNeto = sueldo - impuesto;

            txtSueldo.Value = sueldo.ToString();
            txtImpuesto.Value = impuesto.ToString();
            txtSueldoNeto.Value = sueldoNeto.ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            string limpiar = " ";
            txtNombre.Value = limpiar;
            txtSueldoHora.Value = limpiar;
            txtHorasTrabajadas.Value = limpiar;
            txtHorasExtra.Value = limpiar;
            txtSueldo.Value = limpiar;
            txtImpuesto.Value = limpiar;
            txtSueldoNeto.Value = limpiar;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Finish();
        }
    }
}
