using UnityEngine;

[CreateAssetMenu(fileName = "Card Type", menuName = "Cards/Type")]
public class ScriptableCardType : ScriptableObject
{
	[SerializeField] protected string Key;
	[SerializeField] protected string Name;

	public ICardType Create() => new CardType(Name, Key);
}
