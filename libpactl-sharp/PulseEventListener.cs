using System.Diagnostics;

namespace libpactl_sharp
{
	internal class PulseEventListener
	{
		private const string PulseControlName = "pactl";
		private const string PulseControlSubscriptionArgument = "subscribe";

		private Process PulseControlProcess;

		public void Subscribe()
		{
			ProcessStartInfo pulseControlProcessInfo = new ProcessStartInfo
			{
				FileName = PulseControlName,
				Arguments = PulseControlSubscriptionArgument,
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
			};


		}
	}
}