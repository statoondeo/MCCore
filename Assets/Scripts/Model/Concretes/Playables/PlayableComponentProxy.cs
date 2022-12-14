using System.Text;

public class PlayableComponentProxy : BaseComponentProxy<IPlayableComponent>, IPlayableComponentProxy
{
	public string Name => Wrapped.Name;

	protected ICommand mPlayCommand;
	public virtual ICommand PlayCommand
	{
		get
		{
			if (null == mPlayCommand)
				mPlayCommand = new PlayCommand(this, Entity.GetComponent<IBasicComponentProxy>(), (Zones.STACK, null));

			return (mPlayCommand);
		}
	}

	public PlayableComponentProxy(string name) : this(name, new PlayableComponent(name)) { }
	public PlayableComponentProxy(string name, IPlayableComponent innerComponent) : base(innerComponent) { }

	public bool CanPlay() => Wrapped.CanPlay();
	public void Play() => Wrapped.Play();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t PlayableComponentProxy");
		return (sb.ToString());
	}
}
