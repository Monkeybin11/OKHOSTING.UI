using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Test
{
    class AnalizarCadenaController : Controller
    {
        //Variables de entrada
        ITextBox txtCadena;

        //Variables de saldia
        ITextBox txtLetras;
        ITextBox txtNumeros;
        ITextBox txtVocales;
        ITextBox txtMayusculas;
        ITextBox txtMinusculas;

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

            //lblCadena
            ILabel lblCadena = Core.BaitAndSwitch.Create<ILabel>();
            lblCadena.Text = "Cadena";
            grid.SetContent(0, 0, lblCadena);

            //txtCadena
            txtCadena = Core.BaitAndSwitch.Create<ITextBox>();
            txtCadena.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(0, 1, txtCadena);

            //lblLetras
            ILabel lblLetras = Core.BaitAndSwitch.Create<ILabel>();
            lblLetras.Text = "Cantidad de Letras";
            grid.SetContent(1, 0, lblLetras);

            //txtLetras
            txtLetras = Core.BaitAndSwitch.Create<ITextBox>();
            txtLetras.Enabled = false;
            txtLetras.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(1, 1, txtLetras);

            //lblNumeros
            ILabel lblNumeros = Core.BaitAndSwitch.Create<ILabel>();
            lblNumeros.Text = "Cantidad de Números";
            grid.SetContent(2, 0, lblNumeros);

            //txtNumeros
            txtNumeros = Core.BaitAndSwitch.Create<ITextBox>();
            txtNumeros.Enabled = false;
            txtNumeros.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(2, 1, txtNumeros);

            //lblVocales
            ILabel lblVocales = Core.BaitAndSwitch.Create<ILabel>();
            lblVocales.Text = "Cantidad de Vocales";
            grid.SetContent(3, 0, lblVocales);

            //txtVocales
            txtVocales = Core.BaitAndSwitch.Create<ITextBox>();
            txtVocales.Enabled = false;
            txtVocales.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(3, 1, txtVocales);

            //lblMayusculas
            ILabel lblMayusculas = Core.BaitAndSwitch.Create<ILabel>();
            lblMayusculas.Text = "Cantidad de Mayusculas";
            grid.SetContent(4, 0, lblMayusculas);

            //txtMayusculas
            txtMayusculas = Core.BaitAndSwitch.Create<ITextBox>();
            txtMayusculas.Enabled = false;
            txtMayusculas.BorderWidth = new Thickness(1, 2, 3, 4);
            grid.SetContent(4, 1, txtMayusculas);

            //lblMinusculas
            ILabel lblMinusculas = Core.BaitAndSwitch.Create<ILabel>();
            lblMinusculas.Text = "Cantidad de Minusculas";
            grid.SetContent(5, 0, lblMinusculas);

            //txtMinusculas
            txtMinusculas = Core.BaitAndSwitch.Create<ITextBox>();
            txtMinusculas.Enabled = false;
            grid.SetContent(5, 1, txtMinusculas);

            //btnBuscar
            IButton btnBuscar = Core.BaitAndSwitch.Create<IButton>();
            btnBuscar.Text = "Buscar";
            //btnBuscar.Click += btnBuscar_Click;
            grid.SetContent(7, 0, btnBuscar);

            //btnBorrar
            IButton btnBorrar = Core.BaitAndSwitch.Create<IButton>();
            btnBorrar.Text = "Borrar";
            //btnBorrar.Click += btnBorrar_Click;
            grid.SetContent(7, 1, btnBorrar);

            //btnSalir
            IButton btnSalir = Core.BaitAndSwitch.Create<IButton>();
            btnSalir.Text = "Salir";
            //btnSalir.Click += btnSalir_Click;
            grid.SetContent(7, 2, btnSalir);

            // Establishes the content and title of the page.
            Page.Title = "Test Analizar Cadena";
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

    }
}
