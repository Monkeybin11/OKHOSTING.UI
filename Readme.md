# OKHOSTING.UI

Open source multi-platform UI framework. Create your apps once on PCL and have your UI generated on runtime for ASP.NET, Windows Forms, WPF, Linux (Mono + WinForms), Mac OS (Mono + WinForms and Xamarin.Mac), iOS, Android, Windows Phone (via Xamarin.Forms) and Windows Universal Platform.

[![Build status](https://ci.appveyor.com/api/projects/status/re4416t7tjld2d5g?svg=true)](https://ci.appveyor.com/project/okhosting/okhosting-ui)

[![Join the chat at https://gitter.im/okhosting/OKHOSTING.UI](https://badges.gitter.im/okhosting/OKHOSTING.UI.svg)](https://gitter.im/okhosting/OKHOSTING.UI?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Download 

```
PM> Install-Package OKHOSTING.UI
PM> Install-Package OKHOSTING.UI.CSS
PM> Install-Package OKHOSTING.UI.Net4.WebForms
PM> Install-Package OKHOSTING.UI.Net4.WinForms
PM> Install-Package OKHOSTING.UI.Net4.WPF
PM> Install-Package OKHOSTING.UI.UWP
PM> Install-Package OKHOSTING.UI.Xamarin.Forms
```

* [Download OKHOSTING.UI on NuGet](https://www.nuget.org/packages/OKHOSTING.UI/)
* [Download OKHOSTING.UI.CSS on NuGet](https://www.nuget.org/packages/OKHOSTING.UI.CSS/)
* [Download OKHOSTING.UI.Net4.WebForms on NuGet](https://www.nuget.org/packages/OKHOSTING.UI.Net4.WebForms/)
* [Download OKHOSTING.UI.Net4.WinForms on NuGet](https://www.nuget.org/packages/OKHOSTING.UI.Net4.WinForms/)
* [Download OKHOSTING.UI.Net4.WPF on NuGet](https://www.nuget.org/packages/OKHOSTING.UI.Net4.WPF/)
* [Download OKHOSTING.UI.UWP on NuGet](https://www.nuget.org/packages/OKHOSTING.UI.UWP/)
* [Download OKHOSTING.UI.Xamarin.Forms on NuGet](https://www.nuget.org/packages/OKHOSTING.UI.Xamarin.Forms/)

## Features

* Create your apps in PCL and run them everywhere, truly multi-platform (web included)
* The UI is defined from code (XAML designer on the way)
* 100% native controls are used in all platforms
* You have the "common" UI api surface among all platforms by default, ands it's easily extendible 
* Supports click, and for user input controls, value changed events
* Using OKHOSTING.UI.CSS you can use CSS files to define the styles of your controls (thanks to AngleSharp)

## Supported controls

### Regular controls

* Autocomplete
* Button
* Calendar
* CheckBox
* HyperLink
* Image
* Label
* ListPicker (equivalent to a DropDownList)
* PasswordTextBox
* TextArea
* TextBox

### Forms

* Create forms for user data input/output
* Create form fields for string, int, decimal, date, enum, bool, xml or any custom type you need
* Create forms to execute a method

## Examples

This examples are taken from https://github.com/okhosting/OKHOSTING.UI/tree/master/test

### Native controls

The platform uses native controls in all platforms, therefore all apps work with great performance and compatibility

### Page

A Page is an interface that is implemented as:

* A System.Web.UI.Page in ASP.NET
* A System.Windows.Window in Windows Forms
* A System.Windows.Window in WPF
* A Windows.UI.Xaml.Controls.Page in UWP
* A Xamarin.Forms.ContentPage in Xamarin Forms

You can set page properties like this:

```csharp
Page.Title = "Choose one control to test";
Page.Content = grid;
```

### Controllers

The framework uses classes called "Controllers", which work very much like an MVC controller. 
To work with the framework, you need to inherit from Controller class and override (at least) the Start() method.
For example take a look a this IndexController:

```csharp
public class IndexController: Controller
{
	protected override void OnStart()
	{
		IGrid grid = BaitAndSwitch.Create<IGrid>();
		grid.ColumnCount = 1;
		grid.RowCount = 20;

		ILabelButton lblAutocomplete = BaitAndSwitch.Create<ILabelButton>();
		lblAutocomplete.Text = "Autocomplete";
		lblAutocomplete.Click += (object sender, EventArgs e) => new AutocompleteController(Page).Start();
		grid.SetContent(0, 0, lblAutocomplete);

		ILabelButton lblLabel = BaitAndSwitch.Create<ILabelButton>();
		lblLabel.Text = "Label";
		lblLabel.Click += (object sender, EventArgs e) => new LabelController(Page).Start();
		grid.SetContent(1, 0, lblLabel);

		ILabelButton lblLabelButton = BaitAndSwitch.Create<ILabelButton>();
		lblLabelButton.Text = "Label Button";
		lblLabelButton.Click += (object sender, EventArgs e) => new LabelButtonController(Page).Start();
		grid.SetContent(2, 0, lblLabelButton);

        ILabelButton lblButton = BaitAndSwitch.Create<ILabelButton>();
        lblButton.Text = "Button";
        lblButton.Click += (object sender, EventArgs e) => new ButtonController(Page).Start();
        grid.SetContent(3, 0, lblButton);

        ILabelButton lblHyperLink = BaitAndSwitch.Create<ILabelButton>();
        lblHyperLink.Text = "HyperLink";
        //lblHyperLink.Click += (object sender, EventArgs e) => new HyperLinkController(Page).Start();
        grid.SetContent(4, 0, lblHyperLink);
            

        ILabelButton lblCheckbox = BaitAndSwitch.Create<ILabelButton>();
        lblCheckbox.Text = "Checkbox";
        lblCheckbox.Click += (object sender, EventArgs e) => new CheckboxController(Page).Start();
        grid.SetContent(5, 0, lblCheckbox);

        ILabelButton lblImage = BaitAndSwitch.Create<ILabelButton>();
        lblImage.Text = "Image";
        lblImage.Click += (object sender, EventArgs e) => new ImageController(Page).Start();
        grid.SetContent(6, 0, lblImage);

        ILabelButton lblImageButton = BaitAndSwitch.Create<ILabelButton>();
        lblImageButton.Text = "ImageButton";
        lblImageButton.Click += (object sender, EventArgs e) => new ImageButtonController(Page).Start();
        grid.SetContent(7, 0, lblImageButton);

        Page.Title = "Choose one control to test";
		Page.Content = grid;
	}
}
```

As you can see, the IndexController creates a grid, and then populates the grid with many LabelButtons. Each button has a different Text and click events,
and when you click on the LableButton with text "Button", that triggers an event that leads you to another controller named ButonController.

Also you can set the Title of the Page, and of course, the actual content of the Page.

When you dont finish a controller, and call another controller to Start(), the new controller will "take control" of the app (more acuratelly, your Page)
and will manipulate the UI. When you finish a controller, the app returns control to the previous controller in the stack, and all UI state is maitained in this cycle.

### Button

```csharp
public class ButtonController: Controller
{
    IButton cmdShow;
    ILabel lbltext;

    protected override void OnStart()
	{
		IStack stack = BaitAndSwitch.Create<IStack>();

        cmdShow = BaitAndSwitch.Create<IButton>();
        cmdShow.Text = "Show/Hide";
        cmdShow.Click += CmdShow_Click;
        cmdShow.BackgroundColor = new Color(1, 255, 0, 0);
        cmdShow.FontColor = new Color(1, 255, 255, 255);
        stack.Children.Add(cmdShow);

        lbltext = BaitAndSwitch.Create<ILabel>();
        lbltext.Text = "I'm visible, i want an ice-cream";
        lbltext.Visible = false;
			
		stack.Children.Add(lbltext);

        IButton cmdClose = BaitAndSwitch.Create<IButton>();
        cmdClose.Text = "Close";
        cmdClose.Click += CmdClose_Click;
        stack.Children.Add(cmdClose);

        Page.Title = "Test label";
		Page.Content = stack;
	}

    private void CmdShow_Click(object sender, EventArgs e)
    {
        if (lbltext.Visible == true)
        {
            lbltext.Visible = false;
        }
        else
        {
            lbltext.Visible = true;
        }
    }

    private void CmdClose_Click(object sender, EventArgs e)
    {
        this.Finish();
    }
}
```

### CheckBox

```csharp
public class CheckboxController: Controller
{
    ICheckBox cbxColor;
    ILabel lblLabel;

    protected override void OnStart()
	{
		IStack stack = BaitAndSwitch.Create<IStack>();

		lblLabel = BaitAndSwitch.Create<ILabel>();
		lblLabel.Text = "This is a label";
		lblLabel.Height = 30;
		stack.Children.Add(lblLabel);

        cbxColor = BaitAndSwitch.Create<ICheckBox>();
        cbxColor.Name = "color";
        cbxColor.Value = true;
        stack.Children.Add(cbxColor);

        IButton cmdChange = BaitAndSwitch.Create<IButton>();
        cmdChange.Text = "Change";
        cmdChange.Click += CmdChange_Click;
        stack.Children.Add(cmdChange);

        IButton cmdClose = BaitAndSwitch.Create<IButton>();
        cmdClose.Text = "Close";
        cmdClose.Click += CmdClose_Click;
        stack.Children.Add(cmdClose);

        Page.Title = "Test label";
		Page.Content = stack;
	}

    private void CmdChange_Click(object sender, EventArgs e)
    {
        if(cbxColor.Value == true)
        {
            lblLabel.FontColor = new Color(1, 255, 0, 0);
        }
        else
        {
            lblLabel.FontColor = new Color(1, 0, 0, 0);
        }
    }

    private void CmdClose_Click(object sender, EventArgs e)
    {
        this.Finish();
    }
}
```

### HyperLink

```csharp
public class HyperLinkController: Controller
{
	protected override void OnStart()
	{
		IStack stack = BaitAndSwitch.Create<IStack>();

		ILabel lblLabel = BaitAndSwitch.Create<ILabel>();
		lblLabel.Text = "Visit";
		lblLabel.Height = 30;
		stack.Children.Add(lblLabel);

        IHyperLink hplUrl = BaitAndSwitch.Create<IHyperLink>();
        hplUrl.Text = "http://www.okhosting.com";
        hplUrl.Uri = new Uri("http://www.okhosting.com");
        hplUrl.Name = "okhosting.com";
        stack.Children.Add(hplUrl);

        IButton cmdClose = BaitAndSwitch.Create<IButton>();
        cmdClose.Text = "Close";
        cmdClose.Click += CmdClose_Click;
        stack.Children.Add(cmdClose);

        Page.Title = "Test label";
		Page.Content = stack;
	}

    private void CmdClose_Click(object sender, EventArgs e)
    {
        this.Finish();
    }
}
```

### Image

```csharp
public class ImageController: Controller
{
    protected override void OnStart()
    {
        IStack stack = BaitAndSwitch.Create<IStack>();

        ILabel lblLabel = BaitAndSwitch.Create<ILabel>();
        lblLabel.Text = "View an image from Url";
        lblLabel.Height = 30;
        stack.Children.Add(lblLabel);

        IImage imgPicture = BaitAndSwitch.Create<IImage>();
        imgPicture.LoadFromUrl(new Uri("http://www.patycantu.com/wp-content/uploads/2014/07/91.jpg"));
        imgPicture.Height = 250;
        imgPicture.Width = 600;
        stack.Children.Add(imgPicture);

        IButton cmdClose = BaitAndSwitch.Create<IButton>();
        cmdClose.Text = "Close";
        cmdClose.Click += CmdClose_Click;
        stack.Children.Add(cmdClose);

        Page.Title = "Test label";
		Page.Content = stack;
	}

    private void CmdClose_Click(object sender, EventArgs e)
    {
        this.Finish();
    }
}
```

## Status

The proyect is in beta state, feel free to try it and run it for test projects for now. 
All platforms are running now, some controls dont have all features fully supported (design stuff mostly) in some platforms.
All the core logic on the framework is running very well and generally stable.

So far tested on ASP.NET Web Forms, Windows Forms, WPF, Mac OS X, iOS and Android.

## License

Published under the very permissive MIT License

## Add ORM for your pleasure

Checkout 

* https://github.com/okhosting/OKHOSTING.ORM 
* https://github.com/okhosting/OKHOSTING.ORM/tree/master/src/PCL/OKHOSTING.ORM.UI

To integrate a fully working and also multi platform ORM and integrated CRUD UI generation on top of OKHOSTING.UI.

So you could create full multiplatform apps for CRUD operations very fast. And them add some customization, all from one code base in PCL libraries.
