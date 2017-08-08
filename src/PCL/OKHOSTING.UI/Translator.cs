using static OKHOSTING.Core.TypeExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OKHOSTING.UI
{
	/// <summary>
	/// It represents a language translator where you return the request in the language in which this your dispocitivo.
	/// <para xml:lang="es">
	/// Representa un traductor del lenguaje donde te regresa la peticion en el lenguaje en el que este tu dispocitivo.
	/// </para>
	/// </summary>
	public static class Translator
	{
		/// <summary>
		/// Create a new Dictionary
		/// <para xml:lang="es">Crea un nuevo Dictionary</para>
		/// </summary>
		private readonly static Dictionary<Type, System.Resources.ResourceManager> Managers = new Dictionary<Type, System.Resources.ResourceManager>();

		/// <summary>
		/// Gets the string.
		/// <para xml:lang="es">Devuelve el manejador que corresponda con el nombre especificado.</para>
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="type">Type.</param>
		/// <param name="name">Name.</param>
		public static string GetString(Type type, string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new ArgumentNullException(nameof(name));
			}

			var resourceNames = type.GetTypeInfo().Assembly.GetManifestResourceNames();

			foreach (var resource in resourceNames)
			{
				try
				{
					var manager = new System.Resources.ResourceManager(resource.Replace(".resources", string.Empty), type.GetTypeInfo().Assembly);
					var result = manager.GetString(name);

					if (!string.IsNullOrWhiteSpace(result))
					{
						return result;
					}
				}
				catch { }
			}
		
			if(name.Contains("_"))
			{
				return name.Split('_').Last();
			}
			else
			{
				return name;
			}
		}

		/// <summary>
		/// Translate the specified type.
		/// <para xml:lang="es">Traduce el tipo especificado.</para>
		/// </summary>
		/// <param name="type">Type.</param>
		public static string Translate(Type type)
		{
			return GetString(type, type.GetFriendlyFullName().Replace('.', '_'));
		}

		/// <summary>
		/// Translate the specified member.
		/// </summary>
		/// <param name="member">Member.</param>
		public static string Translate(MemberInfo member)
		{
			return GetString(member.DeclaringType, member.GetFriendlyFullName().Replace('.', '_'));
		}

		/// <summary>
		/// Translate the specified enumValue.
		/// </summary>
		/// <param name="enumValue">Enum value.</param>
		public static string Translate(Enum enumValue)
		{
			return GetString(enumValue.GetType(), enumValue.GetType().GetFriendlyFullName().Replace('.', '_') + '_' + enumValue);
		}

		/// <summary>
		/// Returns an enum value, taking a translated string as input
		/// </summary>
		public static Enum DeTranslate(string enumTranslatedValue, Type enumType)
		{
			foreach (Enum unit in Enum.GetValues(enumType))
			{
				if(Translate(unit) == enumTranslatedValue)
				{
					return unit;
				}
			}

			return null;
		}

		public static string GenerateResource(Assembly assembly)
		{
			StringBuilder builder = new StringBuilder();

			foreach (var type in assembly.DefinedTypes)
			{
				builder.Append(GenerateResource(type));
			}

			return builder.ToString();
		}

		/// <summary>
		/// Generates the xml content that hsould be included in a resource file, containing all public fields, properties
		/// </summary>
		/// <param name="dtype"></param>
		/// <returns></returns>
		public static string GenerateResource(TypeInfo dtype)
		{
			StringBuilder builder = new StringBuilder();

			string t = string.Format(
@"<data name=""{0}"" xml:space=""preserve"">
	<value>{1}</value>
</data>", dtype.AsType().GetFriendlyFullName().Replace('.', '_'), SeparateCamelCase(dtype.Name));

			builder.AppendLine(t);

			foreach (var dmember in dtype.DeclaredMembers.Where(m => !m.IsCompilerGenerated() && !(m is ConstructorInfo)))
			{
				if (dmember.Name.StartsWith("get") || dmember.Name.StartsWith("set") || dmember.Name == "ToString")
				{
					continue;
				}
				
				string s = string.Format(
@"<data name=""{0}"" xml:space=""preserve"">
	<value>{1}</value>
</data>", dtype.AsType().GetFriendlyFullName().Replace('.', '_') + '_' + dmember.Name, SeparateCamelCase(dmember.Name));

				builder.AppendLine(s);
			}

			return builder.ToString();
		}

		private static string SeparateCamelCase(string s)
		{
			StringBuilder member = new StringBuilder();

			for (int i = 0; i < s.Length; i++)
			{
				char c = s[i];

				if (i > 0 && (char.IsUpper(c) || char.IsDigit(c)))
				{
					member.Append(' ');
					member.Append(char.ToLower(c));
				}
				else
				{
					member.Append(c);
				}
			}

			return member.ToString();
		}
	}
}