using System.Collections.Generic;

public class PlayableContainerComponent : BaseComponent, IPlayableContainerComponent
{
	public IDictionary<string, IPlayableComponentProxy> Playables { get; protected set; }

	public PlayableContainerComponent() : base() => Playables = new Dictionary<string, IPlayableComponentProxy>();


	public IPlayableComponentProxy RegisterPlayable(IPlayableComponentProxy playable)
	{
		playable.Attach(Entity);
		Playables.Add(playable.Name, playable);
		return (playable);
	}
}