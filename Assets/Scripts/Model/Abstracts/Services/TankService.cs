using System.Collections.Generic;

public abstract class TankService<T> : ITank<T>
{
	protected IList<T> Items { get; set; }

	protected TankService() => Items = new List<T>();

	public T Add(T item)
	{
		Items.Add(item);
		return (item);
	}
	public void Remove(T item) => Items.Remove(item);
	public IList<T> Get() => Items;

	public virtual IService Initialize() => this;
}
