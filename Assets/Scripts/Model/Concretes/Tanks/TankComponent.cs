using System.Collections.Generic;
using System.Linq;

public class TankComponent : BaseComponent, ITankComponent
{
	public int Count => Tank.Count;

	protected ITank<IEntity> Tank;

	public TankComponent() : base() => Tank = new Tank<IEntity>();

	public IEntity Add(IEntity item)
	{
		item.GetComponent<IBasicComponentProxy>().SetOrder(Tank.Count);
		return (Tank.Add(item));
	}
	public void Add(IList<IEntity> items)
	{
		for(int i = 0; i < items.Count; i++) Add(items[i]);
	}
	public IList<IEntity> Get() => Tank.Get();
	public IEntity Get(int index) => Tank.Get(index);
	public IList<IEntity> Get(IFilterStrategy filter)
	{
		IList<IEntity> entities = Tank.Get();
		IList<IEntity> result = new List<IEntity>();
		for (int i = 0; i < entities.Count; i++)
		{
			if (filter.Filter(entities[i])) result.Add(entities[i]);
			else
			{
				IFaceContainerComponentProxy faceContainer = entities[i].GetComponent<IFaceContainerComponentProxy>();
				IList<string> faces = faceContainer.Faces.Keys.ToList();
				for (int j = 0; j < faces.Count; j++)
					if (filter.Filter(faceContainer.Faces[faces[j]].Face))
					{
						result.Add(entities[i]);
						break;
					}
			}
		}
		return (result);
	}
	public IEntity GetFirst(IFilterStrategy filter)
	{
		IList<IEntity> entities = Tank.Get();
		for (int i = 0; i < entities.Count; i++)
		{
			if (filter.Filter(entities[i])) return (entities[i]);
			else
			{
				IFaceContainerComponentProxy faceContainer = entities[i].GetComponent<IFaceContainerComponentProxy>();
				IList<string> faces = faceContainer.Faces.Keys.ToList();
				for (int j = 0; j < faces.Count; j++)
					if (filter.Filter(faceContainer.Faces[faces[j]].Face)) return (entities[i]);
			}
		}
		return (null);
	}
	public void Remove() => Tank.Remove();
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
