public abstract class BaseComponent : IComponent
{
	public IEntity Entity { get; protected set; }

	protected BaseComponent() { }

	public void Attach(IEntity entity) => Entity = entity;
	public void Detach() => Entity = null;
}
