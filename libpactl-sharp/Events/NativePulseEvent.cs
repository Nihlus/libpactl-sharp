//
//  NativePulseEvent.cs
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
using PulseAudio.Object;

namespace PulseAudio.Events
{
	/// <summary>
	/// This class represents a native event in the PulseAudio server, exposed through the pactl command.
	/// There are three types of events which can occur, represented through the <see cref="NativePulseEventType"/>
	/// type.
	/// </summary>
	public class NativePulseEvent
	{
		/// <summary>
		/// The type of native event that occurred.
		/// </summary>
		public NativePulseEventType EventType;

		/// <summary>
		/// The type of object that the event affected.
		/// </summary>
		public EPulseObject ObjectType;

		/// <summary>
		/// The ID of the object that the event affected.
		/// </summary>
		public int ObjectID;

		/// <summary>
		/// Creates a new <see cref="NativePulseEvent"/> instance from a given event type, object type, and object ID.
		/// </summary>
		/// <param name="eventType">The type of the event that occurred.</param>
		/// <param name="objectType">The type of object that the event affected.</param>
		/// <param name="objectID">The ID of the object that the event affected.</param>
		public NativePulseEvent(NativePulseEventType eventType, EPulseObject objectType, int objectID)
		{
			this.EventType = eventType;
			this.ObjectType = objectType;
			this.ObjectID = objectID;
		}

		/// <summary>
		/// Attempts to parse a <see cref="NativePulseEvent"/> from a given string.
		/// </summary>
		/// <param name="input">The string containing the event.</param>
		/// <param name="pulseEvent">The output parsed event.</param>
		/// <returns><value>true</value> if the event was successfully parsed; Otherwise, <value>false</value>.</returns>
		public static bool TryParse(string input, out NativePulseEvent pulseEvent)
		{
			pulseEvent = null;
			if (string.IsNullOrEmpty(input) || !input.StartsWith("Event"))
			{
				return false;
			}

			string[] eventComponents = input.Split(' ');

			if (eventComponents.Length != 5)
			{
				return false;
			}

			// The second component will contain the event type. This field is enclosed in single quotes.
			NativePulseEventType eventType;
			if (!Enum.TryParse(eventComponents[1].Replace("'", string.Empty), true, out eventType))
			{
				return false;
			}

			// The fourth component will contain the object type. This field may contain dashes.
			EPulseObject objectType;
			if (!Enum.TryParse(eventComponents[3].Replace("-", string.Empty), true, out objectType))
			{
				return false;
			}

			// The fifth component will contain the object ID. This field is prefixed with a hash.
			int objectID;
			if (!int.TryParse(eventComponents[4].Replace("#", string.Empty), out objectID))
			{
				return false;
			}

			pulseEvent = new NativePulseEvent(eventType, objectType, objectID);
			return true;
		}
	}
}