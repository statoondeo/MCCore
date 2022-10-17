using System.Collections.Generic;

public interface ITank<T> : IService
{
	T Add(T item);
	void Remove(T item);
	IList<T> Get();
}
