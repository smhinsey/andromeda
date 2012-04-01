using System;
using System.Web.Mvc;
using Andromeda.Framework.AgentMetadata.Extensions;
using Andromeda.Framework.Models;

namespace Andromeda.Composites.Mvc.Models
{
	public abstract class DefaultInputModel : IInputModel
	{
		[HiddenInput(DisplayValue = false)]
		public string AgentSystemName { get { return CommandType != null ? CommandType.Assembly.GetAgentMetadata().SystemName : string.Empty; }}

		public Type CommandType { get; set; }

		[HiddenInput(DisplayValue = false)]
		public string PartName
		{
			get
			{
				return CommandType != null ? CommandType.Name : string.Empty;
			}
		}
	}
}