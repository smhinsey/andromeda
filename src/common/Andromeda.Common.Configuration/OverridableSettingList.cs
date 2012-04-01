﻿using System.Collections.Generic;

namespace Andromeda.Common.Configuration
{
	public class OverridableSettingList<TSettingType> : IOverridableSettingList<TSettingType>
	{
		public OverridableSettingList()
		{
			DefaultValue = new List<TSettingType>();
			Value = new List<TSettingType>();
		}

		public IList<TSettingType> DefaultValue { get; private set; }

		public IList<TSettingType> Value { get; private set; }

		public bool WasOverridden { get; private set; }

		public void Add(TSettingType newListItem)
		{
			Value.Add(newListItem);
		}

		public void ApplyOverride(IList<TSettingType> newValue)
		{
			Value = newValue;
			WasOverridden = true;
		}

		public void WithDefault(IList<TSettingType> value)
		{
			DefaultValue = value;
			Value = value;
		}
	}
}