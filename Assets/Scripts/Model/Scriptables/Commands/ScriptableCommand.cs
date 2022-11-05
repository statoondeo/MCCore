using UnityEngine;

public abstract class ScriptableCommand : ScriptableObject, ICommandFactory
{
	public abstract ICommand Create(IEntity parentEntity);
}
