using System;
using System.IO;
using System.Linq;
using PulseAudio.Interfaces;
using PulseAudio.Utility;

namespace PulseAudio.Samples
{
	public struct SampleSpecification : ITextParsable
	{
		public ESampleFormat Format;
		public uint Rate;
		public byte Channels;

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

			string[] rawDataComponents = rawData.Split(' ');
			if (rawDataComponents.Length != 3)
			{
				return false;
			}

			ESampleFormat format;
			try
			{
				format = HelperMethods.MapNativeSampleFormatName(rawDataComponents[0]);
				if (format == ESampleFormat.Invalid)
				{
					return false;
				}
			}
			catch (ArgumentNullException anex)
			{
				return false;
			}
			this.Format = format;

			string channelCountNumbers = string.Concat(rawDataComponents[1].Where(char.IsNumber));
			if (!string.IsNullOrEmpty(channelCountNumbers))
			{
				byte channelCount;
				if (byte.TryParse(channelCountNumbers, out channelCount))
				{
					this.Channels = channelCount;
				}
			}
			else
			{
				return false;
			}

			string sampleRateNumbers = string.Concat(rawDataComponents[2].Where(char.IsNumber));
			if (!string.IsNullOrEmpty(sampleRateNumbers))
			{
				uint sampleRate;
				if (uint.TryParse(sampleRateNumbers, out sampleRate))
				{
					this.Rate = sampleRate;
				}
			}
			else
			{
				return false;
			}

			return true;
		}
	}
}