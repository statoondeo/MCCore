using System.Collections.Generic;

public abstract class TankService<T> : ITank<T>, IService
{
	protected ITank<T> Tank;

	public int Count => Tank.Count;

	protected TankService() => Tank = new Tank<T>();

	public T Add(T item) => Tank.Add(item);
	public void Add(IList<T> items) => Tank.Add(items);
	public void Remove(T item) => Tank.Remove(item);
	public void Remove() => Tank.Remove();
	public IList<T> Get() => Tank.Get();
	public T Get(int index) => Tank.Get(index);

	public virtual IService Initialize() => this;
}
