using System.Collections.Generic;

public class TraitComponent : BaseComponent, ITraitComponent
{
	public IList<ITrait> Traits { get; protected set; }

	public TraitComponent(IList<ITrait> traits) : base() => Traits = traits;
}
