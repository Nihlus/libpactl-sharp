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
			// First, convert it to a string.
			string pulseCommandAsString = pulseCommand.ToString();

			// Next, insert dashes between each word, skipping the first
			pulseCommandAsString = string.Concat(pulseCommandAsString.Select(x => char.IsUpper(x) ? "-" + x : x.ToString())).TrimStart('-');

			// Finally, convert it to all lower case
			pulseCommandAsString = pulseCommandAsString.ToLowerInvariant();

			return pulseCommandAsString;
		}
	}
}