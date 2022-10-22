using UnityEngine;

[CreateAssetMenu(fileName = "Classification", menuName = "Cards/Classification")]
public class ScriptableClassification : ScriptableObject
{
	public string Key;
	[SerializeField] protected string Name;

	public IClassification Create() => new Classification(Name, Key);
}
