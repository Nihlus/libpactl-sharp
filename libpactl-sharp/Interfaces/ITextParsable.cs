using System.Collections.Generic;
using System.IO;

namespace PulseAudio.Interfaces
{
	public interface ITextParsable
	{
		bool TryParseTextData(Stream objectInformation);
		bool TryParseTextData(TextReader tr);
	}
}