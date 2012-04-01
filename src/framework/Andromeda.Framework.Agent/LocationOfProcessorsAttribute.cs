using System;

namespace Andromeda.Framework.Agent
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public class LocationOfProcessorsAttribute : NamespaceFinderAttribute
	{
	}
}