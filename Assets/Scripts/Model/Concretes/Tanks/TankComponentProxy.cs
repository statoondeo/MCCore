using System.Collections.Generic;
using System.Text;

public class TankComponentProxy : BaseComponentProxy<ITankComponent>, ITankComponentProxy
{
	public TankComponentProxy() : base(new TankComponent()) { }

	public int Count => Wrapped.Count;

	public IEntity Add(IEntity item) => Wrapped.Add(item);
	public IList<IEntity> Get() => Wrapped.Get();
	public IEntity Get(int index) => Wrapped.Get(index);
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