using System.Collections.Generic;

public abstract class BaseTankComponentDecorator : BaseComponentDecorator<ITankComponent>, ITankComponentDecorator
{
	public int Count => Inner.Count;

	protected BaseTankComponentDecorator(IActivable owner) : base(owner) { }

	public virtual IEntity Add(IEntity item) => Inner.Add(item);
	public virtual void Add(IList<IEntity> items) => Inner.Add(items);
	public virtual IList<IEntity> Get() => Inner.Get();
	public virtual IList<IEntity> Get(IFilterStrategy filter) => Inner.Get(filter);
	public virtual IEntity Get(int index) => Inner.Get(index);
	public virtual IEntity GetFirst(IFilterStrategy filter) => Inner.GetFirst(filter);
	public virtual void Remove(IEntity item) => Inner.Remove(item);
	public virtual void Remove() => Inner.Remove();
}
