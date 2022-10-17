﻿using System.Collections.Generic;
using System.Linq;

public abstract class IndexedTankService<T, U> : IIndexedTank<T, U>
{
	protected bool CacheToRefresh;
	protected IList<T> CachedList;
	protected IDictionary<U, T> Items { get; set; }

	protected IndexedTankService()
	{
		Items = new Dictionary<U, T>();
		CacheToRefresh = true;
	}

	public T Add(U itemId, T item)
	{
		CacheToRefresh = Items.TryAdd(itemId, item);
		return (item);
	}
	public void Remove(U itemId) => CacheToRefresh = Items.Remove(itemId);
	public T Get(U itemid) => Items[itemid];
	public IList<T> Get()
	{
		if (CacheToRefresh)
		{
			CachedList = Items.Values.ToList();
			CacheToRefresh = false;
		}

		return (CachedList);
	}

	public virtual IService Initialize() => this;
}