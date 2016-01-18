using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OKHOSTING.Softosis.Filters;
using OKHOSTING.Softosis.Core.Security;
using OKHOSTING.Core.Extensions;
using OKHOSTING.Softosis;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A form that enables the user to create advanced filters when searching for DataObjects
	/// </summary>
	public class FilterDataForm: DataForm
	{
		/// <summary>
		/// Copies all values entered by the user to a DavaValueInstance collection
		/// </summary>
		/// <param name="dvalues">Collection where values will be copied to</param>
		public FilterCollection GetFiltersFrom(List<DataValue> dvalues)
		{
			//validate arguments
			if (dvalues == null) throw new ArgumentNullException("dvalues");

			//filters
			FilterCollection filters = new OKHOSTING.Softosis.Filters.FilterCollection();
			IFilter filter = null;

			//create filters
			foreach (DataValue dvalue in dvalues)
			{
				#region range filter

				//if it's a datetime or a numeric field, create range filter
				if (dvalue.ValueType.Equals(typeof(DateTime)) || dvalue.ValueType.IsNumeric())
				{
					//realted fields
					FormField fieldMin = null, fieldMax = null;

					//search corresponding field for this DataValueInstance
					foreach (FormField f in Fields)
					{
						if (f.Id == dvalue.Name + "_0") fieldMin = f;
						if (f.Id == dvalue.Name + "_1") fieldMax = f;
					}

					//if no controls where found, continue
					if (fieldMin == null && fieldMax == null) continue;

					//if no value was set, continue to the next field
					if (NullValues.IsNull(fieldMin.Value) && NullValues.IsNull(fieldMax.Value)) continue;

					//if both values are set, create range filter
					if (!NullValues.IsNull(fieldMin.Value) && !NullValues.IsNull(fieldMax.Value))
					{
						filter = new RangeFilter(dvalue, (IComparable)fieldMin.Value, (IComparable)fieldMax.Value);
					}

					//only min value is defined
					else if (!NullValues.IsNull(fieldMin.Value))
					{
						filter = new ValueCompareFilter(dvalue, (IComparable)fieldMin.Value, CompareOperator.GreaterThanEqual);
					}

					//only max value is defined
					else if (!NullValues.IsNull(fieldMax.Value))
					{
						filter = new ValueCompareFilter(dvalue, (IComparable)fieldMax.Value, CompareOperator.LessThanEqual);
					}
				}

				#endregion

				#region single value filter

				//create single value filter
				else
				{
					//realted fields
					FormField field = null;

					//search corresponding field for this DataValueInstance
					foreach (FormField f in Fields)
					{
						if (f.Id == dvalue.Name) field = f;
					}

					//if field not found, continue
					if (field == null) continue;

					//if no value was set, continue to the next field
					if (NullValues.IsNull(field.Value)) continue;

					//if its a string, make a LIKE filter
					else if (field.ValueType.Equals(typeof(string)))
					{
						filter = new LikeFilter(dvalue, "%" + field.Value + "%");
					}

					//if it's a dataobject, create a foreign key filter
					else if (DataType.IsDataObject(field.ValueType))
					{
						filter = new ForeignKeyFilter(dvalue, (DataObject)field.Value);
					}

					//otherwise create a compare filter
					else
					{
						filter = new ValueCompareFilter(dvalue, (IComparable)field.Value, CompareOperator.Equal);
					}
				}

				#endregion

				//if filter is not null, add to filter collection and continue
				if (filter != null) filters.Add(filter);
				filter = null;
			}

			//return generated filters
			return filters;
		}

		/// <summary>
		/// Creates a collection of fields for displaying a collection of DataValues
		/// </summary>
		public void AddFieldsFrom(List<DataValue> dvalues)
		{
			//if there's no values defined, exit
			if (dvalues == null) throw new ArgumentNullException("dvalues");

			//create fields
			foreach (DataValue dv in dvalues)
			{
				AddFieldsFrom(dv);
			}
		}

		/// <summary>
		/// Creates a field for a DataValue
		/// </summary>
		public void AddFieldsFrom(DataValue dvalue)
		{
			//if there's no values defined, exit
			if (dvalue == null) throw new ArgumentNullException("dvalue");

			//field
			FormField fieldMin, fieldMax;

			//DateTime and numeric, create range fields
			if (dvalue.ValueType.Equals(typeof(DateTime)) || dvalue.ValueType.IsNumeric())
			{
				//create fields
				fieldMin = FormField.CreateFieldFrom(dvalue);
				fieldMax = FormField.CreateFieldFrom(dvalue);

				//enable all fields
				fieldMin.Enabled = true;
				fieldMax.Enabled = true;

				//set id
				fieldMin.Id += "_0";
				fieldMax.Id += "_1";

				//labels
				fieldMin.Text += " (" + OKHOSTING.Softosis.Core.Globalization.Translator.Current["OKHOSTING.UI.Controls.Forms.FilterDataForm.Min"] + ")";
				fieldMax.Text += " (" + OKHOSTING.Softosis.Core.Globalization.Translator.Current["OKHOSTING.UI.Controls.Forms.FilterDataForm.Max"] + ")";

				//set container
				fieldMin.Container = this;
				fieldMax.Container = this;

				//not required
				fieldMin.Required = false;
				fieldMax.Required = false;

				//set to false always
				fieldMin.TableWide = false;
				fieldMax.TableWide = false;
				
				//order
				if (dvalue.IsPrimaryKey) fieldMin.SortOrder = fieldMax.SortOrder = 0;
				else fieldMin.SortOrder = fieldMax.SortOrder = 1;

				//add
				Fields.Add(fieldMin);
				Fields.Add(fieldMax);
			}

			//single value fields
			else
			{
				//create field

				//if html attribute is defined, ommit and create a simple string field
				if (HtmlAttribute.IsHtml(dvalue))
				{
					fieldMin = new StringField();
					FormField.SetDefaultProperties(dvalue, fieldMin);
				}
				
				//otherwise, let fieldbase choose the right field type
				else
				{
					fieldMin = FormField.CreateFieldFrom(dvalue);
				}

				//enable all fields
				fieldMin.Enabled = true;
				
				//set container
				fieldMin.Container = this;

				//not required
				fieldMin.Required = false;

				//set to false always
				fieldMin.TableWide = false;

				//order
				if (dvalue.IsPrimaryKey) fieldMin.SortOrder = 0;
				else fieldMin.SortOrder = 1;

				//add
				Fields.Add(fieldMin);
			}
		}
		
		/// <summary>
		/// Returns the fields that corresponds to this DataValue
		/// </summary>
		public List<FormField> GetFieldsFor(DataValue dvalue)
		{
			//found fields
			FormField fieldMin = null, fieldMax = null;

			//if there's no values defined, exit
			if (dvalue == null) throw new ArgumentNullException("dvalue");

			if (dvalue.ValueType.Equals(typeof(DateTime)) || dvalue.ValueType.IsNumeric())
			{
				//search corresponding field for this DataValue
				foreach (FormField f in Fields)
				{
					if (f.Id == dvalue.Name + "_0") fieldMin = f;
					if (f.Id == dvalue.Name + "_1") fieldMax = f;
				}
				
				if (fieldMin != null && fieldMax != null) return new List<FormField>() { fieldMin, fieldMax };
			}
			else
			{
				//search corresponding field for this DataValue
				foreach (FormField f in Fields)
				{
					if (f.Id == dvalue.Name) return new List<FormField>() { f };
				}
			}

			//nothing was found
			return null;
		}
	}
}
