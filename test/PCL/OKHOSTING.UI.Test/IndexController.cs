using System;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test
{
	public class IndexController: Controller
	{
        public override void Start()
        {
            base.Start();

            IGrid grid = Platform.Current.Create<IGrid>();
            grid.ColumnCount = 1;
            grid.RowCount = 20;

            ILabelButton lblLabel = Platform.Current.Create<ILabelButton>();
            lblLabel.Text = "Radio UDG";
            lblLabel.Height = 100;
            lblLabel.Click += (object sender, EventArgs e) => new UDG().Start();
            grid.SetContent(1, 0, lblLabel);

			ILabelButton lblRelativePanel = Platform.Current.Create<ILabelButton>();
			lblLabel.Text = "RelativePanel";
			lblLabel.Height = 100;
			lblLabel.Click += (object sender, EventArgs e) => new RelativePanelController().Start();
			grid.SetContent(2, 0, lblLabel);

			/*
            ILabelButton lblAutocomplete = Platform.Current.Create<ILabelButton>();
            lblAutocomplete.Text = "Autocomplete";
            lblAutocomplete.Height = 100;
            lblAutocomplete.Click += (object sender, EventArgs e) => new AutocompleteController().Start();
            grid.SetContent(0, 0, lblAutocomplete);

            ILabelButton lblLabel = Platform.Current.Create<ILabelButton>();
            lblLabel.Text = "Label";
            lblLabel.Height = 100;
            lblLabel.Click += (object sender, EventArgs e) => new LabelController().Start();
            grid.SetContent(1, 0, lblLabel);

            ILabelButton lblLabelButton = Platform.Current.Create<ILabelButton>();
            lblLabelButton.Text = "Label Button";
            lblLabelButton.Height = 100;
            lblLabelButton.Click += (object sender, EventArgs e) => new LabelButtonController().Start();
            grid.SetContent(2, 0, lblLabelButton);

            ILabelButton lblButton = Platform.Current.Create<ILabelButton>();
            lblButton.Text = "Button";
            lblButton.Height = 100;
            lblButton.Click += (object sender, EventArgs e) => new ButtonController().Start();
            grid.SetContent(3, 0, lblButton);

            ILabelButton lblHyperLink = Platform.Current.Create<ILabelButton>();
            lblHyperLink.Text = "HyperLink";
            lblHyperLink.Height = 100;
            //lblHyperLink.Click += (object sender, EventArgs e) => new HyperLinkController().Start();
            grid.SetContent(4, 0, lblHyperLink);


            ILabelButton lblCheckbox = Platform.Current.Create<ILabelButton>();
            lblCheckbox.Text = "Checkbox";
            lblCheckbox.Height = 100;
            lblCheckbox.Click += (object sender, EventArgs e) => new CheckboxController().Start();
            grid.SetContent(5, 0, lblCheckbox);

            ILabelButton lblImage = Platform.Current.Create<ILabelButton>();
            lblImage.Text = "Image";
            lblImage.Height = 100;
            lblImage.Click += (object sender, EventArgs e) => new ImageController().Start();
            grid.SetContent(6, 0, lblImage);

            ILabelButton lblImageButton = Platform.Current.Create<ILabelButton>();
            lblImageButton.Text = "ImageButton";
            lblImageButton.Height = 100;
            lblImageButton.Click += (object sender, EventArgs e) => new ImageButtonController().Start();
            grid.SetContent(7, 0, lblImageButton);

            ILabelButton lblPasswordBox = Platform.Current.Create<ILabelButton>();
            lblPasswordBox.Text = "PasswordBox";
            lblPasswordBox.Height = 100;
            lblPasswordBox.Click += (object sender, EventArgs e) => new PasswordTextBoxControler().Start();
            grid.SetContent(8, 0, lblPasswordBox);

            ILabelButton lblCalendar = Platform.Current.Create<ILabelButton>();
            lblCalendar.Text = "Calendar";
            lblCalendar.Height = 100;
            lblCalendar.Click += (object sender, EventArgs e) => new CalendarController().Start();
            grid.SetContent(9, 0, lblCalendar);

            ILabelButton lblarea = Platform.Current.Create<ILabelButton>();
            lblarea.Text = "Text_Area";
            lblarea.Height = 100;
            lblarea.Click += (object sender, EventArgs e) => new TextAreaController().Start();
            grid.SetContent(10, 0, lblarea);

            ILabelButton lblpkr = Platform.Current.Create<ILabelButton>();
            lblpkr.Text = "List_Picker";
            lblpkr.Height = 100;
            lblpkr.Click += (object sender, EventArgs e) => new ListPickerController().Start();
            grid.SetContent(11, 0, lblpkr);
            */

			Platform.Current.Page.Title = "Choose one control to test";
			Platform.Current.Page.Content = grid;

            
		}
	}
}