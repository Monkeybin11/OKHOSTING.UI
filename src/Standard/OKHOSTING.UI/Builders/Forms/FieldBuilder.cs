using OKHOSTING.Core;
using OKHOSTING.UI.Builders.Editors;
using OKHOSTING.UI.Controls;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OKHOSTING.UI.Builders.Forms
{
	/// <summary>
	/// Creates an editor for a specific type or member
	/// </summary>
	public class FieldBuilder
	{
		public readonly EditorBuilder EditorBuilder;

		public FieldBuilder()
		{
			EditorBuilder = BaitAndSwitch.Create<EditorBuilder>();
		}

		public FieldBuilder(EditorBuilder editorBuilder)
		{
			if (editorBuilder == null)
			{
				EditorBuilder = BaitAndSwitch.Create<EditorBuilder>();
			}
			else
			{
				EditorBuilder = editorBuilder;
			}
		}

		/// <summary>
		/// Creates a field for a DataMember
		/// <para xml:lang="es">
		/// Crea un campo para un DataMember
		/// </para>
		/// </summary>
		public virtual Field For(MemberInfo member)
		{
			//if there's no values defined, exit
			if (member == null) throw new ArgumentNullException(nameof(member));

			//field
			Field field = new Field();
			field.Name = member.Name;
			field.Editor = EditorBuilder.For(member);
			field.Caption.Text = Translator.Translate(member);

			return field;
		}

		/// <summary>
		/// Creates fields for every Member
		/// <para xml:lang="es">
		/// Agrega campos para cada miembro 
		/// </para>
		/// </summary>
		public virtual IEnumerable<Field> For(IEnumerable<MemberInfo> members)
		{
			//validate arguments
			if (members == null) throw new ArgumentNullException(nameof(members));

			//create fields
			foreach (MemberInfo member in members)
			{
				yield return For(member);
			}
		}

		/// <summary>
		/// Creates fields for every member and inits the Field value from the instance
		/// <para xml:lang="es">
		/// Agrega campos para cada miembro que se asigna en un objeto persistente
		/// </para>
		/// </summary>
		/// <param name="instance">
		/// Object which values will be copied to the fields
		/// <para xml:lang="es">
		/// Objeto que se van a copiar a los campos
		/// </para>
		/// </param>
		public virtual IEnumerable<Field> For(object instance, IEnumerable<MemberInfo> members)
		{
			//validate arguments
			if (instance == null)
			{
				throw new ArgumentNullException(nameof(instance));
			}

			if (members == null)
			{
				throw new ArgumentNullException(nameof(members));
			}

			//create fields
			foreach (MemberInfo member in members)
			{
				var field = For(member);
				field.Editor.Value = Data.MemberExpression.GetValue(member, instance);

				yield return field;
			}
		}

		/// <summary>
		/// Creates fiels for all the parameters that a method needs to be executed
		/// </summary>
		public virtual IEnumerable<Field> For(MethodInfo method)
		{
			//add a field for each parameter
			foreach (ParameterInfo param in method.GetParameters())
			{
				//field
				Field field = new Field();
				field.Name = param.Name;
				field.Caption = BaitAndSwitch.Create<ILabel>();
				field.Caption.Text = Translator.Translate(param);
				field.Editor = EditorBuilder.For(param.ParameterType);
				field.Editor.Required = !param.IsOptional && !param.IsOut;

				yield return field;
			}
		}
	}
}