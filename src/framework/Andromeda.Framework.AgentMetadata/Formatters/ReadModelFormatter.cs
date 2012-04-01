using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace Andromeda.Framework.AgentMetadata.Formatters
{
	internal class ReadModelFormatter : MetadataFormatter
	{
		private readonly ITypeMetadata _partMetadata;

		public ReadModelFormatter(ITypeMetadata partMetadata)
		{
			_partMetadata = partMetadata;
		}

		protected override string GetAsXml()
		{
			var root = new XElement("ReadModel");

			foreach (var p in _partMetadata.Properties)
			{
				root.Add(
					new XElement("Property", new XElement("PropertyName", p.Name), new XElement("PropertyType", p.PropertyType.Name)));
			}

			return root.ToString();
		}

		public override object GetJsonObject(JsonSerializer serializer)
		{
			return _partMetadata.Properties.Select(p => new { PropertyName = p.Name, PropertyType = p.PropertyType.Name });
		}
	}
}