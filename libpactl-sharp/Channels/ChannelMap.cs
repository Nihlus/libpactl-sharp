using System.Collections.Generic;
using PulseAudio.Object;

namespace PulseAudio
{
	public struct ChannelMap
	{
		public byte Channels;
		public List<EChannelPosition> Map;
	}
}