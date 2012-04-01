﻿using System;
using Andromeda.Framework.Cqrs;
using EventStore;

namespace Andromeda.Framework.EventSourcing
{
	/// <summary>
	/// 	The EventRecorder is responsible for persisting IEvents within an EventStore stream.
	/// </summary>
	public class EventRecorder : DefaultCommandProcessor<IEvent>
	{
		private readonly IStoreEvents _eventStore;

		private readonly Guid _streamId;

		public EventRecorder(IStoreEvents eventStore, Guid streamId)
		{
			_eventStore = eventStore;
			_streamId = streamId;
		}

		public override void Process(IEvent message)
		{
			using (var stream = _eventStore.CreateStream(_streamId))
			{
				stream.Add(new EventMessage { Body = message });
			}
		}
	}
}