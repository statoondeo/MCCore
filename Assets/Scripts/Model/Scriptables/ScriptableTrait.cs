using UnityEngine;

[CreateAssetMenu(fileName = "Trait", menuName = "Cards/Trait")]
public class ScriptableTrait : ScriptableObject
{
	public string Key;
	[SerializeField] protected string Name;

	public ITrait Create() => new Trait(Name, Key);
}
