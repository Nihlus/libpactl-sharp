namespace PulseAudio
{
	/// <summary>
	/// Native pactl commands which can be passed to
	/// </summary>
	public enum EPulseCommand
	{
		Stat,
		Info,
		List,
		Exit,
		UploadSample,
		PlaySample,
		RemoveSample,
		LoadModule,
		UnloadModule,
		MoveSinkInput,
		MoveSourceOutput,
		SuspendSink,
		SuspendSource,
		SetCardProfile,
		SetDefaultSink,
		SetSinkPort,
		SetDefaultSource,
		SetSourcePort,
		SetPortLatencyOffset,
		SetSinkVolume,
		SetSourceVolume,
		SetSinkInputVolume,
		SetSourceOutputVolume,
		SetSinkMute,
		SetSourceMute,
		SetSinkInputMute,
		SetSourceOutputMute,
		SetSinkFormats,
		Subscribe
	}
}