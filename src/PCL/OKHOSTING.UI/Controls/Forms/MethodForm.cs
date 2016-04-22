using OKHOSTING.Core;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A form used to retrieve all parameters necessary for executing a DataMethod
	/// </summary>
	public class MethodForm: Form
	{
		public readonly MethodInfo Method;

		public MethodForm(MethodInfo method)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}

			Method = method;
		}

		/// <summary>
		/// Adds a field for every argument that the DataMethos needs in order to be invoked
		/// </summary>
		/// <param name="method">DataMethod which parameters will be used as fields</param>
		public override void DataBind()
		{
			uint order = 0;

			//add a field for each parameter
			foreach (ParameterInfo param in Method.GetParameters())
			{
				FormField field;

				field = CreateFieldFrom(param.ParameterType);
				
				//set common values
				field.Container = this;
				field.Name = param.Name;
				field.Required = !param.IsOptional && !param.IsOut;
				//field.CaptionControl.Text = new System.Resources.ResourceManager(Method.DeclaringType).GetString(Method.GetFriendlyFullName().Replace('.', '_') + '_' + param.Name);
				field.CaptionControl.Text = param.Name;
				field.SortOrder = order++;

				Fields.Add(field);
			}

			base.DataBind();
		}

		/// <summary>
		/// Copies all field values to a list of objects that will be used as parameters to invoke a DataMethod
		/// </summary>
		/// <param name="parameters">List of objects that will be used as parameters to invoke a DataMethod</param>
		public virtual IEnumerable<object> GetParameters()
		{
			//search corresponding field for this DataValueInstance
			foreach (FormField f in Fields)
			{
				yield return f.Value;
			}
		}

		protected virtual FormField CreateFieldFrom(Type type)
		{
			return FormField.CreateFieldFrom(type);
		}
	}
}