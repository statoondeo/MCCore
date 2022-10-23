using System.Collections.Generic;

public interface IPlayableContainerComponent : IComponent
{
	IDictionary<string, IPlayableComponentProxy> Playables { get; }
	IPlayableComponentProxy RegisterPlayable(IPlayableComponentProxy face);
}
