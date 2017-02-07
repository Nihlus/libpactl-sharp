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

namespace PulseAudio.Utility
{
	public static class HelperMethods
	{
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

		private static string InsertSpacesBetweenWords(string noSpaceString)
		{
			return string.Concat(noSpaceString.Select(x => char.IsUpper(x) ? " " + x : x.ToString())).TrimStart(' ');
		}
	}
}