using System.Collections.Generic;

public interface ITank<T>
{
	int Count { get; }
	T Add(T item);
	void Add(IList<T> items);
	void Remove(T item);
	void Remove();
	IList<T> Get();
	T Get(int index);
}
