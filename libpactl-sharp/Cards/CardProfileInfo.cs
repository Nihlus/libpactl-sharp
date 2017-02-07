namespace PulseAudio.Cards
{
	public struct CardProfileInfo
	{
		public string Name;
		public string Description;
		public uint SinkCount;
		public uint SourceCount;
		public uint Priority;
		public bool IsAvailable;
	}
}