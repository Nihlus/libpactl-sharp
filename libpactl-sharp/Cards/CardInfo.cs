using System.Collections.Generic;

namespace PulseAudio.Cards
{
	public struct CardInfo
	{
		public uint Index;
		public string Name;
		public uint OwnerModule;
		public string Driver;
		public uint ProfileCount;
		public Dictionary<string, string> Properties;
		public uint PortCount;
		public List<CardPortInfo> Ports;
		public List<CardProfileInfo> Profiles;
		public CardProfileInfo ActiveProfile;
	}
}