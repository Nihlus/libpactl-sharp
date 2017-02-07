using System.Collections.Generic;
using NUnit.Framework;
using PulseAudio.Tests.Helpers;

namespace PulseAudio.Tests.Parser
{
	[TestFixture]
	public class ParserTests
	{
		[Test]
		public void TestGetObjectInfoByID()
		{
			// Load the test sink output list
			IEnumerable<string> listSinkOutput =
				typeof(ParserTests).Assembly.GetManifestResourceStream("PulseAudio.Tests.Resources.DemoListSinkOutput").ToEnumerable();

			// Load the expected output
			IEnumerable<string> expectedSinkData =
				typeof(ParserTests).Assembly.GetManifestResourceStream("PulseAudio.Tests.Resources.Sink1ExpectedData").ToEnumerable();

			// Get the sink with ID 1
			IEnumerable<string> sinkData = PulseControlOutputParser.GetPulseObjectData(EPulseObject.Sink, 1, listSinkOutput);

			// Test that it matches, line by line, the expected data
			Assert.AreEqual(expectedSinkData, sinkData);
		}
	}
}