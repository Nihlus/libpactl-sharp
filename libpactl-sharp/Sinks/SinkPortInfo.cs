using PulseAudio.Ports;

namespace PulseAudio.Sinks
{
	public struct SinkPortInfo
	{
		public string Name;
		public string Description;
		public uint Priority;
		public EPortAvailable Available;
	}
}