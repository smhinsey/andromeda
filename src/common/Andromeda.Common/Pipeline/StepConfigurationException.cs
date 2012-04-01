using System;

namespace Andromeda.Common.Pipeline
{
	public class StepConfigurationException : Exception
	{
		public StepConfigurationException(string msg)
			: base(msg)
		{
		}

		public StepConfigurationException()
		{
		}
	}
}