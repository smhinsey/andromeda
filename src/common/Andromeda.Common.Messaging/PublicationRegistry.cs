﻿using System;
using System.Collections.Generic;
using System.Linq;
using Andromeda.Common.Storage;
using Andromeda.Common.Storage.Binary;
using Andromeda.Common.Storage.Record;

namespace Andromeda.Common.Messaging
{
	public class PublicationRegistry<TRecord, TRecordContract> : IPublicationRegistry<TRecord, TRecordContract>
		where TRecord : class, TRecordContract, IPublicationRecord, new() where TRecordContract : IPublicationRecord
	{
		protected readonly IBlobStorage BlobStorage;

		protected readonly IRecordMapper<TRecord> Mapper;

		protected readonly IMessageSerializer Serializer;

		public PublicationRegistry(IRecordMapper<TRecord> mapper, IBlobStorage blobStorage, IMessageSerializer serializer)
		{
			Mapper = mapper;
			BlobStorage = blobStorage;
			Serializer = serializer;
		}

		public virtual IMessage GetMessage(Uri messageLocation, Type recordType)
		{
			var messageBlob = BlobStorage.Get(messageLocation);

			return Convert.ChangeType(Serializer.Deserialize(messageBlob.Content), recordType) as IMessage;
		}

		public TRecordContract GetPublicationRecord(Guid identifier)
		{
			return Mapper.Retrieve(identifier);
		}

		public IList<IPublicationRecord> GetRecords(int pageSize, int offSet)
		{
			return Mapper.List(pageSize, offSet).Cast<IPublicationRecord>().ToList();
		}

		public virtual TRecordContract MarkAsComplete(Guid identifier)
		{
			return updateRecord(
				identifier,
				r =>
					{
						r.Completed = true;
						r.Dispatched = true;
						r.Error = false;
					});
		}

		public virtual TRecordContract MarkAsFailed(Guid identifier, string message, string callStack)
		{
			return updateRecord(
				identifier,
				r =>
					{
						r.Dispatched = true;
						r.Completed = true;
						r.Error = true;
						r.ErrorMessage = message;
						r.CallStack = callStack;
					});
		}

		public virtual TRecordContract MarkAsUnableToDispatch(Guid identifier, bool isError = false, string message = null)
		{
			return updateRecord(
				identifier,
				r =>
					{
						r.Dispatched = false;
						r.Completed = true;
						r.Error = isError;
						r.ErrorMessage = string.IsNullOrEmpty(message) ? string.Empty : message;
					});
		}

		public virtual TRecordContract PublishMessage(IMessage message)
		{
			var msgBlob = new Blob { Content = Serializer.Serialize(message), ContentType = "application/octet-stream" };

			var uri = BlobStorage.Put(msgBlob, message.GetType().FullName);

			var record = new TRecord
				{ Identifier = Guid.NewGuid(), Created = DateTime.Now, MessageLocation = uri, MessageType = message.GetType() };

			return Mapper.Create(record);
		}

		private TRecordContract updateRecord(Guid id, Action<TRecordContract> actOnRecord)
		{
			var record = GetPublicationRecord(id);

			actOnRecord(record);

			return Mapper.Update((TRecord)record);
		}
	}
}