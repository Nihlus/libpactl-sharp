using System.Collections.Generic;

namespace PulseAudio.Modules
{
	public struct ModuleInfo
	{
		public uint Index;
		public string Name;
		public string Argument;
		public uint UsedCount;
		public Dictionary<string, string> Properties;
	}
}