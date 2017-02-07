using System.Collections.Generic;

namespace PulseAudio.Formats
{
	public struct FormatInfo
	{
		public EFormatEncoding Encoding;
		public Dictionary<string, string> Properties;
	}
}