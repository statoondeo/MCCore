using System.Collections.Generic;

public interface ITraitComponent : IComponent
{
	IList<ITrait> Traits { get; }
}
