namespace PulseAudio
{
	public struct Volume
	{
		public short NumericalLevel;

		public float Percentage => short.MaxValue / (float)this.NumericalLevel;

		public float Decibel;
	}
}