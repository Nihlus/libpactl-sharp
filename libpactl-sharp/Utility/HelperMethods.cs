//
//  Pulse.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2017 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Linq;
using PulseAudio.Samples;

namespace PulseAudio.Utility
{
	public static class HelperMethods
	{
		public static ESampleFormat MapNativeSampleFormatName(string nativeSampleFormatName)
		{
			if (string.IsNullOrEmpty(nativeSampleFormatName))
			{
				throw new ArgumentNullException(nameof(nativeSampleFormatName));
			}

			switch (nativeSampleFormatName.ToLowerInvariant())
			{
				case "u8":
				{
					return ESampleFormat.Unsigned8PCM;
				}
				case "alaw":
				{
					return ESampleFormat.ALaw8;
				}
				case "ulaw":
				{
					return ESampleFormat.MuLaw8;
				}
				case "s16le":
				{
					return ESampleFormat.Signed16PCMLittleEndian;
				}
				case "s16be":
				{
					return ESampleFormat.Signed16PCMBigEndian;
				}
				case "float32le":
				{
					return ESampleFormat.Float32LittleEndian;
				}
				case "float32be":
				{
					return ESampleFormat.Float32BigEndian;
				}
				case "s32le":
				{
					return ESampleFormat.Signed32PCMLittleEndian;
				}
				case "s32be":
				{
					return ESampleFormat.Signed32PCMBigEndian;
				}
				case "s24le":
				{
					return ESampleFormat.Signed24PCMPackedLittleEndian;
				}
				case "s24be":
				{
					return ESampleFormat.Signed24PCMPackedBigEndian;
				}
				case "s24_32le":
				{
					return ESampleFormat.Signed24PCMInLSBOf32LittleEndian;
				}
				case "s24_32be":
				{
					return ESampleFormat.Signed24PCMInLSBOf32BigEndian;
				}
				default:
				{
					return ESampleFormat.Invalid;
				}
			}
		}

		public static string ToNativeFormat(this EPulseCommand pulseCommand)
		{
			return ToNativeFormat(pulseCommand.ToString());
		}

		public static string ToNativeFormat(this EPulseObject pulseObject)
		{
			return ToNativeFormat(pulseObject.ToString());
		}

		public static string ToFieldKeyFormat(this EPulseObject pulseObject)
		{
			return InsertSpacesBetweenWords(pulseObject.ToString());
		}

		private static string ToNativeFormat(string nonNativeString)
		{
			// Insert dashes between each word, skipping the first
			nonNativeString = string.Concat(nonNativeString.Select(x => char.IsUpper(x) ? "-" + x : x.ToString())).TrimStart('-');

			// Finally, convert it to all lower case
			nonNativeString = nonNativeString.ToLowerInvariant();

			return nonNativeString;
		}

		public static string ToManagedFormat(string nonManagedString)
		{
			if (string.IsNullOrEmpty(nonManagedString))
			{
				throw new ArgumentNullException(nameof(nonManagedString));
			}

			char[] transientArray = nonManagedString.ToCharArray();
			// Capitalize the first letter
			transientArray[0] = char.ToUpperInvariant(transientArray[0]);

			// Capitalize letters after dashes
			for (int i = 0; i < transientArray.Length; ++i)
			{
				if (transientArray[i] == '-' && (i + 1) < transientArray.Length)
				{
					transientArray[i + 1] = char.ToUpperInvariant(transientArray[i + 1]);
				}
			}

			transientArray = transientArray.Where(c => c != '-').ToArray();

			return new string(transientArray);
		}

		private static string InsertSpacesBetweenWords(string noSpaceString)
		{
			return string.Concat(noSpaceString.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
		}
	}
}