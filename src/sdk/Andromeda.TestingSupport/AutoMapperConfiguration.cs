using System;
using System.Linq;
using FluentNHibernate;
using FluentNHibernate.Automapping;

namespace Andromeda.TestingSupport
{
	public class AutoMapperConfiguration : DefaultAutomappingConfiguration
	{
		private readonly Type[] _mappableTypes;

		public AutoMapperConfiguration(params Type[] mappableTypes)
		{
			_mappableTypes = mappableTypes;
		}

		public override bool IsId(Member member)
		{
			return member.Name == "Identifier";
		}

		public override bool ShouldMap(Type type)
		{
			var mapMe = false;

			foreach (var mappableType in _mappableTypes.Where(mappableType => mappableType == type))
			{
				mapMe = true;
			}

			return mapMe;
		}
	}
}