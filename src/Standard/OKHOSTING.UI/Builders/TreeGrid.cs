using OKHOSTING.Core;
using OKHOSTING.UI.Controls;
using OKHOSTING.UI.Controls.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
		protected readonly List<Row> Rows;
		
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

		public TreeGrid(IEnumerable<T> parentItems)
		{
			Grid = BaitAndSwitch.Create<IGrid>();
			ParentItems = parentItems;

			IControl[] headers = CreateHeaders().ToArray();
			
			Grid.ClearContent();
			Grid.ColumnCount = headers.Length;
			Grid.ShowGridLines = true;
			
			Rows = CreateParentRows().ToList();
			Row[] rows = Rows.ToArray();

			Grid.RowCount = rows.Length + 1;

			//set headers
			for (int column = 0; column < headers.Length; column++)
			{
				if (column == 0)
				{
					var originalMargin = headers[column].Margin ?? new Thickness(0);
					originalMargin = new Thickness(originalMargin.Left + 10, originalMargin.Top, originalMargin.Right, originalMargin.Bottom);

					headers[column].Margin = originalMargin;
				}

				Grid.SetContent(0, column, headers[column]);
			}

			//set rows
			for (int rowIndex = 0; rowIndex < rows.Length; rowIndex++)
			{
				rows[rowIndex].Index = rowIndex;
				SetRowContent(rows[rowIndex]);
			}
		}

		protected virtual void SetRowContent(Row row)
		{
			//set content of the row, except for expand button
			var content = row.Content.ToArray();
			
			for (int column = 0; column < Grid.ColumnCount; column++)
			{
				Grid.SetContent(row.Index + 1, column, content[column]);
			}

			//create child rows if necessary
			if (row.Children == null)
			{
				CreateChildrenRows(row);
			}

			var children = row.Children?.ToArray();

			if (children != null && children.Length > 0)
			{
				//create expand/collapse button and put it on the first cell
				ILabelButton cmdExpand = CreateExpandButton();

				if (!row.Collapsed)
				{
					cmdExpand.Text = "-";
				}

				cmdExpand.Tag = row;

				//add expand button to the first column
				var flow = BaitAndSwitch.Create<IFlow>();
				flow.Children.Add(cmdExpand);
				flow.Children.Add(row.Content.First());
				Grid.SetContent(row.Index + 1, 0, flow);

				//show children only if the row is not collapsed
				if (!row.Collapsed)
				{
					var childrenMargin = content[0].Margin ?? new Thickness(0);
					childrenMargin = new Thickness(childrenMargin.Left + 20, childrenMargin.Top, childrenMargin.Right, childrenMargin.Bottom);

					for (int childrenIndex = 0; childrenIndex < children.Length; childrenIndex++)
					{
						children[childrenIndex].Content.First().Margin = childrenMargin;

						children[childrenIndex].Index = row.Index + childrenIndex + 1;
						SetRowContent(children[childrenIndex]);
					}
				}
			}
			else
			{
				var childrenMargin = content[0].Margin ?? new Thickness(0);
				childrenMargin = new Thickness(childrenMargin.Left + 20, childrenMargin.Top, childrenMargin.Right, childrenMargin.Bottom);
				
				content[0].Margin = childrenMargin;
			}
		}

		protected virtual void cmdExpand_Click(object sender, EventArgs e)
		{
			var cmdExpand = (ILabelButton) sender;
			var row = (Row) cmdExpand.Tag;
			var newCollapsedValue = !row.Collapsed;

			//from non-collapsed to collapsed
			if (newCollapsedValue)
			{
				var children = row.RecursiveNonCollapsedChildern.ToArray();

				//delete rows that where collapsed
				foreach (var child in children)
				{
					Grid.ClearContentRow(child.Index);
				}

				//move bottom content up
				for (int childIndex = 0; childIndex < children.Length; childIndex++)
				{
					Grid.MoveRowContent(row.Index + children.Length + 1, row.Index + childIndex + 1);
				}

				Grid.RowCount = Grid.RowCount - children.Length;
				row.Collapsed = newCollapsedValue;
				cmdExpand.Text = "+";
			}
			//from collapsed to non-collapsed
			else
			{
				//create new rows if necessary
				if (row.Children == null)
				{
					CreateChildrenRows(row);
				}

				row.Collapsed = newCollapsedValue;

				var children = row.Children.ToArray();
				var bottomCount = Grid.RowCount - row.Index - 1;
				Grid.RowCount = Grid.RowCount + children.Length;

				//move content to the bottom
				for (int childIndex = 0; childIndex < bottomCount; childIndex++)
				{
					Grid.MoveRowContent(row.Index + childIndex + 1, row.Index + childIndex + children.Length + 1);
				}
				
				var childrenMargin = row.Content.First().Margin ?? new Thickness(0);
				childrenMargin = new Thickness(childrenMargin.Left + 20, childrenMargin.Top, childrenMargin.Right, childrenMargin.Bottom);

				//insert the just expanded content
				for (int childIndex = 0; childIndex < children.Length; childIndex++)
				{
					var child = children[childIndex];
					child.Index = row.Index + childIndex;
					child.Content.First().Margin = childrenMargin;

					SetRowContent(child);
				}
				
				cmdExpand.Text = "-";
			}
		}

		protected ILabelButton CreateExpandButton()
		{
			var control = BaitAndSwitch.Create<ILabelButton>();
			control.Text = "+";
			control.Click += cmdExpand_Click;
			control.TextHorizontalAlignment = HorizontalAlignment.Center;
			control.TextVerticalAlignment = VerticalAlignment.Center;
			
			return control;
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
		protected virtual IControl CreateHeader(MemberInfo member)
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
		protected virtual IEnumerable<Row> CreateParentRows()
		{
			int index = 0;

			foreach (var item in ParentItems)
			{
				var row = CreateRow(item);
				row.Index = index++;
				
				yield return row;
			}
		}

		/// <summary>
		/// Creates a row from one of the items
		/// </summary>
		protected virtual Row CreateRow(T item)
		{
			var row = new Row();
			row.Tag = item;
			row.Collapsed = true;

			var controls = new List<IControl>();
			var members = GetMembers();

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

		protected virtual IControl CreateContent(T item, MemberInfo member)
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
		protected virtual IEnumerable<MemberInfo> GetMembers()
		{ 
			return typeof(T).GetAllMemberInfos().Where(m => 
			(
				(m is FieldInfo && ((FieldInfo) m).IsPublic)
				|| 
				(m is PropertyInfo && ((PropertyInfo) m).GetMethod != null && ((PropertyInfo) m).GetMethod.IsPublic)
			)
			&& 
			!Data.MemberExpression.GetReturnType(m).IsCollection());
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

		protected virtual IEnumerable<Row> CreateChildrenRows(Row parent)
		{
			var newRows = new List<Row>();
			var childrenItems = GetChildren(parent.Tag);

			if (childrenItems == null)
			{
				parent.Children = newRows;
				return newRows;
			}

			foreach (var childItem in childrenItems)
			{
				var childRow = CreateRow(childItem);
				newRows.Add(childRow);
			}

			parent.Children = newRows;
			return newRows;
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
			/// The position of this row in the grid, top to bottom
			/// </summary>
			public int Index { get; set; }

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

			public IEnumerable<Row> RecursiveChildern
			{
				get 
				{
					if (Children == null)
					{
						yield break;
					}

					foreach (var child in Children)
					{
						yield return child;

						foreach (var subChild in child.RecursiveChildern)
						{
							yield return subChild;
						}
					}
				}
			}

			public IEnumerable<Row> RecursiveNonCollapsedChildern
			{
				get
				{
					if (Collapsed || Children == null)
					{
						yield break;
					}

					foreach (var child in Children)
					{
						yield return child;

						foreach (var subChild in child.RecursiveNonCollapsedChildern)
						{
							yield return subChild;
						}
					}
				}
			}
		}
	}
}