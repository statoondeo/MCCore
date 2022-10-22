using System.Collections.Generic;

public class ShuffleComponent : BaseComponent, IShuffleComponent
{
	public ShuffleComponent() : base() { }

	public void Shuffle()
	{
		IList<IEntity> cards = Entity.GetComponent<ITankComponentProxy>().Get();
		for (int i = 0; i < cards.Count; i++)
		{
			int j = UnityEngine.Random.Range(i, cards.Count);
			IBasicComponentProxy cardiBasicComponentProxy = cards[i].GetComponent<IBasicComponentProxy>();
			IBasicComponentProxy cardjBasicComponentProxy = cards[j].GetComponent<IBasicComponentProxy>();
			cardiBasicComponentProxy.SetOrder(j);
			cardjBasicComponentProxy.SetOrder(i);
		}
	}
}
