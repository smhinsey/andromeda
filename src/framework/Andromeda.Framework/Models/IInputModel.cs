using System;

namespace Andromeda.Framework.Models
{
	public interface IInputModel
	{
		string AgentSystemName { get; }

		Type CommandType { get; set; }

		string PartName { get; }
	}
}