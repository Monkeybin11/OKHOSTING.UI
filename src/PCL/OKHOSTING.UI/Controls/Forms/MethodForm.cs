using System;
using System.Collections.Generic;
using System.Reflection;

namespace OKHOSTING.UI.Controls.Forms
{
	/// <summary>
	/// A form used to retrieve all parameters necessary for executing a DataMethod
	/// <para xml:lang="es">
	/// Es una forma de utilizarlo para recuperar todos los parametros necesarios para la ejecucion de un metodo de datos.
	/// </para>
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
		/// Adds a field for every argument that the DataMethos needs in order to be invoked.
		/// <para xml:lang="es">
		/// Agrega un campo para cada argumento que el DataMethods necesita para ser invocado.
		/// </para>
		/// </summary>
		/// <param name="method">DataMethod which parameters will be used as fields.
		/// <para xml:lang="es">DataMethod de los parametrtos que se utilizan como campos.</para>
		/// </param>
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
		/// Copies all field values to a list of objects that will be used as parameters to invoke a DataMethod.
		/// <para xml:lang="es">
		/// Copia todos los valores del campo a una lista de objetos que seran utilizados como parametros para invocar un DataMethod.
		/// </para>
		/// </summary>
		/// <param name="parameters">List of objects that will be used as parameters to invoke a DataMethod.
		/// <para xml:lang="es">Lista de parametros que seran utilizados como parametros para invocar un DataMethod.</para>
		/// </param>
		public virtual IEnumerable<object> GetParameters()
		{
			//search corresponding field for this DataValueInstance
			foreach (FormField f in Fields)
			{
				yield return f.Value;
			}
		}

		/// <summary>
		/// Creates the field of specified type.
		/// <para xml:lang="es">Crea el campo del tipo especificado.</para>
		/// </summary>
		/// <returns>The field from.</returns>
		/// <param name="type">Type.</param>
		protected virtual FormField CreateFieldFrom(Type type)
		{
			return FormField.CreateFieldFrom(type);
		}
	}
}