using System.Collections.Generic;
using PulseAudio.Ports;

namespace PulseAudio.Cards
{
	public struct CardPortInfo
	{
		public string Name;
		public string Description;
		public uint Priority;
		public EPortAvailable IsAvailable;
		public EPortDirection Direction;
		public uint ProfileCount;
		public Dictionary<string, string> Properties;
		public ulong LatencyOffset;
		public List<CardProfileInfo> Profiles;
	}
}