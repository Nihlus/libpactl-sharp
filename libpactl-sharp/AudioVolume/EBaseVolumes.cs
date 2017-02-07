namespace PulseAudio.AudioVolume
{
	public enum EBaseVolumes : uint
	{
		Invalid = uint.MaxValue,
		Max = uint.MaxValue / 2,
		Muted = 0,
		Normal =  0x10000U
	}
}