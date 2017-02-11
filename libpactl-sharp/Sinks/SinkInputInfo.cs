using System.Collections.Generic;
using PulseAudio.AudioVolume;
using PulseAudio.Channels;
using PulseAudio.Clients;
using PulseAudio.Formats;
using PulseAudio.Modules;
using PulseAudio.Samples;

namespace PulseAudio.Sinks
{
	public struct SinkInputInfo
	{
		public uint Index;
		public string Name;
		public uint OwnerModuleID;

		public ModuleInfo OwnerModule
		{
			get { return Pulse.GetInfo<ModuleInfo>(this.OwnerModuleID); }
		}

		public uint ClientID;

		public ClientInfo Client
		{
			get { return Pulse.GetInfo<ClientInfo>(this.ClientID); }
		}

		public uint SinkID;

		public SampleSpecification SampleSpecification;
		public ChannelMap ChannelMap;
		public ulong BufferLatency;
		public ulong SinkLatency;
		public string ResamplingMethod;
		public string Driver;
		public Dictionary<string, string> Properties;
		public bool IsCorked;
		public Volume Volume;
		public bool IsMuted;
		public bool HasVolume;
		public bool CanVolumeBeSet;
		public FormatInfo Format;

	}
}