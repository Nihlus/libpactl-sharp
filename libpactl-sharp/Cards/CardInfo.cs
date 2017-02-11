using System.Collections.Generic;
using System.IO;
using PulseAudio.Interfaces;

namespace PulseAudio.Cards
{
	public struct CardInfo : ITextParsable
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