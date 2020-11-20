using OKHOSTING.Core;
using OKHOSTING.Data.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OKHOSTING.UI.Builders.Editors
{
	/// <summary>
	/// Creates an editor for a specific type or member
	/// </summary>
	public class EditorBuilder
	{
		/// <summary>
		/// Creates a editor that will contain a value of a specific type
		/// <para xml:lang="es">
		/// Crea un campo que contendra un valor de un tipo especifico.
		/// </para>
		/// </summary>
		public virtual Editor For(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}

			if (Nullable.GetUnderlyingType(type) != null)
			{
				type = Nullable.GetUnderlyingType(type);
			}

			//Enum
			if (type.GetTypeInfo().IsEnum)
			{
				return new EnumEditor(type);
			}

			//Type, ignore this since we can't know if type means Person (as in a serializable object) or typeof(Person) as a type which child types you would choose from
			//else if (type.Equals(typeof(Type)))
			//{
			//	return new TypeEditor(type);
			//}

			//Bool
			else if (type.Equals(typeof(bool)))
			{
				return new CheckBoxBoolEditor();
			}

			//DateTime
			else if (type.Equals(typeof(DateTime)))
			{
				//editor = new DateTimeField();
				return new DateTimeEditor();
			}

			//TimeSpan
			else if (type.Equals(typeof(TimeSpan)))
			{
				return new TimeSpanEditor();
			}

			//Numeric
			else if (type.IsNumeric())
			{
				if (type.IsIntegral())
				{
					return new IntegerEditor();
				}
				else
				{
					return new DecimalEditor();
				}
			}

			//String serializable
			else if (type.GetTypeInfo().ImplementedInterfaces.Contains(typeof(Data.IStringSerializable)))
			{
				return new StringSerializableEditor(type);
			}

			//XML
			else if (type.GetTypeInfo().ImplementedInterfaces.Contains(typeof(System.Xml.Serialization.IXmlSerializable)))
			{
				return new XmlSerializableEditor(type);
			}

			//Uri
			else if (type.Equals(typeof(Uri)))
			{
				return new TextBoxEditor<Uri>(500, RegexPatterns.Url);
			}

			//String
			else if (type.Equals(typeof(string)))
			{
				return new TextBoxEditor<string>();
			}

			//guid
			else if (type.Equals(typeof(Guid)))
			{
				return new TextBoxEditor<Guid>();
			}

			//byte[]
			else if (type.Equals(typeof(byte[])))
			{
				return new BinaryEditor();
			}

			else if (type.IsEnumerable())
			{
				return new OneItemPerLineEditor(type.GetEnumerableItemType());
			}

			//otherwise just create a json textbox
			else
			{
				return new JsonEditor(type);
			}
		}

		/// <summary>
		/// Creates a editor for a DataMember
		/// <para xml:lang="es">
		/// Crea un campo para un DataMember
		/// </para>
		/// </summary>
		public virtual Editor For(MemberInfo member)
		{
			//if there's no values defined, exit
			if (member == null) throw new ArgumentNullException(nameof(member));

			//editor
			Editor editor;
			Type returnType = Data.MemberExpression.GetReturnType(member);

			//String
			if (returnType.Equals(typeof(string)))
			{
				if (member.Name.ToLower() == "password" || member.Name.ToLower() == "pwd")
				{
					editor = new PasswordEditor();
				}
				else
				{
					//set max lenght, if defined
					int maxLenght = (int) StringLengthValidator.GetMaxLength(member);

					if (maxLenght == 0)
					{
						editor = new LongStringEditor();
					}
					else
					{
						editor = new TextBoxEditor<string>(maxLenght);
					}

					//set regular expression validation, if defined
					var regex = member.CustomAttributes.Where(att => att.AttributeType.Equals(typeof(RegexValidator))).SingleOrDefault();

					if (regex != null)
					{
						((TextBoxEditor<string>) editor).RegularExpression = (string) regex.ConstructorArguments[0].Value;
					}
				}
			}

			//otherwise delegate to the static method to create the editor from the return type
			else
			{
				editor = For(returnType);
			}

			editor.Required = RequiredValidator.IsRequired(member);
			editor.Control.Name = $"editor_{member.Name}";

			return editor;
		}

		/// <summary>
		/// Creates fields for every Member
		/// <para xml:lang="es">
		/// Agrega campos para cada miembro 
		/// </para>
		/// </summary>
		public virtual IEnumerable<Editor> For(IEnumerable<MemberInfo> members)
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
		/// Creates fields for every Member that is mapped on a persistent object
		/// <para xml:lang="es">
		/// Agrega campos para cada miembro que se asigna en un objeto persistente
		/// </para>
		/// </summary>
		/// <param name="instance">
		/// Object which values will be copied to the form
		/// <para xml:lang="es">
		/// Objeto que se van a copiar al formulario
		/// </para>
		/// </param>
		public virtual IEnumerable<Editor> For(object instance, IEnumerable<MemberInfo> members)
		{
			//validate arguments
			if (instance == null) throw new ArgumentNullException(nameof(instance));

			//create fields
			foreach (MemberInfo member in members)
			{
				Editor editor = For(member);
				editor.Value = Data.MemberExpression.GetValue(member, instance);

				yield return editor;
			}
		}

		/// <summary>
		/// Creates fiels for all the parameters that a method needs to be executed
		/// </summary>
		public virtual IEnumerable<Editor> For(MethodInfo method)
		{
			//add a editor for each parameter
			foreach (ParameterInfo param in method.GetParameters())
			{
				Editor editor = For(param.ParameterType);
				editor.Required = !param.IsOptional && !param.IsOut;

				yield return editor;
			}
		}
	}
}