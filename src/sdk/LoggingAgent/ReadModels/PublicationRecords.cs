using System.Collections.Generic;
using Andromeda.Common.Messaging;
using Andromeda.Framework.Models;

namespace LoggingAgent.ReadModels
{
	public class PublicationRecords : SyntheticReadModel
	{
		public int Offset { get; set; }
		public int RecordsPerPage { get; set; }
		public int TotalRecords { get; set; }
		public int TotalPages { get; set; }
		public int CurrentPage;
		public int NextPage { get; set; }
		public int PreviousPage { get; set; }
		public IEnumerable<IPublicationRecord> Records { get; set; }
	}
}