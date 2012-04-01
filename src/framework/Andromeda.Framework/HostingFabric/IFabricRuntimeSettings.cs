using System;
using Andromeda.Common.Configuration;
using Andromeda.Common.Messaging;

namespace Andromeda.Framework.HostingFabric
{
	public interface IFabricRuntimeSettings : IOverridableSettings
	{
		IOverridableSetting<IMessageChannel> ErrorChannel { get; set; }

		IOverridableSettingList<Type> HostedServices { get; set; }

		IOverridableSetting<IMessageChannel> InputChannel { get; set; }

		IOverridableSetting<Type> ServiceHost { get; set; }
	}
}