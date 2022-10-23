using System.Collections.Generic;
using UnityEngine;

public class ShuffleComponent : BaseComponent, IShuffleComponent
{
	public ShuffleComponent() : base() { }

	public void Shuffle()
	{
		IList<IEntity> cards = Entity.GetComponent<ITankComponentProxy>().Get();
		for (int i = 0; i < (cards.Count -1); i++)
		{
			int j = Random.Range(i + 1, cards.Count);
			IBasicComponentProxy cardiBasicComponentProxy = cards[i].GetComponent<IBasicComponentProxy>();
			IBasicComponentProxy cardjBasicComponentProxy = cards[j].GetComponent<IBasicComponentProxy>();
			cardiBasicComponentProxy.SetOrder(j);
			cardjBasicComponentProxy.SetOrder(i);
			cards[j] = cardiBasicComponentProxy.Entity;
			cards[i] = cardjBasicComponentProxy.Entity;
		}
	}
}
