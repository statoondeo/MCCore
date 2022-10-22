using System.Collections.Generic;

public class TankComponent : BaseComponent, ITankComponent
{
	public int Count => Tank.Count;

	protected ITank<IEntity> Tank;

	public TankComponent() : base() => Tank = new Tank<IEntity>();

	public IEntity Add(IEntity item)
	{
		IBasicComponentProxy basicComponentProxy = item.GetComponent<IBasicComponentProxy>();
		basicComponentProxy.SetOrder(Tank.Count);
		return (Tank.Add(item));
	}
	public IList<IEntity> Get() => Tank.Get();
	public IEntity Get(int index) => Tank.Get(index);
	public void Remove(IEntity item)
	{
		int itemOrder = item.GetComponent<IBasicComponentProxy>().Order;
		Tank.Remove(item);
		IList<IEntity> entities = Tank.Get();
		for (int i = 0; i < entities.Count; i++)
		{
			IBasicComponentProxy basicComponentProxy = entities[i].GetComponent<IBasicComponentProxy>();
			if(basicComponentProxy.Order > itemOrder) basicComponentProxy.SetOrder(basicComponentProxy.Order - 1);
		}
	}
}
