public class PlayableComponentProxy : BaseComponentProxy<IPlayableComponent>, IPlayableComponentProxy
{
	public string Name => Wrapped.Name;

	public PlayableComponentProxy(string name) : this(name, new PlayableComponent(name)) { }
	public PlayableComponentProxy(string name, IPlayableComponent innerComponent) : base(innerComponent) { }

	public void Play() => Wrapped.Play();
}