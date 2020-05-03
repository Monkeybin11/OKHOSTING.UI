using System;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Misc
{
	/// <summary>
	/// It represents the main platform where controls are housed.
	/// <para xml:lang="es">
	/// Representa la plataforma principal donde se alojan controles.
	/// </para>
	/// </summary>
	public class IndexController: Controller 
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

			ILabelButton lblForm = Core.BaitAndSwitch.Create<ILabelButton>();
			lblForm.Text = "Form";
			lblForm.Click += (object sender, EventArgs e) => new FormController() { Page = Page }.Start();
			stack.Children.Add(lblForm);

			//calculator
			ILabelButton cmdCalculator = Core.BaitAndSwitch.Create<ILabelButton>();
			cmdCalculator.Text = "Calculator with CSS";
			cmdCalculator.Click += (object sender, EventArgs e) => new CalculatorController() { Page = Page }.Start();
			stack.Children.Add(cmdCalculator);

			ILabelButton CalcularEdad = Core.BaitAndSwitch.Create<ILabelButton>();
			CalcularEdad.Text = "Calculate age";
			CalcularEdad.Click += (object sender, EventArgs e) => new CalculateAgeController() { Page = Page }.Start();
			stack.Children.Add(CalcularEdad);

			//AnalizeString
			ILabelButton AnalizeString = Core.BaitAndSwitch.Create<ILabelButton>();
			AnalizeString.Text = "Analize String";
			AnalizeString.Click += (object sender, EventArgs e) => new AnalizeStringController() { Page = Page }.Start();
			stack.Children.Add(AnalizeString);

			ILabelButton dragDrop = Core.BaitAndSwitch.Create<ILabelButton>();
			dragDrop.Text = "Drag and drop";
			dragDrop.Click += (object sender, EventArgs e) => new DragDropController() { Page = Page }.Start();
			stack.Children.Add(dragDrop);

			// Establishes the content and title of the page.
			Page.Title = "Choose one control/feature to test";
			Page.Content = stack;
		}
	}
}