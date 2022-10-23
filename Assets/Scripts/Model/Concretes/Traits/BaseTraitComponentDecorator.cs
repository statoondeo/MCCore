using System.Collections.Generic;

public abstract class BaseTraitComponentDecorator : BaseComponentDecorator<ITraitComponent>, ITraitComponentDecorator
{
	public virtual IList<ITrait> Traits => Inner.Traits;

	protected BaseTraitComponentDecorator(IActivable owner) : base(owner) { }
}