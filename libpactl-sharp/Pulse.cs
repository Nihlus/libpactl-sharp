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
using PulseAudio.Interfaces;

namespace PulseAudio
{
	public class Pulse
	{
		public T GetInfo<T>(uint index) where T : ITextParsable<T>, new()
		{
			T transientObject = new T();
			throw new NotImplementedException();
		}

		public T GetInfo<T>(string name) where T : ITextParsable<T>, new()
		{
			throw new NotImplementedException();
		}
	}
}