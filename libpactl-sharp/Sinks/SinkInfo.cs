//
//  SinkInfo.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2017 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System.Collections.Generic;
using System.IO;
using PulseAudio.AudioVolume;
using PulseAudio.Cards;
using PulseAudio.Channels;
using PulseAudio.Formats;
using PulseAudio.Interfaces;
using PulseAudio.Modules;
using PulseAudio.Samples;
using PulseAudio.Sources;

namespace PulseAudio.Sinks
{
	public struct SinkInfo : ITextParsable
	{
		public string Name;
		public uint Index;
		public string Description;
		public SampleSpecification SampleSpecification;
		public ChannelMap ChannelMap;
		public uint OwnerModuleID;
		public ModuleInfo OwnerModule
		{
			get { return Pulse.GetInfo<ModuleInfo>(this.OwnerModuleID); }
		}

		public Dictionary<EChannelPosition, Volume> ChannelVolumes;
		public bool IsMuted;
		public uint MonitorSourceID;
		public string MonitorSourceName;

		public SourceInfo MonitorSource
		{
			get { return Pulse.GetInfo<SourceInfo>(this.MonitorSourceID); }
		}

		/// <summary>
		/// Combined latency field for both actual and configured latency of the sink.
		/// </summary>
		public Latency Latency;

		public string Driver;
		public SinkFlag Flags;
		public Dictionary<string, string> Properties;
		public Volume BaseVolume;
		public ESinkState State;
		public uint VolumeSteps;
		public uint CardID;

		public CardInfo Card
		{
			get { return Pulse.GetInfo<CardInfo>(this.CardID); }
		}
		public uint PortCount;
		public List<SinkPortInfo> AvailablePorts;
		public SinkPortInfo ActivePort;
		public byte SupportedFormatCount;
		public List<FormatInfo> SupportedFormats;

		public bool TryParseTextData(Stream objectInformation)
		{
			using (TextReader tr = new StreamReader(objectInformation))
			{
				return TryParseTextData(tr);
			}
		}

		// TODO: Catch exceptions and return false
		public bool TryParseTextData(TextReader tr)
		{
			int objectIndex = tr.ReadObjectIndex();
			if (objectIndex < 0)
			{
				return false;
			}

			this.Index = (uint)objectIndex;
			this.State = tr.ReadKeyValuePairEnum<ESinkState>("State");
			this.Name = tr.ReadKeyValuePairString("Name");
			this.Description = tr.ReadKeyValuePairString("Description");
			this.Driver = tr.ReadKeyValuePairString("Driver");
			this.SampleSpecification = tr.ReadKeyValuePairParsable<SampleSpecification>("Sample Specification");
			this.ChannelMap = tr.ReadKeyValuePairParsable<ChannelMap>("Channel Map");
			this.OwnerModuleID = (uint)tr.ReadKeyValuePairIntegerData("Owner Module");

			return true;
		}
	}
}