using System.Collections.Generic;

public class PlayableContainerComponentProxy : BaseComponentProxy<IPlayableContainerComponent>, IPlayableContainerComponentProxy
{
	public IDictionary<string, IPlayableComponentProxy> Playables => Wrapped.Playables;

	public PlayableContainerComponentProxy() : base(new PlayableContainerComponent()) { }

	public IPlayableComponentProxy RegisterPlayable(IPlayableComponentProxy playable) => Wrapped.RegisterPlayable(playable);
}
