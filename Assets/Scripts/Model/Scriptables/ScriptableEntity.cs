using UnityEngine;

public abstract class ScriptableEntity : ScriptableObject
{
	public string Id;
	public abstract IEntity Create(IPlayer owner);
}
