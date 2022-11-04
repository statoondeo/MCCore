using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Deck", menuName = "Deck")]
public class ScriptableDeck : ScriptableObject
{
	[SerializeField] protected ScriptableEntity[] Cards;

	public IList<IEntity> Create(IPlayer owner)
	{
		IList<IEntity> deck = new List<IEntity>();
		for (int i = 0; i < Cards.Length; i++) deck.Add(Cards[i].Create(owner));

		return (deck);
	}
}
