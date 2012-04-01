using System;

namespace Andromeda.Framework.Agent
{
	[AttributeUsage(AttributeTargets.Assembly)]
	public class LocationOfCommandsAttribute : NamespaceFinderAttribute
	{
	}
}