using System.Collections.Generic;
using System.Text;

public class PlayableContainerComponentProxy : BaseComponentProxy<IPlayableContainerComponent>, IPlayableContainerComponentProxy
{
	public IDictionary<string, IPlayableComponentProxy> Playables => Wrapped.Playables;

	public PlayableContainerComponentProxy() : base(new PlayableContainerComponent()) { }

	public IPlayableComponentProxy RegisterPlayable(IPlayableComponentProxy playable) => Wrapped.RegisterPlayable(playable);

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t PlayableContainerComponentProxy");
		return (sb.ToString());
	}
}
