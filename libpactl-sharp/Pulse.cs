//
//  Pulse.cs
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

using System;
using System.Collections.Generic;
using PulseAudio.Cards;
using PulseAudio.Clients;
using PulseAudio.Interfaces;
using PulseAudio.Modules;
using PulseAudio.Samples;
using PulseAudio.Sinks;
using PulseAudio.Sources;

namespace PulseAudio
{
	public static class Pulse
	{
		public static T GetInfo<T>(uint index) where T : ITextParsable, new()
		{
			T transientObject = new T();
			throw new NotImplementedException();
		}

		public static T GetInfo<T>(string name) where T : ITextParsable, new()
		{
			throw new NotImplementedException();
		}

		public static List<ModuleInfo> GetModules()
		{
			throw new NotImplementedException();
		}

		public static List<SinkInfo> GetSinks()
		{
			throw new NotImplementedException();
		}

		public static List<SourceInfo> GetSources()
		{
			throw new NotImplementedException();
		}

		public static List<SinkInputInfo> GetSinkInputs()
		{
			throw new NotImplementedException();
		}

		public static List<SourceOutputInfo> GetSourceOutputs()
		{
			throw new NotImplementedException();
		}

		public static List<ClientInfo> GetClients()
		{
			throw new NotImplementedException();
		}

		public static List<SampleInfo> GetSamples()
		{
			throw new NotImplementedException();
		}

		public static List<CardInfo> GetCards()
		{
			throw new NotImplementedException();
		}
	}
}