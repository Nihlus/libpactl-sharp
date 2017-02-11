using System;
using System.Collections.Generic;
using System.IO;
using PulseAudio.Interfaces;
using PulseAudio.Utility;

namespace PulseAudio
{
	public static class PulseControlOutputParser
	{
		public static int ReadObjectIndex(this TextReader tr)
		{
			string line = tr.ReadLine();
			if (string.IsNullOrEmpty(line))
			{
				return -1;
			}

			return ParseObjectIndex(line);
		}

		public static int ParseObjectIndex(string line)
		{
			int indexStartIndex = line.IndexOf("#", StringComparison.InvariantCultureIgnoreCase);
			if (indexStartIndex >= 0)
			{
				int objectIndex;
				if (int.TryParse(line.Substring(indexStartIndex + 1), out objectIndex))
				{
					return objectIndex;
				}
			}

			return -1;
		}

		public static string ReadKeyValuePairString(this TextReader tr, string key)
		{
			string line = tr.ReadLine();
			if (string.IsNullOrEmpty(line))
			{
				return null;
			}

			int keyIndex = line.IndexOf(key, StringComparison.Ordinal);
			if (keyIndex < 0)
			{
				return null;
			}

			// Skip the key
			keyIndex += key.Length;

			// Skip the separator
			keyIndex += ": ".Length;

			return line.Substring(keyIndex);
		}

		public static T ReadKeyValuePairEnum<T>(this TextReader tr, string key) where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an enumerated type.");
			}

			string rawKeyValue = tr.ReadKeyValuePairString(key);
			if (string.IsNullOrEmpty(rawKeyValue))
			{
				throw new ArgumentException($"No value found for key {key}", nameof(key));
			}

			T enumResult;
			if (Enum.TryParse(rawKeyValue, true, out enumResult))
			{
				return enumResult;
			}

			throw new ArgumentException($"Failed to parse an enum value from {key}.", nameof(key));
		}

		public static T ReadKeyValuePairParsable<T>(this TextReader tr, string key) where T : ITextParsable, new()
		{
			T defaultObject = new T();

			if (defaultObject.TryParseTextData(tr))
			{
				return defaultObject;
			}

			throw new InvalidDataException("Failed to parse a valid object from the given data.");
		}

		public static int ReadKeyValuePairIntegerData(this TextReader tr, string key)
		{
			string rawKeyValue = tr.ReadKeyValuePairString(key);
			if (string.IsNullOrEmpty(rawKeyValue))
			{
				throw new ArgumentException($"No value found for key {key}", nameof(key));
			}

			int numberResult;
			if (int.TryParse(rawKeyValue, out numberResult))
			{
				return numberResult;
			}

			throw new ArgumentException($"Failed to parse an integer value from {key}.", nameof(key));
		}

		public static Dictionary<string, string> ReadObjectPropertyList(List<string> propertyList)
		{
			throw new NotImplementedException();
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