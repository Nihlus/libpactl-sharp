using System.Collections.Generic;

namespace PulseAudio.Channels
{
	public struct ChannelMap
	{
		public byte Channels;
		public List<EChannelPosition> Map;
	}
}