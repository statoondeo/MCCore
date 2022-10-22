using System.Collections.Generic;

public interface ITank<T>
{
	int Count { get; }
	T Add(T item);
	void Remove(T item);
	IList<T> Get();
	T Get(int index);
}
