using System.Collections.Generic;
using System.IO;
using PulseAudio.AudioVolume;
using PulseAudio.Channels;
using PulseAudio.Formats;
using PulseAudio.Interfaces;
using PulseAudio.Samples;

namespace PulseAudio.Sources
{
	public struct SourceOutputInfo : ITextParsable
	{
		public uint Index;
		public string Name;
		public uint OwnerModuleID;
		public uint ClientID;
		public uint SourceID;
		public SampleSpecification SampleSpecification;
		public ChannelMap ChannelMap;
		public ulong BufferLatency;
		public ulong SourceLatency;
		public string ResamplingMethod;
		public string Driver;
		public Dictionary<string, string> Properties;
		public bool IsCorked;
		public Volume Volume;
		public bool IsMuted;
		public bool HasVolume;
		public bool CanVolumeBeSet;
		public FormatInfo Format;

		public bool TryParseTextData(Stream objectInformation)
		{
			using (TextReader tr = new StreamReader(objectInformation))
			{
				return TryParseTextData(tr);
			}
		}

		public bool TryParseTextData(TextReader tr)
		{
			throw new System.NotImplementedException();
		}
	}
}