using UnityEngine;

[CreateAssetMenu(fileName = "Zone", menuName = "Zone")]
public class ScriptableZone : ScriptableObject
{
	public string Key;
	[SerializeField] protected string Name;

	public IZone Create() => new Zone(Name, Key);
}
