using System.Collections.Generic;
using System.Text;

public class TankComponentProxy : BaseComponentProxy<ITankComponent>, ITankComponentProxy
{
	public TankComponentProxy() : base(new TankComponent()) { }

	public int Count => Wrapped.Count;

	public IEntity Add(IEntity item) => Wrapped.Add(item);
	public void Add(IList<IEntity> items) => Wrapped.Add(items);
	public IList<IEntity> Get() => Wrapped.Get();
	public IList<IEntity> Get(IFilterStrategy filter) => Wrapped.Get(filter);	
	public IEntity Get(int index) => Wrapped.Get(index);
	public IEntity GetFirst(IFilterStrategy filter) => Wrapped.GetFirst(filter);
	public void Remove() => Wrapped.Remove();
	public void Remove(IEntity item) => Wrapped.Remove(item);

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t TankComponentProxy");
		sb.AppendLine($"\t\t Count={Count}");
		IList<IEntity> cards = Get();
		for (int i = 0; i < cards.Count; i++) sb.Append(cards[i]);
		return (sb.ToString());
	}
}