using System.Collections.Generic;
using System.IO;
using PulseAudio.Interfaces;

namespace PulseAudio.Modules
{
	public struct ModuleInfo : ITextParsable
	{
		public uint Index;
		public string Name;
		public string Argument;
		public uint UsedCount;
		public Dictionary<string, string> Properties;

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