using System;
using System.Collections.Generic;
using System.IO;
using PulseAudio.Interfaces;
using PulseAudio.Utility;

namespace PulseAudio.Channels
{
	public struct ChannelMap : ITextParsable
	{
		public List<EChannelPosition> Map;

		public bool TryParseTextData(Stream objectInformation)
		{
			using (TextReader tr = new StreamReader(objectInformation))
			{
				return TryParseTextData(tr);
			}
		}

		public bool TryParseTextData(TextReader tr)
		{
			string rawData = tr.ReadLine();

			if (string.IsNullOrEmpty(rawData))
			{
				return false;
			}

			string[] rawDataComponents = rawData.Split(',');
			this.Map = new List<EChannelPosition>(rawDataComponents.Length);
			foreach (string channelName in rawDataComponents)
			{
				EChannelPosition position;
				if (!Enum.TryParse(HelperMethods.ToManagedFormat(channelName), out position))
				{
					return false;
				}

				this.Map.Add(position);
			}

			return true;
		}
	}
}