using NUnit.Framework;
using PulseAudio.Utility;

namespace PulseAudio.Tests.Utility
{
	[TestFixture]
	public class UtilityTests
	{
		[Test]
		public void TestToNativeFormat()
		{
			// Set up expected data
			const string expectedOutput = "set-default-sink";
			const EPulseCommand originalPulseCommandValue = EPulseCommand.SetDefaultSink;

			// Convert the original value
			string actualConvertedValue = originalPulseCommandValue.ToNativeFormat();

			// Assert
			Assert.AreEqual(expectedOutput, actualConvertedValue);
		}

		[Test]
		public void TestToFieldKeyFormat()
		{
			// Set up expected data
			const string expectedOutput = "Sink Input";
			const EPulseObject originalValue = EPulseObject.SinkInput;

			// Convert the original value
			string actualConvertedValue = originalValue.ToFieldKeyFormat();

			// Assert
			Assert.AreEqual(expectedOutput, actualConvertedValue);
		}
	}
}