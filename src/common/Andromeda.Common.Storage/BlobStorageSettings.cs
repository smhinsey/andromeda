using Andromeda.Common.Configuration;
using Andromeda.Common.Storage.Binary;

namespace Andromeda.Common.Storage
{
	public class BlobStorageSettings : IBlobStorageSettings
	{
		public BlobStorageSettings()
		{
			ContainerName = new OverridableSetting<string>();

			ContainerName.WithDefault("andromeda-storage");
		}

		public IOverridableSetting<string> ContainerName { get; set; }
	}
}