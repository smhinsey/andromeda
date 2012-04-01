﻿namespace Andromeda.Common.Configuration
{
	public class OverridableSetting<TSettingType> : IOverridableSetting<TSettingType>
	{
		public TSettingType DefaultValue { get; private set; }

		public TSettingType Value { get; private set; }

		public bool WasOverridden { get; private set; }

		public void ApplyOverride(TSettingType newValue)
		{
			Value = newValue;
			WasOverridden = true;
		}

		public void WithDefault(TSettingType value)
		{
			DefaultValue = value;
			Value = value;
		}
	}
}