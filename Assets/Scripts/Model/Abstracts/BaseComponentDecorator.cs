public abstract class BaseComponentDecorator<T> : IComponentDecorator<T> where T : IComponent
{
	public IEntity Entity => Inner.Entity;
	public T Inner { get; protected set; }
	public IActivable Owner { get; protected set; }

	protected BaseComponentDecorator(IActivable owner) => Owner = owner;

	public void SetInner(T inner) => Inner = inner;
	public void Attach(IEntity entity) => Inner.Attach(entity);
	public void Detach() => Inner.Detach();
}
