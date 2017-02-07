using System.Collections.Generic;

namespace PulseAudio.Interfaces
{
	public interface ITextParsable<out T>
	{
		bool PostParse(IEnumerable<string> objectInformation);
	}
}