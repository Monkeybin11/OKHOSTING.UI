using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// Field for selecting a DataType
	/// </summary>
	public class TypeField : ListPickerField
	{
		public TypeField(Type parent)
		{
			if (parent == null)
			{ 
				throw new ArgumentNullException("parent");
			}

			Parent = parent;
		}

		public override Type ValueType
		{
			get
			{
				return typeof(Type);
			}
		}

		public override object Value
		{
			get
			{
				if (ValueControl.Value == Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue)
				{
					return null;
				}
				else
				{
					return Type.GetType(ValueControl.Value);
				}
			}
			set
			{
				if (value == null && !Required)
				{
					ValueControl.Value = Resources.Strings.OKHOSTING_UI_Controls_Forms_EmptyValue;
				}
				else
				{
					ValueControl.Value = ((Type) value).FullName;
				}
			}
		}

		/// <summary>
		/// The DataType (and subclasses of it) that will be available as an option in the DropDownList.
		/// if set to null, all DataTypes will be available
		/// </summary>
		public readonly Type Parent;

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected override void CreateValueControl()
		{
			//create listpicker and add empty value if not required
			base.CreateValueControl();

			//add Parent first
			ValueControl.Items.Add(Parent.FullName);

			//add all Parent subclasses
			foreach (Type type in Parent.GetTypeInfo().Assembly.DefinedTypes.Where(t => t.IsSubclassOf(Parent)).Select(t => t.AsType()))
			{
				ValueControl.Items.Add(type.FullName);
			}
		}
	}
}