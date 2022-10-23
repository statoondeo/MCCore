using UnityEngine;

public abstract class BaseNameComponentDecorator : BaseComponentDecorator<INameComponent>, INameComponentDecorator
{
	public virtual string Name => Inner.Name;
	public virtual Sprite Image => Inner.Image;

	protected BaseNameComponentDecorator(IActivable owner) : base(owner) { }
}
