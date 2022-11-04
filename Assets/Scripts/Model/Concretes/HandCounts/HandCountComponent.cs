using System.Collections.Generic;

public class HandCountComponent : BaseComponent, IHandCountComponent
{
	public HandCountComponent() : base() { }

	public int Count()
	{
		int count = 0;
		IList<IEntity> cards = Entity.GetComponent<ITankComponentProxy>().Get();
		for (int i = 0; i < cards.Count; i++)
			count += cards[i].GetComponent<IFaceContainerComponentProxy>().ActiveFace.Face.GetComponent<ICardComponentProxy>().HandSize;
		return (count);
	}
}
