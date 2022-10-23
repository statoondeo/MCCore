using System.Collections.Generic;

public abstract class BasePlayableContainerComponentDecorator : BaseComponentDecorator<IPlayableContainerComponent>, IPlayableContainerComponentDecorator
{
	public IDictionary<string, IPlayableComponentProxy> Playables => Inner.Playables;

	protected BasePlayableContainerComponentDecorator(IActivable owner) : base(owner) { }

	public IPlayableComponentProxy RegisterPlayable(IPlayableComponentProxy playable) => Inner.RegisterPlayable(playable);
}
