namespace PulseAudio.AudioVolume
{
	public struct Volume
	{
		public uint NumericalLevel;

		public float Percentage => uint.MaxValue / (float)this.NumericalLevel;

		public bool IsMax => (EBaseVolumes)this.NumericalLevel == EBaseVolumes.Max;
		public bool IsMuted => (EBaseVolumes)this.NumericalLevel == EBaseVolumes.Muted;
		public bool IsNormal => (EBaseVolumes)this.NumericalLevel == EBaseVolumes.Normal;

		public float Decibel;
	}
}