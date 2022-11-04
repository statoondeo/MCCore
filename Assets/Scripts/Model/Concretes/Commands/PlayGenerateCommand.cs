public class PlayGenerateCommand : PlayCommand
{
	public PlayGenerateCommand(IPlayableComponentProxy playableComponentProxy, IBasicComponentProxy basicComponentProxy, (string, IPlayer) targetZone)
		: base(playableComponentProxy, basicComponentProxy, targetZone)
		=> PlayableComponentProxy = playableComponentProxy;

	public override bool CanExecute() => PlayableComponentProxy.CanPlay();
	public override void Execute()
	{
		if (CanExecute())
		{
			PlayableComponentProxy.Play();
			Done = true;
		}
	}
}