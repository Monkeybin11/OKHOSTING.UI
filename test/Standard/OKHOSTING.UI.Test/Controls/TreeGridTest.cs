using System;
using System.Collections.Generic;
using OKHOSTING.UI.Builders;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;

namespace OKHOSTING.UI.Test.Controls
{
	/// <summary>
	/// It represents an TreeGrid.
	/// </summary>
	public class TreeGridTest : Controller
	{
		const int Columns = 4;

		/// <summary>
		/// Start this instance.
		/// <para xml:lang="es">
		/// Inicia una instancia de este objeto.
		/// </para>
		/// </summary>
		protected override void OnStart()
		{
			var treeGrid = new PersonTreeGrid();

			var cmdClose = Core.BaitAndSwitch.Create<IButton>();
			cmdClose.Text = "Close";
			cmdClose.Click += cmdClose_Click;

			var stack = Core.BaitAndSwitch.Create<IStack>();
			stack.Children.Add(treeGrid.Control);
			stack.Children.Add(cmdClose);

			// Establishes the content and title of the page.
			Page.Title = "Test a TreeGrid";
			Page.Content = stack;
		}

		/// <summary>
		/// It is the button click event cmdClose, what it does is end this instance.
		/// <para xml:lang="es">
		/// Es el evento clic del boton cmdClose, lo que hace es finalizar esta instancia.
		/// </para>
		/// </summary>
		/// <returns>The close click.</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		private void cmdClose_Click(object sender, EventArgs e)
		{
			this.Finish();
		}

		public class Person
		{
			public string Name;
			public string LastName;
			public DateTime BirthDate { get; set; }
			public bool DoesSports { get; set; }

			public static IEnumerable<Person> GetSomeFolks()
			{
				yield return new Person()
				{
					Name = "Fulanito",
					LastName = "De tal",
					BirthDate = new DateTime(1980, 7, 30),
					DoesSports= true,
				};

				yield return new Person()
				{
					Name = "Sutanito",
					LastName = "Perez",
					BirthDate = new DateTime(1975, 8, 17),
					DoesSports = true,
				};

				yield return new Person()
				{
					Name = "Merengano",
					LastName = "Sutano",
					BirthDate = new DateTime(1982, 7, 1),
					DoesSports = false,
				};

				yield return new Person()
				{
					Name = "Mariana",
					LastName = "Velazco",
					BirthDate = new DateTime(1990, 1, 1),
					DoesSports = true,
				};

				yield return new Person()
				{
					Name = "Pedro",
					LastName = "Paramo",
					BirthDate = new DateTime(1950, 1, 15),
					DoesSports = false,
				};
			}
		}

		public class PersonTreeGrid : TreeGrid<Person>
		{
			Random random = new Random();

			public PersonTreeGrid() : base(Person.GetSomeFolks())
			{
			}

			protected override IEnumerable<Person> GetChildren(Person item)
			{
				if (random.Next() % 2 == 0)
				{
					return Person.GetSomeFolks();
				}
				else
				{
					return null;
				}
			}
		}
	}
}