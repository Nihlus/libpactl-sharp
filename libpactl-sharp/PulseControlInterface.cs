//
//  PulseEventDelegates.cs
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

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using PulseAudio.Utility;

namespace PulseAudio
{
	public static class PulseControlInterface
	{
		public const string PulseControlName = "pactl";

		public static IEnumerable<string> GetPulseControlOutput(EPulseCommand command, params string[] arguments)
		{
			string argumentString = $"{command.ToNativeFormat()} {arguments.SelectMany(x => x)}";
			return GetPulseControlOutput(argumentString);
		}

		private static IEnumerable<string> GetPulseControlOutput(string arguments)
		{
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = PulseControlName,
				Arguments = $"--client-name=libpactl-sharp " + arguments,
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				RedirectStandardError = true
			};

			using (Process pulseControlProcess = new Process {StartInfo = startInfo})
			{
				pulseControlProcess.Start();
				pulseControlProcess.WaitForExit();

				string line;
				while ((line = pulseControlProcess.StandardOutput.ReadLine()) != null)
				{
					yield return line;
				}
			}
		}
	}
}