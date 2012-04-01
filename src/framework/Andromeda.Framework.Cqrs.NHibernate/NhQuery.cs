﻿using System;
using System.Collections.Generic;
using Andromeda.Common.Storage.NHibernate;
using Andromeda.Framework.Models;
using NHibernate;

namespace Andromeda.Framework.Cqrs.NHibernate
{
	/// <summary>
	/// 	NhQuery wraps an NhSimpleRepository in order to provide read-only access
	/// 	to a database managed by NHibernate.
	/// </summary>
	/// <typeparam name = "TReadModel"></typeparam>
	public class NhQuery<TReadModel> : IQuery<TReadModel>
		where TReadModel : class, IReadModel
	{
		internal readonly NhSimpleRepository<TReadModel> Repository;

		public NhQuery(ISession session)
		{
			Repository = new NhSimpleRepository<TReadModel>(session);
		}

		public IList<TReadModel> FindByCreationDate(DateTime specificDate)
		{
			return Repository.FindByCreationDate(specificDate);
		}

		public IList<TReadModel> FindByCreationDate(DateTime begin, DateTime end)
		{
			return Repository.FindByCreationDate(begin, end);
		}

		public virtual TReadModel FindById(Guid id)
		{
			return Repository.FindById(id);
		}

		public IList<TReadModel> FindByModificationDate(DateTime specificDate)
		{
			return Repository.FindByModificationDate(specificDate);
		}

		public IList<TReadModel> FindByModificationDate(DateTime begin, DateTime end)
		{
			return Repository.FindByModificationDate(begin, end);
		}

		public IList<TReadModel> List(int offset, int pageSize)
		{
			return Repository.List(offset, pageSize);
		}

		protected ISession GetCurrentSession()
		{
			return Repository.GetCurrentSession();
		}
	}
}