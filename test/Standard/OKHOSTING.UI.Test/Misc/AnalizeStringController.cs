using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OKHOSTING.UI.Test.Misc
{
	class AnalizeStringController : Controller
	{
		//In Variables
		ITextBox txtString;

		//Out Variables
		ITextBox txtLetters;
		ITextBox txtNumbers;
		ITextBox txtVowels;
		ITextBox txtUpperCase;
		ITextBox txtLowerCase;

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

			//lblString
			ILabel lblString = Core.BaitAndSwitch.Create<ILabel>();
			lblString.Text = "String";
			grid.SetContent(0, 0, lblString);

			//txtString
			txtString = Core.BaitAndSwitch.Create<ITextBox>();
			txtString.Value = "";
			txtString.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(0, 1, txtString);

			//lblLetters
			ILabel lblLetters = Core.BaitAndSwitch.Create<ILabel>();
			lblLetters.Text = "Number of Letters";
			grid.SetContent(1, 0, lblLetters);

			//txtLetters
			txtLetters = Core.BaitAndSwitch.Create<ITextBox>();
			txtLetters.Enabled = false;
			txtLetters.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(1, 1, txtLetters);

			//lblNumbers
			ILabel lblNumbers = Core.BaitAndSwitch.Create<ILabel>();
			lblNumbers.Text = "Number of Numbers";
			grid.SetContent(2, 0, lblNumbers);

			//txtNumbers
			txtNumbers = Core.BaitAndSwitch.Create<ITextBox>();
			txtNumbers.Enabled = false;
			txtNumbers.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(2, 1, txtNumbers);

			//lblVowels
			ILabel lblVowels = Core.BaitAndSwitch.Create<ILabel>();
			lblVowels.Text = "Number of Vowels";
			grid.SetContent(3, 0, lblVowels);

			//txtVowels
			txtVowels = Core.BaitAndSwitch.Create<ITextBox>();
			txtVowels.Enabled = false;
			txtVowels.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(3, 1, txtVowels);

			//lblUpperCase
			ILabel lblUpperCase = Core.BaitAndSwitch.Create<ILabel>();
			lblUpperCase.Text = "Number of Upper Case";
			grid.SetContent(4, 0, lblUpperCase);

			//txtUpperCase
			txtUpperCase = Core.BaitAndSwitch.Create<ITextBox>();
			txtUpperCase.Enabled = false;
			txtUpperCase.BorderWidth = new Thickness(1, 2, 3, 4);
			grid.SetContent(4, 1, txtUpperCase);

			//lblLowerCase
			ILabel lblLowerCase = Core.BaitAndSwitch.Create<ILabel>();
			lblLowerCase.Text = "Number of Lower Case";
			grid.SetContent(5, 0, lblLowerCase);

			//txtLowerCase
			txtLowerCase = Core.BaitAndSwitch.Create<ITextBox>();
			txtLowerCase.Enabled = false;
			grid.SetContent(5, 1, txtLowerCase);

			//btnSearch
			IButton btnSearch = Core.BaitAndSwitch.Create<IButton>();
			btnSearch.Text = "Search";
			btnSearch.Click += btnSearch_Click;
			grid.SetContent(7, 0, btnSearch);

			//btnClean
			IButton btnClean = Core.BaitAndSwitch.Create<IButton>();
			btnClean.Text = "Clean";
			btnClean.Click += btnClean_Click;
			grid.SetContent(7, 1, btnClean);

			//btnClose
			IButton btnClose = Core.BaitAndSwitch.Create<IButton>();
			btnClose.Text = "Close";
			btnClose.Click += btnClose_Click;
			grid.SetContent(7, 2, btnClose);

			// Establishes the content and title of the page.
			Page.Title = "Test Analize String";
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
		/// 

		//Evento del botón buscar
		private void btnSearch_Click(object sender, EventArgs e)
		{
			//LETTERS**************************************************************************************
			//This variable ir for compare the value of txtString if contain vowels
			string letters = "abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ";

			//This variable contain the number of numbers
			int countLetters = 0;

			//Convert the value of letters to array char
			char[] arrayLetters = letters.ToCharArray();

			//NUMBERS**************************************************************************************
			//This variable ir for compare the value of txtString if contain numbers
			string numbers = "0123456789";

			//This variable contain the number of numbers
			int countNumbers = 0;

			//Convert the value of numbers to array char
			char[] arrayNumbers = numbers.ToCharArray();

			//VOWELS**************************************************************************************
			//This variable ir for compare the value of txtString if contain vowels
			string vowels = "aeiou";

			//This variable contain the number of vowels
			int countVowels = 0;

			//Convert the value of vowels to array char
			char[] arrayVowels = vowels.ToCharArray();

			//UPPER CASE**************************************************************************************
			//This variable ir for compare the value of txtString if contain vowels
			string uppers = "ABCDEFGHIJKLMNÑOPQRSTUVWXYZ";

			//This variable contain the number of vowels
			int countUppers = 0;

			//Convert the value of vowels to array char
			char[] arrayUppers = uppers.ToCharArray();

			//LOWER CASE**************************************************************************************
			//This variable ir for compare the value of txtString if contain vowels
			string lowers = "abcdefghijklmnñopqrstuvwxyz";

			//This variable contain the number of vowels
			int countLowers = 0;

			//Convert the value of vowels to array char
			char[] arrayLowers = lowers.ToCharArray();

			//Convert the value of txtString to array char
			char[] arrayString = txtString.Value.ToCharArray();

			foreach(char arrayS in arrayString)
			{
				//Foreach for know if txtString contain letters
				foreach (char arrayL in arrayLetters)
				{
					if (arrayS == arrayL)
					{
						countLetters++;
					}
				}

				//Foreach for know if txtString contain numbers
				foreach (char arrayN in arrayNumbers)
				{
					if(arrayS == arrayN)
					{
						countNumbers++;
					}
				}

				//Foreach for know if txtString contain vowels
				foreach (char arrayV in arrayVowels)
				{
					if (arrayS == arrayV)
					{
						countVowels++;
					}
				}

				//Foreach for know if txtString contain Upper
				foreach (char arrayU in arrayUppers)
				{
					if (arrayS == arrayU)
					{
						countUppers++;
					}
				}

				//Foreach for know if txtString contain Lower
				foreach (char arrayL in arrayLowers)
				{
					if (arrayS == arrayL)
					{
						countLowers++;
					}
				}

			}

			txtLetters.Value = countLetters.ToString();
			txtNumbers.Value = countNumbers.ToString();
			txtVowels.Value = countVowels.ToString();
			txtUpperCase.Value = countUppers.ToString();
			txtLowerCase.Value = countLowers.ToString();
		}

		//Evento del botón borrar
		private void btnClean_Click(object sender, EventArgs e)
		{
			string Clean = " ";

			txtString.Value = Clean;
			txtLetters.Value = Clean;
			txtNumbers.Value = Clean;
			txtVowels.Value = Clean;
			txtUpperCase.Value = Clean;
			txtLowerCase.Value = Clean;
		}

		//Evento del botón Salir
		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}
	}
}
