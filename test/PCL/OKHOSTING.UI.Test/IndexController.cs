using System;
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
		/// <para xml:lang="es">
		/// Inicia la instancia de este objeto.
		/// </para>
		/// </summary>
		public override void Start()
		{
			base.Start();

            //Create an Grid with specified columns and rows.
            IGrid grid = App.Create<IGrid>();

			grid.ColumnCount = 1;
			grid.RowCount = 18;

			// Create an LabelButton that binds us to a AutocompleteController.
			ILabelButton lblAutocomplete = App.Create<ILabelButton>();
			lblAutocomplete.BackgroundColor = new Color(150, 100, 250, 80);
			lblAutocomplete.Text = "Autocomplete";
			lblAutocomplete.Click += (object sender, EventArgs e) => new AutocompleteController().Start();
			grid.SetContent(0, 0, lblAutocomplete);

			// Create an LabelButton that binds us to a LabelController.
			ILabelButton lblLabel = App.Create<ILabelButton>();
			lblLabel.Text = "Label";
			lblLabel.Click += (object sender, EventArgs e) => new LabelController().Start();
			grid.SetContent(1, 0, lblLabel);

			// Create an LabelButton that binds us to a LabelButtonController.
			ILabelButton lblLabelButton = App.Create<ILabelButton>();
			lblLabelButton.Text = "Label Button";
			lblLabelButton.Click += (object sender, EventArgs e) => new LabelButtonController().Start();
			grid.SetContent(2, 0, lblLabelButton);

			// Create an LabelButton that binds us to a ButtonController.
			ILabelButton lblButton = App.Create<ILabelButton>();
			lblButton.Text = "Button";
			lblButton.Click += (object sender, EventArgs e) => new ButtonController().Start();
			grid.SetContent(3, 0, lblButton);

			// Create an LabelButton that binds us to a HyperLinkController.
			ILabelButton lblHyperLink = App.Create<ILabelButton>();
			lblHyperLink.Text = "HyperLink";
			lblHyperLink.Click += (object sender, EventArgs e) => new HyperLinkController().Start();
			grid.SetContent(4, 0, lblHyperLink);

			// Create an LabelButton that binds us to a CheckboxControler.
			ILabelButton lblCheckbox = App.Create<ILabelButton>();
			lblCheckbox.Text = "Checkbox";
			lblCheckbox.Click += (object sender, EventArgs e) => new CheckboxController().Start();
			grid.SetContent(5, 0, lblCheckbox);

			// Create an LabelButton that binds us to a ImageController.
			ILabelButton lblImage = App.Create<ILabelButton>();
			lblImage.Text = "Image";
			lblImage.Click += (object sender, EventArgs e) => new ImageController().Start();
			grid.SetContent(6, 0, lblImage);

			// Create an LabelButton that binds us to a ImageButtonController.
			ILabelButton lblImageButton = App.Create<ILabelButton>();
			lblImageButton.Text = "ImageButton";
			lblImageButton.Click += (object sender, EventArgs e) => new ImageButtonController().Start();
			grid.SetContent(7, 0, lblImageButton);

			// Create an LabelButton that binds us to a PasswordTextBoxControler.
			ILabelButton lblPasswordBox = App.Create<ILabelButton>();
			lblPasswordBox.Text = "PasswordBox";
			lblPasswordBox.Click += (object sender, EventArgs e) => new PasswordTextBoxControler().Start();
			grid.SetContent(8, 0, lblPasswordBox);

			// Create an LabelButton that binds us to a CalendarController.
			ILabelButton lblCalendar = App.Create<ILabelButton>();
			lblCalendar.Text = "Calendar";
			lblCalendar.Click += (object sender, EventArgs e) => new CalendarController().Start();
			grid.SetContent(9, 0, lblCalendar);

			// Create an LabelButton that binds us to a TextAreaController.
			ILabelButton lblTextBox = App.Create<ILabelButton>();
			lblTextBox.Text = "TextBox";
			lblTextBox.Click += (object sender, EventArgs e) => new TextBoxController().Start();
			grid.SetContent(10, 0, lblTextBox);

			// Create an LabelButton that binds us to a TextAreaController.
			ILabelButton lblTextArea = App.Create<ILabelButton>();
			lblTextArea.Text = "TextArea";
			lblTextArea.Click += (object sender, EventArgs e) => new TextAreaController().Start();
			grid.SetContent(11, 0, lblTextArea);

			// Create an LabelButton that binds us to a ListPickerController.
			ILabelButton lblpkr = App.Create<ILabelButton>();
			lblpkr.Text = "List_Picker";
			lblpkr.Click += (object sender, EventArgs e) => new ListPickerController().Start();
			grid.SetContent(12, 0, lblpkr);

			// Create an LabelButton that binds us to a RelativePanelController.
			ILabelButton lblRelativePanel = App.Create<ILabelButton>();
			lblRelativePanel.Text = "RelativePanel";
			lblRelativePanel.Click += (object sender, EventArgs e) => new RelativePanelController().Start();
			grid.SetContent(13, 0, lblRelativePanel);

			// Create an LabelButton that binds us to a FormController.
			ILabelButton lblForm = App.Create<ILabelButton>();
			lblForm.Text = "Form";
			lblForm.Click += (object sender, EventArgs e) => new FormController().Start();
			grid.SetContent(14, 0, lblForm);

			// Create an LabelButton that binds us to a FormController.
			ILabelButton lblDatePicker = App.Create<ILabelButton>();
			lblDatePicker.Text = "DatePicker";
			lblDatePicker.Click += (object sender, EventArgs e) => new DatePickerController().Start();
			grid.SetContent(15, 0, lblDatePicker);

			// Create an LabelButton that binds us to a FormController.
			ILabelButton lblTimePicker = App.Create<ILabelButton>();
			lblTimePicker.Text = "TimePicker";
			lblTimePicker.Click += (object sender, EventArgs e) => new TimePickerController().Start();
			grid.SetContent(16, 0, lblTimePicker);

			// Establishes the content and title of the page.
			App.Page.Title = "Choose one control to test";
			App.Page.Content = grid;
		}
	 }
}