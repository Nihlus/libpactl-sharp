namespace PulseAudio
{
	public enum ESampleFormat
	{
		Invalid,
		Unsigned8PCM,
		ALaw8,
		MuLaw8,
		Signed16PCMLittleEndian,
		Signed16PCMBigEndian,
		Float32LittleEndian,
		Float32BigEndian,
		Signed32PCMLittleEndian,
		Signed32PCMBigEndian,
		Signed24PCMPackedLittleEndian,
		Signed24PCMPackedBigEndian,
		Signed24PCMInLSBOf32LittleEndian,
		Signed24PCMInLSBOf32BugEndian,
	}
}