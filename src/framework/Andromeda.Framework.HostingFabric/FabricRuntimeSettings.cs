﻿using System;
using Andromeda.Common.Configuration;
using Andromeda.Common.Messaging;

namespace Andromeda.Framework.HostingFabric
{
	public class FabricRuntimeSettings : IFabricRuntimeSettings
	{
		public FabricRuntimeSettings()
		{
			HostedServices = new OverridableSettingList<Type>();
			ServiceHost = new OverridableSetting<Type>();
			InputChannel = new OverridableSetting<IMessageChannel>();
			ErrorChannel = new OverridableSetting<IMessageChannel>();
		}

		public IOverridableSetting<IMessageChannel> ErrorChannel { get; set; }

		public IOverridableSettingList<Type> HostedServices { get; set; }

		public IOverridableSetting<IMessageChannel> InputChannel { get; set; }

		public IOverridableSetting<Type> ServiceHost { get; set; }
	}
}