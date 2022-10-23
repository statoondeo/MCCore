public class PlayCommand : MoveCommand
{
	protected IPlayableComponentProxy PlayableComponentProxy;
	public PlayCommand(IPlayableComponentProxy playableComponentProxy, IBasicComponentProxy basicComponentProxy, string targetZone)
		: base(basicComponentProxy, targetZone, CommandType.PLAY)
		=> PlayableComponentProxy = playableComponentProxy;

	public override bool CanExecute() => PlayableComponentProxy.CanPlay();
	public override void Execute()
	{
		if (CanExecute())
		{
			PlayableComponentProxy.Play();
			base.Execute();
		}
	}
}
