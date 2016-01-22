using static OKHOSTING.Core.TypeExtensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OKHOSTING.UI
{
	public static class Translator
	{
		private readonly static Dictionary<Type, System.Resources.ResourceManager> Managers = new Dictionary<Type, System.Resources.ResourceManager>();

		private static System.Resources.ResourceManager GetManager(Type type)
		{
			if (!Managers.ContainsKey(type))
			{
				Managers.Add(type, new System.Resources.ResourceManager(type));
			}

			return Managers[type];
		}

		public static string GetString(Type type, string name)
		{
			return GetManager(type).GetString(name);
		}

		public static string Translate(Type type)
		{
			return GetString(type, type.GetFriendlyFullName().Replace('.', '_'));
		}

		public static string Translate(System.Reflection.MemberInfo member)
		{
			return GetString(member.DeclaringType, member.GetFriendlyFullName().Replace('.', '_'));
		}

		public static string Translate(Enum enumValue)
		{
			return GetString(enumValue.GetType(), enumValue.GetType().GetFriendlyFullName().Replace('.', '_') + '_' + enumValue);
		}
	}
}