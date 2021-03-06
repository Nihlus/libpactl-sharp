﻿//
//  SourceInfo.cs
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
using PulseAudio.Channels;
using PulseAudio.Formats;
using PulseAudio.Interfaces;
using PulseAudio.Modules;
using PulseAudio.Samples;
using PulseAudio.Sinks;

namespace PulseAudio.Sources
{
	public struct SourceInfo : ITextParsable
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
		public bool Muted;
		public uint MonitorOfSink;
		public string MonitorOfSinkName;

		/// <summary>
		/// Combined latency field for both actual and configured latency of the sink.
		/// </summary>
		public Latency Latency;

		public string Driver;
		public SourceFlag Flags;
		public Dictionary<string, string> Properties;
		public Volume BaseVolume;
		public ESourceState State;
		public uint VolumeSteps;
		public uint Card;
		public uint PortCount;
		public List<SinkPortInfo> AvailablePorts;
		public SinkPortInfo ActivePort;
		public byte SupportedFormatCount;
		public List<FormatInfo> SupportedFormats;

		public bool TryParseTextData(IEnumerable<string> objectInformation)
		{
			throw new System.NotImplementedException();
		}

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