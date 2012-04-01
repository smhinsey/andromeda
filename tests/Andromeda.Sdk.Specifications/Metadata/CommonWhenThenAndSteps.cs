using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Andromeda.Sdk.Specifications.Metadata
{
	[Binding]
	public class CommonWhenThenAndSteps : PropertiesUsedInTests
	{
		[Then(@"has been independently validated")]
		public void IndependentlyValidate()
		{
			Assert.NotNull(Formatter);

			Assert.False(string.IsNullOrEmpty(Format));

			var representation = Formatter.GetRepresentation(Format);

			Assert.False(string.IsNullOrEmpty(representation));

			Console.WriteLine(representation);
		}

		[Then(@"it can be represented as (.*)")]
		public void ItCanBeRepresentedAs(string contentType)
		{
			Assert.NotNull(Formatter);

			Assert.False(string.IsNullOrEmpty(Format));

			Assert.False(string.IsNullOrEmpty(contentType));

			Assert.AreEqual(contentType, Formatter.GetContentType(Format));

			Assert.True(Formatter.GetFormats(contentType).Contains(Format));
		}

		[When(@"metadata is requested as (.*)")]
		public void MetadataIsRequested(string format)
		{
			Assert.False(string.IsNullOrEmpty(format));

			Format = format;
		}
	}
}