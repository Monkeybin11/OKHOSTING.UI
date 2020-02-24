using System;
using System.Drawing;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
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
			//Create an Grid with specified columns and rows.
			IGrid grid = Core.BaitAndSwitch.Create<IGrid>();

			grid.ColumnCount = 1;
			grid.RowCount = 26;

			// Create an LabelButton that binds us to a AutocompleteController.
			ILabelButton lblAutocomplete = Core.BaitAndSwitch.Create<ILabelButton>();
			lblAutocomplete.BackgroundColor = Color.FromArgb(150, 100, 250, 80);
			lblAutocomplete.Text = "Autocomplete";
			lblAutocomplete.Click += (object sender, EventArgs e) => new AutocompleteController() { Page = Page }.Start();
			grid.SetContent(0, 0, lblAutocomplete);

			// Create an LabelButton that binds us to a LabelController.
			ILabelButton lblLabel = Core.BaitAndSwitch.Create<ILabelButton>();
			lblLabel.Text = "Label";
			lblLabel.Click += (object sender, EventArgs e) => new LabelController() { Page = Page }.Start();
			grid.SetContent(1, 0, lblLabel);

			// Create an LabelButton that binds us to a LabelButtonController.
			ILabelButton lblLabelButton = Core.BaitAndSwitch.Create<ILabelButton>();
			lblLabelButton.Text = "Label Button";
			lblLabelButton.Click += (object sender, EventArgs e) => new LabelButtonController() { Page = Page }.Start();
			grid.SetContent(2, 0, lblLabelButton);

			// Create an LabelButton that binds us to a ButtonController.
			ILabelButton lblButton = Core.BaitAndSwitch.Create<ILabelButton>();
			lblButton.Text = "Button";
			lblButton.Click += (object sender, EventArgs e) => new ButtonController() { Page = Page }.Start();
			grid.SetContent(3, 0, lblButton);

			// Create an LabelButton that binds us to a HyperLinkController.
			ILabelButton lblHyperLink = Core.BaitAndSwitch.Create<ILabelButton>();
			lblHyperLink.Text = "HyperLink";
			lblHyperLink.Click += (object sender, EventArgs e) => new HyperLinkController() { Page = Page }.Start();
			grid.SetContent(4, 0, lblHyperLink);

			// Create an LabelButton that binds us to a CheckboxControler.
			ILabelButton lblCheckbox = Core.BaitAndSwitch.Create<ILabelButton>();
			lblCheckbox.Text = "Checkbox";
			lblCheckbox.Click += (object sender, EventArgs e) => new CheckboxController() { Page = Page }.Start();
			grid.SetContent(5, 0, lblCheckbox);

			// Create an LabelButton that binds us to a ImageController.
			ILabelButton lblImage = Core.BaitAndSwitch.Create<ILabelButton>();
			lblImage.Text = "Image";
			lblImage.Click += (object sender, EventArgs e) => new ImageController() { Page = Page }.Start();
			grid.SetContent(6, 0, lblImage);

			// Create an LabelButton that binds us to a ImageButtonController.
			ILabelButton lblImageButton = Core.BaitAndSwitch.Create<ILabelButton>();
			lblImageButton.Text = "ImageButton";
			lblImageButton.Click += (object sender, EventArgs e) => new ImageButtonController() { Page = Page }.Start();
			grid.SetContent(7, 0, lblImageButton);

			// Create an LabelButton that binds us to a PasswordTextBoxControler.
			ILabelButton lblPasswordBox = Core.BaitAndSwitch.Create<ILabelButton>();
			lblPasswordBox.Text = "PasswordBox";
			lblPasswordBox.Click += (object sender, EventArgs e) => new PasswordTextBoxControler() { Page = Page }.Start();
			grid.SetContent(8, 0, lblPasswordBox);

			// Create an LabelButton that binds us to a CalendarController.
			ILabelButton lblCalendar = Core.BaitAndSwitch.Create<ILabelButton>();
			lblCalendar.Text = "Calendar";
			lblCalendar.Click += (object sender, EventArgs e) => new CalendarController() { Page = Page }.Start();
			grid.SetContent(9, 0, lblCalendar);

			// Create an LabelButton that binds us to a TextAreaController.
			ILabelButton lblTextBox = Core.BaitAndSwitch.Create<ILabelButton>();
			lblTextBox.Text = "TextBox";
			lblTextBox.Click += (object sender, EventArgs e) => new TextBoxController() { Page = Page }.Start();
			grid.SetContent(10, 0, lblTextBox);

			// Create an LabelButton that binds us to a TextAreaController.
			ILabelButton lblTextArea = Core.BaitAndSwitch.Create<ILabelButton>();
			lblTextArea.Text = "TextArea";
			lblTextArea.Click += (object sender, EventArgs e) => new TextAreaController() { Page = Page }.Start();
			grid.SetContent(11, 0, lblTextArea);

			// Create an LabelButton that binds us to a ListPickerController.
			ILabelButton lblpkr = Core.BaitAndSwitch.Create<ILabelButton>();
			lblpkr.Text = "List_Picker";
			lblpkr.Click += (object sender, EventArgs e) => new ListPickerController() { Page = Page }.Start();
			grid.SetContent(12, 0, lblpkr);

			// Create an LabelButton that binds us to a RelativePanelController.
			ILabelButton lblRelativePanel = Core.BaitAndSwitch.Create<ILabelButton>();
			lblRelativePanel.Text = "RelativePanel";
			lblRelativePanel.Click += (object sender, EventArgs e) => new RelativePanelController() { Page = Page }.Start();
			grid.SetContent(13, 0, lblRelativePanel);

			// Create an LabelButton that binds us to a FormController.
			ILabelButton lblForm = Core.BaitAndSwitch.Create<ILabelButton>();
			lblForm.Text = "Form";
			lblForm.Click += (object sender, EventArgs e) => new FormController() { Page = Page }.Start();
			grid.SetContent(14, 0, lblForm);

			// Create an LabelButton that binds us to a FormController.
			ILabelButton lblDatePicker = Core.BaitAndSwitch.Create<ILabelButton>();
			lblDatePicker.Text = "DatePicker";
			lblDatePicker.Click += (object sender, EventArgs e) => new DatePickerController() { Page = Page }.Start();
			grid.SetContent(15, 0, lblDatePicker);

			// Create an LabelButton that binds us to a FormController.
			ILabelButton lblTimePicker = Core.BaitAndSwitch.Create<ILabelButton>();
			lblTimePicker.Text = "TimePicker";
			lblTimePicker.Click += (object sender, EventArgs e) => new TimePickerController() { Page = Page }.Start();
			lblTimePicker.Name = "label1";
			grid.SetContent(16, 0, lblTimePicker);

			//calculator
			ILabelButton cmdCalculator = Core.BaitAndSwitch.Create<ILabelButton>();
			cmdCalculator.Text = "Calculator with CSS";
			cmdCalculator.Click += (object sender, EventArgs e) => new CalculatorController() { Page = Page }.Start();
			grid.SetContent(17, 0, cmdCalculator);

			//Otro Controlador
			ILabelButton CalcularEdad = Core.BaitAndSwitch.Create<ILabelButton>();
			CalcularEdad.Text = "Calculate age";
			CalcularEdad.Click += (object sender, EventArgs e) => new CalculateAgeController() { Page = Page }.Start();
			grid.SetContent(18, 0, CalcularEdad);

			//AnalizeString
			ILabelButton AnalizeString = Core.BaitAndSwitch.Create<ILabelButton>();
			AnalizeString.Text = "Analize String";
			AnalizeString.Click += (object sender, EventArgs e) => new AnalizeStringController() { Page = Page }.Start();
			grid.SetContent(19, 0, AnalizeString);

			//CSSController
			ILabelButton cssController = Core.BaitAndSwitch.Create<ILabelButton>();
			cssController.Text = "CSS Controller";
			cssController.Click += (object sender, EventArgs e) => new CssController() { Page = Page }.Start();
			grid.SetContent(20, 0, cssController);

			//even or odd test
			//ILabelButton EvenOrOddController = Core.BaitAndSwitch.Create<ILabelButton>();
			//EvenOrOddController.Text = "Even or Odd";
			//EvenOrOddController.Click += (object sender, EventArgs e) => new EvenOrOddTest() { Page = Page }.Start();
			//grid.SetContent(21, 0, EvenOrOddController);

			//Test Grid Make Responsive
			ILabelButton GridMakeResponsive = Core.BaitAndSwitch.Create<ILabelButton>();
			GridMakeResponsive.Text = "Grid Make Responsive";
			GridMakeResponsive.Click += (object sender, EventArgs e) => new GridMakeResponsive() { Page = Page }.Start();
			grid.SetContent(22, 0, GridMakeResponsive);

			ILabelButton URLCssGrid = Core.BaitAndSwitch.Create<ILabelButton>();
			URLCssGrid.Text = "URL CssGrid Click Mee";
			URLCssGrid.Click += (object sender, EventArgs e) => new CssGrid() { Page = Page }.Start();
			grid.SetContent(23, 0, URLCssGrid);

			ILabelButton ArrobaMedia = Core.BaitAndSwitch.Create<ILabelButton>();
			ArrobaMedia.Text = "@media controller";
			ArrobaMedia.Click += (object sender, EventArgs e) => new ArrobaMediaController() { Page = Page }.Start();
			grid.SetContent(24, 0, ArrobaMedia);

			ILabelButton ManyControladores = Core.BaitAndSwitch.Create<ILabelButton>();
			ManyControladores.Text = "Varios Controladores";
			ManyControladores.Click += (object sender, EventArgs e) => new MenuRules () { Page = Page }.Start();
			grid.SetContent(25, 0, ManyControladores);


			// Establishes the content and title of the page.
			Page.Title = "Choose one control to test";
            Page.Content = grid;
        }
    }
}