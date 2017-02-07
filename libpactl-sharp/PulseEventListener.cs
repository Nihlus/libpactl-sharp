//
//  PulseEventListener.cs
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
using System.Diagnostics;
using PulseAudio.Events;
using PulseAudio.Utility;

namespace PulseAudio
{
	public class PulseEventListener : IDisposable
	{
		private Process PulseControlProcess;

		private bool IsShuttingDown;

		public void Subscribe()
		{
			this.PulseControlProcess = new Process
			{
				StartInfo = new ProcessStartInfo
				{
					FileName = PulseNative.PulseControlName,
					Arguments = $"--client-name=libpulse-sharp {EPulseCommand.Subscribe.ToNativeFormat()}",
					CreateNoWindow = true,
					UseShellExecute = false,
					RedirectStandardOutput = true,
					RedirectStandardError = true
				},
				EnableRaisingEvents = true
			};

			this.PulseControlProcess.OutputDataReceived += OnNativePulseEvent;
			this.PulseControlProcess.ErrorDataReceived += OnNativePulseError;
			this.PulseControlProcess.Exited += OnNativePulseEventListenerExited;

			this.PulseControlProcess.Start();
			this.PulseControlProcess.BeginOutputReadLine();
		}

		/// <summary>
		/// Shuts down the event listener and the background process.
		/// </summary>
		public void Shutdown()
		{
			this.IsShuttingDown = true;

			if (this.PulseControlProcess != null)
			{
				this.PulseControlProcess.OutputDataReceived -= OnNativePulseEvent;
				this.PulseControlProcess.ErrorDataReceived -= OnNativePulseError;
				this.PulseControlProcess.Exited -= OnNativePulseEventListenerExited;

				this.PulseControlProcess.Kill();
			}
		}

		/// <summary>
		/// Resubscribes to PulseAudio events if the background process exits.
		/// </summary>
		/// <param name="sender">The sending object.</param>
		/// <param name="e">A set of empty event arguments.</param>
		private void OnNativePulseEventListenerExited(object sender, EventArgs e)
		{
			if (!this.IsShuttingDown)
			{
				this.PulseControlProcess?.Dispose();
				Subscribe();
			}
		}

		private void OnNativePulseError(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
		}

		private void OnNativePulseEvent(object sender, DataReceivedEventArgs e)
		{
			NativePulseEvent pulseEvent;
			if (NativePulseEvent.TryParse(e.Data, out pulseEvent))
			{
				Console.WriteLine($"Pulse event: \n" +
				                  $"Type: {pulseEvent.EventType}\n" +
				                  $"Object: {pulseEvent.ObjectType}\n" +
				                  $"ID: {pulseEvent.ObjectID}");
			}
		}

		/// <summary>
		/// Disposes the event listener, getting rid of the native process.
		/// </summary>
		public void Dispose()
		{
			try
			{
				this.PulseControlProcess?.Kill();
			}
			catch (InvalidOperationException iex)
			{
				// Intentionally doing nothing here
			}

			this.PulseControlProcess?.Dispose();
		}
	}
}