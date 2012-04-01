using System;
using System.Collections.Generic;
using Andromeda.Common.Storage.NHibernate;
using Andromeda.Framework.Cqrs;
using LoggingAgent.ReadModels;
using NHibernate;
using IQuery = Andromeda.Framework.Cqrs.IQuery;

namespace LoggingAgent.Queries
{
	public class CommandRegistryQueries : IQuery
	{
		private readonly ISession _session;

		public CommandRegistryQueries(ISession session)
		{
			_session = session;
		}

		public PublicationRecords GetPublicationRecords(int offset, int recordsPerPage)
		{
			var records = _session.QueryOver<CommandPublicationRecord>().OrderBy(x => x.Created).Desc.Skip(offset).Take(recordsPerPage).List();

			return getRecords(records, offset, recordsPerPage);
		}

		public PublicationRecords GetFailedCommands(int offset, int recordsPerPage)
		{
			var records =
				_session.QueryOver<CommandPublicationRecord>().Where(x => x.Error).OrderBy(x => x.Created).Desc.Skip(offset).Take(recordsPerPage).List();

			return getRecords(records, offset, recordsPerPage);
		}

		public PublicationRecords GetUndispatchedCommands(int offset, int recordsPerPage)
		{
			var records =
				_session.QueryOver<CommandPublicationRecord>().Where(x => !x.Dispatched).OrderBy(x => x.Created).Desc.Skip(offset).
					Take(recordsPerPage).List();

			return getRecords(records, offset, recordsPerPage);
		}

		public PublicationRecords GetPublicationRecords<TCommand>(int offset, int recordsPerPage) where TCommand : ICommand
		{
			var records = _session.QueryOver<CommandPublicationRecord>().Where(x => x.MessageType == typeof(TCommand)).OrderBy(x => x.Created).Desc.Skip(offset).Take(recordsPerPage).List();

			return getRecords(records, offset, recordsPerPage);
		}

		public PublicationRecords GetFailedCommands<TCommand>(int offset, int recordsPerPage) where TCommand : ICommand
		{
			var records = _session.QueryOver<CommandPublicationRecord>().Where(x => x.MessageType == typeof(TCommand) && x.Error).OrderBy(x => x.Created).Desc.Skip(offset).Take(recordsPerPage).List();

			return getRecords(records, offset, recordsPerPage);
		}

		public PublicationRecords GetUndispatchedCommands<TCommand>(int offset, int recordsPerPage) where TCommand : ICommand
		{
			var records = _session.QueryOver<CommandPublicationRecord>().Where(x => x.MessageType == typeof(TCommand) && !x.Dispatched).OrderBy(x => x.Created).Desc.Skip(offset).Take(recordsPerPage).List();

			return getRecords(records, offset, recordsPerPage);
		}

		private PublicationRecords getRecords(IEnumerable<CommandPublicationRecord> records, int offset, int recordsPerPage)
		{
			var totalRecords = _session.QueryOver<CommandPublicationRecord>().RowCount();
			var totalPages = (int)Math.Ceiling((double)totalRecords / recordsPerPage);
			var currentPage = offset > totalPages*recordsPerPage ? totalPages : offset/recordsPerPage + 1;
			return new PublicationRecords
			{
				Records = records,
				TotalRecords = totalRecords,
				TotalPages = totalPages,
				CurrentPage = currentPage,
				PreviousPage = currentPage > 1 ? currentPage - 1 : 1,
				NextPage = currentPage < totalPages ? currentPage + 1 : totalPages,
				Offset = offset,
				RecordsPerPage = recordsPerPage,
				Created = DateTime.Now,
				Identifier = Guid.Empty,
				Modified = DateTime.Now
			};
		}
	}
}