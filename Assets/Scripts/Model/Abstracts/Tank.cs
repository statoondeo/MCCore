using System.Collections.Generic;

public class Tank<T> : ITank<T>
{
	protected IList<T> Items { get; set; }

	public int Count => Items.Count;

	public Tank() => Items = new List<T>();

	public T Add(T item)
	{
		Items.Add(item);
		return (item);
	}
	public void Remove(T item) => Items.Remove(item);
	public IList<T> Get() => Items;
	public T Get(int index) => Items[index];
}