using System;
using System.Linq;
using Andromeda.Common.Messaging;
using Andromeda.Common.Storage;
using Andromeda.Common.Storage.NHibernate;
using Andromeda.Common.TestingFakes.Storage;
using Andromeda.Common.UnitTests.Storage;
using Andromeda.TestingSupport;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;

namespace Andromeda.Common.IntegrationTests.Storage
{
	[TestFixture]
	[Category(TestCategories.Integration)]
	public class NhRecordMapperTests
	{
		private ISession _session;

		private RecordMapperTester<NhRecordMapper<FakePublicationRecord>> _tester;

		public void ConfigureDatabase()
		{
			var cfg = new AutoMapperConfiguration(typeof(FakeMessage), typeof(FakePublicationRecord));

			_session =
				Fluently.Configure().Database(SQLiteConfiguration.Standard.UsingFile("NhRecordMapperTests")).Mappings(
					map => map.AutoMappings.Add(AutoMap.AssemblyOf<FakeMessage>(cfg))).ExposeConfiguration(buildSchema).
					BuildSessionFactory().OpenSession();
		}

		[SetUp]
		public void Setup()
		{
			if (_session == null)
			{
				ConfigureDatabase();
			}

			var storage = new InMemoryBlobStorage();
			var serializer = new JsonMessageSerializer();
			var repo = new NhRecordMapper<FakePublicationRecord>(_session);

			_tester = new RecordMapperTester<NhRecordMapper<FakePublicationRecord>>(repo);
		}

		[Test]
		public void TestAutoMap()
		{
			Assert.Null(_session.Query<FakeMessage>().FirstOrDefault());

			var primaryKey = (Guid)_session.Save(new FakeMessage { Created = DateTime.Now, CreatedBy = Guid.NewGuid() });
			Assert.NotNull(primaryKey);
			_session.Flush();

			var message = _session.Query<FakeMessage>().Where(m => m.Identifier == primaryKey).FirstOrDefault();
			Assert.NotNull(message);
			Assert.AreEqual(primaryKey, message.Identifier);
		}

		[Test]
		public void TestCreate()
		{
			_tester.TestCreate();
		}

		[Test]
		public void TestDelete()
		{
			_tester.TestDelete();
		}

		[Test]
		public void TestList()
		{
			_tester.TestList();
		}

		[Test]
		public void TestListPagination()
		{
			_tester.TestList();
		}

		[Test]
		public void TestRetrieve()
		{
			_tester.TestRetrieve();
		}

		[Test]
		public void TestUpdate()
		{
			_tester.TestUpdate();
		}

		private static void buildSchema(NHibernate.Cfg.Configuration cfg)
		{
			new SchemaExport(cfg).Create(false, true);
		}
	}
}