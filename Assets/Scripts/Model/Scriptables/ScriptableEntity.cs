using UnityEngine;

public abstract class ScriptableEntity : ScriptableObject
{
	[SerializeField] protected string Id;

	public abstract IEntity Create(IPlayer owner);
}
