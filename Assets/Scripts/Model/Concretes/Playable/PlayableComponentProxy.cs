public class PlayableComponentProxy : BaseComponentProxy<IPlayableComponent>, IPlayableComponentProxy
{
	public string Name => Wrapped.Name;

	protected ICommand mPlayCommand;
	public virtual ICommand PlayCommand
	{
		get
		{
			if (null == mPlayCommand)
				mPlayCommand = new PlayCommand(this, Entity.GetComponent<IBasicComponentProxy>(), Zones.STACK);

			return (mPlayCommand);
		}
	}

	public PlayableComponentProxy(string name) : this(name, new PlayableComponent(name)) { }
	public PlayableComponentProxy(string name, IPlayableComponent innerComponent) : base(innerComponent) { }

	public bool CanPlay() => Wrapped.CanPlay();
	public void Play() => Wrapped.Play();
}
