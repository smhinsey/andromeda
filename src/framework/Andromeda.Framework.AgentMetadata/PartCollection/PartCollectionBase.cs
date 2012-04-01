using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Andromeda.Framework.AgentMetadata.Extensions;

namespace Andromeda.Framework.AgentMetadata.PartCollection
{
	public abstract class PartCollectionBase<T> : IPartCollection
		where T : IAgentPart
	{
		private readonly Assembly _agent;

		private readonly string _partNamespace;

		private string _agentSystemName;

		private IEnumerable<IPartMetadata> _collection;

		private Type _collectionType;

		private bool _init;

		private string _ns;

		protected PartCollectionBase(Assembly agent, string partNamespace)
		{
			_agent = agent;
			_partNamespace = partNamespace;
			Initialize();
		}

		public string AgentSystemName
		{
			get
			{
				if (!_init)
				{
					Initialize();
				}

				return _agentSystemName;
			}
		}

		public Type CollectionType
		{
			get
			{
				if (!_init)
				{
					Initialize();
				}

				return _collectionType;
			}
		}

		public abstract string DescriptiveName { get; }

		public string Namespace
		{
			get
			{
				if (!_init)
				{
					Initialize();
				}

				return _ns;
			}
		}

		public IMetadataFormatter GetFormatter()
		{
			return FormattableMetadataFactory.GetFormatter(this);
		}

		protected void Initialize()
		{
			_collection =
				_agent.GetTypes().Where(type => type.Namespace == _partNamespace && typeof(T).IsAssignableFrom(type)).Select(
					type => new PartMetadata(type)).Cast<IPartMetadata>().ToList();

			_collectionType = typeof(T);
			_agentSystemName = _agent.GetAgentSystemName();
			_ns = _partNamespace;

			_init = true;
		}

		public IEnumerator<IPartMetadata> GetEnumerator()
		{
			return _collection.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}