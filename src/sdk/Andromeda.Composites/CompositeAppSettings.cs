using System.Collections.Generic;
using Andromeda.Common.Configuration;
using Andromeda.Common.Messaging;
using Andromeda.Common.Storage;
using Andromeda.Common.Storage.Binary;
using Andromeda.Common.Storage.Record;
using Andromeda.Framework.Cqrs;

namespace Andromeda.Composites
{
	public class CompositeAppSettings : IOverridableSettings
	{
		public readonly OverridableTypeSetting<IBlobStorage> BlobStorage;

		public readonly OverridableTypeSetting<ICommandDispatcher> CommandDispatcher;

		public readonly OverridableTypeSetting<IRecordMapper<CommandPublicationRecord>> CommandPublicationRecordMapper;

		public readonly OverridableSetting<IInputModelMapCollection> InputModelMaps;

		public readonly OverridableTypeSetting<IMessageSerializer> MessageSerializer;

		public readonly OverridableTypeSetting<IMessageChannel> OutputChannel;

		public readonly OverridableSetting<string> OutputChannelName;

		public readonly OverridableTypeSetting<IPublicationRegistry<IPublicationRecord, IPublicationRecord>>
			PublicationRegistry;

		public readonly OverridableTypeSetting<IPublisher> Publisher;

		public CompositeAppSettings()
		{
			OutputChannelName = new OverridableSetting<string>();
			OutputChannel = new OverridableTypeSetting<IMessageChannel>("OutputChannel");
			BlobStorage = new OverridableTypeSetting<IBlobStorage>("BlobStorage");
			CommandDispatcher = new OverridableTypeSetting<ICommandDispatcher>("CommandDispatcher");
			CommandPublicationRecordMapper =
				new OverridableTypeSetting<IRecordMapper<CommandPublicationRecord>>("CommandPublicationRecordMapper");
			MessageSerializer = new OverridableTypeSetting<IMessageSerializer>("MessageSerializer");
			PublicationRegistry =
				new OverridableTypeSetting<IPublicationRegistry<IPublicationRecord, IPublicationRecord>>("PublicationRegistry");
			Publisher = new OverridableTypeSetting<IPublisher>("Publisher");
			InputModelMaps = new OverridableSetting<IInputModelMapCollection>();

			OutputChannelName.WithDefault("OutputChannelName");
			BlobStorage.WithDefault(typeof(InMemoryBlobStorage));
			CommandDispatcher.WithDefault(typeof(CommandDispatcher));
			CommandPublicationRecordMapper.WithDefault(typeof(InMemoryCommandPublicationRecordMapper));
			MessageSerializer.WithDefault(typeof(JsonMessageSerializer));
			PublicationRegistry.WithDefault(typeof(CommandRegistry));
			Publisher.WithDefault(typeof(DefaultPublisher));
			InputModelMaps.WithDefault(new AutoMapperInputModelCollection());
		}

		public IEnumerable<string> GetInvalidSettingReasons()
		{
			var reasons = new List<string>();
			GetInvalidSettingReason(OutputChannel, reasons);
			GetInvalidSettingReason(BlobStorage, reasons);
			GetInvalidSettingReason(CommandDispatcher, reasons);
			GetInvalidSettingReason(CommandPublicationRecordMapper, reasons);
			GetInvalidSettingReason(MessageSerializer, reasons);
			GetInvalidSettingReason(PublicationRegistry, reasons);
			GetInvalidSettingReason(Publisher, reasons);

			return reasons;
		}

		public void Validate()
		{
			OutputChannel.Validate();
			BlobStorage.Validate();
			CommandDispatcher.Validate();
			CommandPublicationRecordMapper.Validate();
			MessageSerializer.Validate();
			PublicationRegistry.Validate();
			Publisher.Validate();
		}

		private void GetInvalidSettingReason<T>(OverridableTypeSetting<T> setting, IList<string> reasons)
		{
			if (!setting.IsValid())
			{
				reasons.Add(setting.GetInvalidReason());
			}
		}
	}
}