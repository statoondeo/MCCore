public class PlayableGenerateComponentProxy : PlayableComponentProxy
{
	public override ICommand PlayCommand
	{
		get
		{
			if (null == mPlayCommand)
				mPlayCommand = new PlayGenerateCommand(this, Entity.GetComponent<IBasicComponentProxy>(), Zones.STACK);

			return (mPlayCommand);
		}
	}

	public PlayableGenerateComponentProxy(string name) : this(name, new PlayableComponent(name)) { }
	public PlayableGenerateComponentProxy(string name, IPlayableComponent innerComponent) : base(name, innerComponent) { }
}
