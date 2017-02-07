using System;
using System.Collections.Generic;
using PulseAudio.Utility;

namespace PulseAudio
{
	public class PulseControlOutputParser
	{
		public static int ParseObjectIndex(string line)
		{
			int indexStartIndex = line.IndexOf("#", StringComparison.InvariantCultureIgnoreCase);
			if (indexStartIndex >= 0)
			{
				int objectIndex;
				if (Int32.TryParse(line.Substring(indexStartIndex + 1), out objectIndex))
				{
					return objectIndex;
				}
			}

			return -1;
		}

		public static IEnumerable<string> GetPulseObjectData(EPulseObject objectType, uint index)
		{
			IEnumerable<string> controlOutput = PulseControlInterface.GetPulseControlOutput(EPulseCommand.List, objectType.ToNativeFormat());
			return GetPulseObjectData(objectType, index, controlOutput);
		}

		public static IEnumerable<string> GetPulseObjectData(EPulseObject objectType, uint index,
			IEnumerable<string> dataToSearch)
		{
			bool hasFoundObject = false;
			foreach (string line in dataToSearch)
			{
				if (line.StartsWith(objectType.ToFieldKeyFormat()))
				{
					// This is where an object begins. Check if it's the one we want
					if (ParseObjectIndex(line) != index)
					{
						if (hasFoundObject)
						{
							yield break;
						}

						// Else, continue searching
						continue;
					}

					hasFoundObject = true;
				}

				if (hasFoundObject)
				{
					// Skip empty lines, not useful
					if (string.IsNullOrEmpty(line))
					{
						continue;
					}

					yield return line;
				}
			}
		}
	}
}