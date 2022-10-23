using System.Collections.Generic;

public abstract class BaseTankComponentDecorator : BaseComponentDecorator<ITankComponent>, ITankComponentDecorator
{
	public int Count => Inner.Count;

	protected BaseTankComponentDecorator(IActivable owner) : base(owner) { }

	public IEntity Add(IEntity item) => Inner.Add(item);
	public IList<IEntity> Get() => Inner.Get();
	public IEntity Get(int index) => Inner.Get(index);
	public void Remove(IEntity item) => Inner.Remove(item);
}
