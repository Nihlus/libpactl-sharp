using System;

namespace PulseAudio.Sinks
{
	[Flags]
	public enum SinkFlag
	{
		None,
		HardwareVolumeControl,
		Latency,
		Hardware,
		Network,
		HardwareMuteControl,
		DecibelVolume,
		FlatVolume,
		DynamicLatency,
		SetFormats
	}
}