using OKHOSTING.Data.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// An item that will be displayed in the dataform
	/// </summary>
	public abstract class FormField
	{
		public FormField()
		{
		}

		#region Public properties

		/// <summary>
		/// Id or programing-friendly name that you give to this field.
		/// A single form should not contain 2 fields with the same field
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Label that shows the caption or name for this field
		/// </summary>
		public ILabel CaptionControl { get; protected set; }

		/// <summary>
		/// Control that parses the value to web
		/// </summary>
		public IControl ValueControl { get; protected set; }

		/// <summary>
		/// The type of value that this field will show/accept
		/// </summary>
		public Type ValueType { get; protected set; }

		/// <summary>
		/// If set to true, this field must be set to 100% of the form's width and use a complete row for itself
		/// </summary>
		public bool TableWide { get; set; }

		/// <summary>
		/// Container form
		/// </summary>
		public Form Container { get; set; }

		/// <summary>
		/// Category of the field. Used for grouping fields in the DataForm
		/// </summary>
		public string Category { get; set; }

		/// <summary>
		/// Gets or sets a value that defines the order in which fields appear on the DataForm
		/// </summary>
		public uint SortOrder { get; set; }
		
		/// <summary>
		/// If true, the current field cannot be left empty, validated in javascript
		/// </summary>
		public bool Required = false;

		#endregion

		#region Methods

		//abstract

		/// <summary>
		/// Value selected by the user
		/// </summary>
		public abstract object Value { get; set; }

		/// <summary>
		/// Creates the controls for displaying the field
		/// </summary>
		protected abstract void CreateValueControl();

		//non abstract

		/// <summary>
		/// Indicates wether all information written by the user has been succesfully validated or not
		/// </summary>
		public virtual bool IsValid
		{
			get
			{
				if (Required)
				{
					return new RequiredValidator().Validate(Value) == null;
				}
				else
				{
					return true;
				}
			}
		}

		/// <summary>
		/// Returns the field's Id
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (CaptionControl == null)
			{
				return null;
			}
			else
			{
				return CaptionControl.Text;
			}
		}

		#endregion
	}
}