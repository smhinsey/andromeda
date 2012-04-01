using System.Collections.Generic;
using Andromeda.Framework.Cqrs;
using Andromeda.Framework.Models;

namespace Andromeda.TestingSupport
{
	public interface IValidateListOfReadModels<in TQuery, TReadModel>
		where TQuery : IQuery<TReadModel> where TReadModel : IReadModel
	{
		void ValidateList(TQuery query, IList<TReadModel> readModels);
	}
}