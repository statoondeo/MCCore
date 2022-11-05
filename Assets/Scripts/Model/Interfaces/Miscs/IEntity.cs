using System.Collections.Generic;

public interface IEntity : IActivable
{
	string Id { get; }
	IPlayer Owner { get; }
	T GetComponent<T>() where T : class;
	IList<IComponent> GetComponents();
	T AddComponent<T>(IComponent component) where T : IComponent;
	void RemoveComponent<T>(IComponent component) where T : IComponent;
}
public interface IEntityDecorator : IEntity
{
	IEntity Inner { get; }
	void SetInner(IEntity entity);
}
public interface IEntityProxy : IEntity
{
	IEntityDecorator Register(IEntityDecorator decorator);
	void UnRegister(IEntityDecorator decorator);
}
