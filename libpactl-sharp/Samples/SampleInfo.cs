using System.Collections.Generic;
using PulseAudio.AudioVolume;
using PulseAudio.Channels;

namespace PulseAudio.Samples
{
	public struct SampleInfo
	{
		public uint Index;
		public string Name;
		public Dictionary<EChannelPosition, Volume> DefaultChannelVolumes;
		public SampleSpecification SampleSpecification;
		public ChannelMap ChannelMap;
		public ulong Duration;
		public uint Bytes;
		public bool IsLazyCached;
		public string Filename;
		public Dictionary<string, string> Properties;
	}
}