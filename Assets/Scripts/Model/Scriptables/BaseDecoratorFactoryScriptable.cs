using UnityEngine;

public abstract class BaseDecoratorFactoryScriptable<T> : ScriptableObject where T : IComponent
{
	public abstract IComponentDecorator<T> Create(IActivable owner);
}
