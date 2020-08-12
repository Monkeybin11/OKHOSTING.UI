using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
			public string Id;
			public string Name;
			public string LastName;
			public DateTime BirthDate { get; set; }
			public bool DoesSports { get; set; }

			public static IEnumerable<Person> GetSomeFolks()
			{
				yield return new Person()
				{
					Id = "1",
					Name = "Fulanito",
					LastName = "De tal",
					BirthDate = new DateTime(1980, 7, 30),
					DoesSports= true,
				};

				yield return new Person()
				{
					Id = "2",
					Name = "Sutanito",
					LastName = "Perez",
					BirthDate = new DateTime(1975, 8, 17),
					DoesSports = true,
				};

				yield return new Person()
				{
					Id = "3",
					Name = "Merengano",
					LastName = "Sutano",
					BirthDate = new DateTime(1982, 7, 1),
					DoesSports = false,
				};

				yield return new Person()
				{
					Id = "4",
					Name = "Mariana",
					LastName = "Velazco",
					BirthDate = new DateTime(1990, 1, 1),
					DoesSports = true,
				};

				yield return new Person()
				{
					Id = "5",
					Name = "Pedro",
					LastName = "Paramo",
					BirthDate = new DateTime(1950, 1, 15),
					DoesSports = false,
				};
			}
		}

		public class PersonTreeGrid : TreeGrid<Person>
		{
			public PersonTreeGrid() : base(Person.GetSomeFolks())
			{
			}

			protected override IEnumerable<Person> GetChildren(Person item)
			{
				if (item.Id.EndsWith("1") || item.Id.EndsWith("3") || item.Id.EndsWith("5"))
				{
					var folks = Person.GetSomeFolks().ToArray();

					int i = 1;

					foreach (var f in folks)
					{
						f.Id = $"{item.Id}.{i++}";
					}

					return folks;
				}
				else
				{
					return null;
				}
			}

			protected override IEnumerable<MemberInfo> GetMembers()
			{
				Type type = typeof(Person);

				yield return type.GetMember(nameof(Person.Id))[0];
				yield return type.GetMember(nameof(Person.Name))[0];
				yield return type.GetMember(nameof(Person.LastName))[0];
				yield return type.GetMember(nameof(Person.BirthDate))[0];
				yield return type.GetMember(nameof(Person.DoesSports))[0];
			}
		}
	}
}