using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Builders
{
	/// <summary>
	/// A grid that has rows with child rows, and the child rows are shown when the user
	/// clicks the "expand" button on the parent row
	/// </summary>
	public class TreeGrid<T>: IBuilder<IGrid>
	{
		protected readonly IGrid Grid;

		/// <summary>
		/// The rows of this grid
		/// </summary>
		public readonly List<Row> Rows;
		
		/// <summary>
		/// The items that will be displayed, each as a row
		/// </summary>
		public readonly IEnumerable<T> ParentItems;

		IControl IBuilder.Control
		{
			get
			{
				return Grid;
			}
		}

		public IGrid Control
		{
			get
			{
				return Grid;
			}
		}

		public event EventHandler<Row> AddingRow;

		public TreeGrid(IEnumerable<T> parentItems)
		{
			Grid = BaitAndSwitch.Create<IGrid>();
			Rows = new List<Row>();
			ParentItems = parentItems;
			
			Init();
		}

		public void Init()
		{
			IControl[] headers = CreateHeaders().ToArray();

			Grid.ClearContent();
			Grid.ColumnCount = headers.Length + 1; //always add a 0 column that will display the +- icons to open and collapse the children rows
			Grid.RowCount = 1;
			Grid.ShowGridLines = true;

			Row[] rows = Rows.ToArray();

			//set headers
			for (int column = 1; column <= headers.Length; column++)
			{
				Grid.SetContent(0, column, headers[column - 1]);
			}

			//set rows
			for (int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
			{
				AddRow(rows[rowIndex]);
			}
		}

		protected void AddRow(Row row)
		{
			OnAddingRow(row);
			
			Grid.RowCount++;
 
			//set content of the row, except for expand button
			var content = row.Content.ToArray();
			
			for (int column = 1; column < Grid.ColumnCount; column++)
			{
				Grid.SetContent(Grid.RowCount - 1, column, content[column - 1]);
			}

			var children = row.Children?.ToArray();

			if (children != null && children.Length > 0)
			{
				//create expand/collapse button and put it on the first cell
				IClickable cmdExpand;

				if (row.Collapsed)
				{
					cmdExpand = CreateExpandButton();
				}
				else
				{
					cmdExpand = CreateCollapseButton();
				}

				cmdExpand.Tag = row;

				Grid.SetContent(Grid.RowCount - 1, 0, cmdExpand);

				//show children only if the row is not collapsed
				if (!row.Collapsed)
				{
					var childrenMargin = content[0].Margin ?? new Thickness(0);
					childrenMargin = new Thickness(childrenMargin.Left + 20, childrenMargin.Top, childrenMargin.Right, childrenMargin.Bottom);

					for (int childrenIndex = 0; childrenIndex < children.Length; childrenIndex++)
					{
						children[childrenIndex].Content.First().Margin = childrenMargin;

						AddRow(children[childrenIndex]);
					}
				}
			}
		}

		protected void cmdExpand_Click(object sender, EventArgs e)
		{
			var cmdExpand = (ILabelButton) sender;
			var row = (Row) cmdExpand.Tag;

			//reverse value
			row.Collapsed = !row.Collapsed;
			Init();
		}

		protected IClickable CreateExpandButton()
		{
			var control = BaitAndSwitch.Create<ILabelButton>();
			control.Text = "+";
			control.Click += cmdExpand_Click;

			return control;
		}

		protected IClickable CreateCollapseButton()
		{
			var control = BaitAndSwitch.Create<ILabelButton>();
			control.Text = "-";
			control.Click += cmdExpand_Click;

			return control;
		}

		protected void OnAddingRow(Row row)
		{
			AddingRow?.Invoke(this, row);
		}

		/// <summary>
		/// Creates the controls that will be placed at the top of the grid, displaying the column names
		/// </summary>
		protected virtual IEnumerable<IControl> CreateHeaders()
		{
			var members = GetMembers();

			foreach (var member in members)
			{
				yield return CreateHeader(member);
			}
		}

		/// <summary>
		/// Creates a control that will be placed at the top of the grid, displaying the member name
		/// </summary>
		protected virtual IControl CreateHeader(System.Reflection.MemberInfo member)
		{
			var lblHeader = BaitAndSwitch.Create<ILabelButton>();
			lblHeader.Text = Translator.Translate(member);
			lblHeader.Click += lblHeader_Click;
			lblHeader.Tag = member;

			return lblHeader;
		}

		/// <summary>
		/// Raised when the user clicks aon a header
		/// </summary>
		protected virtual void lblHeader_Click(object sender, EventArgs e)
		{
		}
		
		/// <summary>
		/// Creates all rows, one for each of the items
		/// </summary>
		protected virtual IEnumerable<Row> CreateRows()
		{
			foreach (var item in ParentItems)
			{
				yield return CreateRow(item);
			}
		}

		/// <summary>
		/// Creates a row from one of the items
		/// </summary>
		protected virtual Row CreateRow(T item)
		{
			var members = GetMembers();
			var row = new Row();
			var controls = new List<IControl>();

			foreach (var member in members)
			{
				var content = CreateContent(item, member);
				
				if (content != null)
				{
					controls.Add(content);
				}
			}

			row.Content = controls;

			return row;
		}

		protected virtual IControl CreateContent(T item, System.Reflection.MemberInfo member)
		{ 
			var content = BaitAndSwitch.Create<ILabelButton>();
			content.Click += content_Click;
			content.Text = Data.MemberExpression.GetValue(member, item)?.ToString();

			return content;
		}

		protected virtual void content_Click(object sender, EventArgs e)
		{
		}

		/// <summary>
		/// Returns the members that showld be dispolayed in the grid as columns
		/// </summary>
		protected virtual IEnumerable<System.Reflection.MemberInfo> GetMembers()
		{ 
			return typeof(T).GetAllMemberInfos().Where(m => !Data.MemberExpression.GetReturnType(m).IsCollection());
		}

		protected virtual IEnumerable<T> GetChildren(T item)
		{
			var type = typeof(T);
			var enumerableType = typeof(IEnumerable<T>);
			var childrenMember = type.GetAllMemberInfos().Where(m => Data.MemberExpression.GetReturnType(m).IsAssignableFrom(enumerableType)).FirstOrDefault();

			if (childrenMember == null)
			{
				return null;
			}

			var children = (IEnumerable<T>) Data.MemberExpression.GetValue(childrenMember, item);
			return children;
		}

		/// <summary>
		/// Represents a row in a TreeGrid, with optional children rows
		/// </summary>
		public class Row
		{
			/// <summary>
			/// Gets or sets an arbitrary object value that can be used to store custom information about this element. 
			/// <para xml:lang="es">
			/// Obtiene o establece un objeto de valor arbitrario que se puede usar para almacenar informacion personalizada sobre este elemento.
			/// </para>
			/// </summary>
			public T Tag { get; set; }

			/// <summary>
			/// When true, the row will not display it's children. 
			/// When false, the children rows will be visible.
			/// </summary>
			public bool Collapsed { get; set; }

			/// <summary>
			/// The content that must be placed in the row, each control will be put in a column
			/// </summary>
			public IEnumerable<IControl> Content { get; set; }

			/// <summary>
			/// The children rows of this row, will be visible when collapsed is false, with a little padding to the right of the current row
			/// </summary>
			public IEnumerable<Row> Children { get; set; }
		}
	}
}