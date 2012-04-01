using System;
using Andromeda.Framework.AgentMetadata.PartCollection;

namespace Andromeda.Framework.AgentMetadata.Extensions
{
	public static class TypeExtensions
	{
		public static ITypeMetadata GetMetadata(this Type type)
		{
			if (typeof(IAgentPart).IsAssignableFrom(type))
			{
				return new PartMetadata(type);
			}

			return new TypeMetadata(type);
		}

		public static IPartMetadata GetPartMetadata(this Type type)
		{
			if (!typeof(IAgentPart).IsAssignableFrom(type))
			{
				throw new InvalidAgentPartImplementationException(type);
			}

			return new PartMetadata(type);
		}

		public static string GetDefaultValue(this Type type)
		{
			string value = null;
			if (type.IsValueType)
			{
				value = Activator.CreateInstance(type).ToString();
			}
			else if (type == typeof(string))
			{
				value = string.Empty;
			}

			return value;
		}
	}
}