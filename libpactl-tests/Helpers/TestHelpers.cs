using System.Collections.Generic;
using System.IO;

namespace PulseAudio.Tests.Helpers
{
	public static class TestHelpers
	{
		public static IEnumerable<string> ToEnumerable(this Stream stream)
		{
			if (stream == null)
			{
				yield break;
			}

			using (TextReader tr = new StreamReader(stream))
			{
				string line;
				while ((line = tr.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}
	}
}