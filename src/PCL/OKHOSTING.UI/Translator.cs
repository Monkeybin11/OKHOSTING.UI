using static OKHOSTING.Core.TypeExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

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
		/// Gets the manager.
		/// <para xml:lang="es">Obtiene el manejador de recursos.</para>
		/// </summary>
		/// <returns>The manager.
		/// <para xml:lang="es">El manejador.</para>
		/// </returns>
		/// <param name="type">Type.</param>
		private static System.Resources.ResourceManager GetManager(Type type)
		{
			if (!Managers.ContainsKey(type))
			{
				Managers.Add(type, new System.Resources.ResourceManager(type));
			}

			return Managers[type];
		}

		/// <summary>
		/// Gets the string.
		/// <para xml:lang="es">Devuelve el manejador que corresponda con el nombre especificado.</para>
		/// </summary>
		/// <returns>The string.</returns>
		/// <param name="type">Type.</param>
		/// <param name="name">Name.</param>
		public static string GetString(Type type, string name)
		{
			try
			{
				return GetManager(type).GetString(name);
			}
			catch
			{
				//return string.Format("{0}.{1}", type.Name, name);
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
		public static string Translate(System.Reflection.MemberInfo member)
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
	}
}