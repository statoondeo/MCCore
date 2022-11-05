using System.Collections.Generic;

public interface IIndexedTank<T, U> : IService
{
	T Add(U itemId, T item);
	void Remove(U itemId);
	T Get(U itemId);
	IList<T> Get();
	int Count();
}
