using UnityEngine;

[CreateAssetMenu(fileName = "Card Type", menuName = "Cards/Type")]
public class ScriptableCardType : ScriptableObject
{
	public string Key;
	[SerializeField] protected string Name;

	public ICardType Create() => new CardType(Name, Key);
}
