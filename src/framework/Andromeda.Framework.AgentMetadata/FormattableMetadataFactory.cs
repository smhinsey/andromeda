using System;
using Andromeda.Framework.AgentMetadata.Formatters;
using Andromeda.Framework.Cqrs;
using Andromeda.Framework.Models;

namespace Andromeda.Framework.AgentMetadata
{
	public class FormattableMetadataFactory
	{
		public static IMetadataFormatter GetFormatter(Type metadataSource)
		{
			var metadata = new TypeMetadata(metadataSource);

			return GetFormatter(metadata);
		}

		public static IMetadataFormatter GetFormatter(ITypeMetadata metadata)
		{
			if (typeof(ICommand).IsAssignableFrom(metadata.Type))
			{
				return new CommandMetadataFormatter(metadata);
			}
			else if (typeof(IReadModel).IsAssignableFrom(metadata.Type))
			{
				return new ReadModelFormatter(metadata);
			}
			else if (typeof(IQuery).IsAssignableFrom(metadata.Type))
			{
				return new QueryFormatter(metadata);
			}
			else if (typeof(IInputModel).IsAssignableFrom(metadata.Type))
			{
				return new InputModelFormatter(metadata);
			}

			return new DefaultFormatter(metadata);
		}

		public static IMetadataFormatter GetFormatter(IPartCollection metadata)
		{
			if (typeof(ICommand).IsAssignableFrom(metadata.CollectionType))
			{
				return new CommandCollectionFormatter(metadata);
			}
			else if (typeof(IReadModel).IsAssignableFrom(metadata.CollectionType))
			{
				return new ReadModelCollectionFormatter(metadata);
			}
			else if (typeof(IQuery).IsAssignableFrom(metadata.CollectionType))
			{
				return new QueryCollectionFormatter(metadata);
			}

			throw new AgentPartFormatterNotFoundException(metadata.CollectionType.Name);
		}
	}
}