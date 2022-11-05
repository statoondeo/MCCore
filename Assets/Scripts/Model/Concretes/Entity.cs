using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Entity : IEntity
{
	public string Id { get; protected set; }
	public bool IsActive { get; protected set; }
	public IPlayer Owner { get; protected set; }

	protected IDictionary<Type, IComponent> Components;

	public Entity() : this(null) { }
	public Entity(IPlayer owner) : this(Guid.NewGuid().ToString(), owner) { }
	public Entity(string id, IPlayer owner)
	{
		Id = id;
		Components = new Dictionary<Type, IComponent>();
		SetActive(true);
		Owner = owner;
	}

	public void SetActive(bool active) => IsActive = active;
	public T AddComponent<T>(IComponent component) where T : IComponent
	{
		Components.Add(typeof(T), component);
		component.Attach(this);
		return ((T)component);
	}
	public T GetComponent<T>() where T : class
	{
		if (Components.TryGetValue(typeof(T), out IComponent component)) return (component as T);
		return (null);
	}
	public IList<IComponent> GetComponents() => Components.Values.ToList();
	public void RemoveComponent<T>(IComponent component) where T : IComponent => Components.Remove(typeof(T));

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"Id={Id}");
		sb.AppendLine($"IsActive={IsActive}");
		IList<IComponent> components = GetComponents();
		for (int i = 0; i < components.Count; i++)
			sb.Append(components[i]);

		return (sb.ToString());
	}
}
