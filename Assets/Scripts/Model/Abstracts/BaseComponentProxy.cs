public abstract class BaseComponentProxy<T> : IComponentProxy<T> where T : IComponent
{
	public IEntity Entity => Wrapped.Entity;
	public bool IsActive { get; protected set; }

	protected T Wrapped;

	protected BaseComponentProxy(T wrapped)
	{
		Wrapped = wrapped;
		SetActive(true);
	}

	public void SetActive(bool active) => IsActive = active;
	public void Attach(IEntity entity) => Wrapped.Attach(entity);
	public void Detach() => Wrapped.Detach();
	public IComponentDecorator<T> Register(IComponentDecorator<T> decorator)
	{
		decorator.SetInner(Wrapped);
		Wrapped = (T)decorator;
		return (decorator);
	}
	public void UnRegister(IComponentDecorator<T> decorator)
	{
		IComponentDecorator<T> previous = null;
		IComponentDecorator<T> current = Wrapped as IComponentDecorator<T>;
		while (null != current)
		{
			if (decorator.Equals(current))
			{
				if (null == previous)
				{
					Wrapped = (T)current.Inner;
				}
				else
				{
					previous.SetInner(current.Inner);
				}
				return;
			}
			previous = current;
			current = current.Inner as IComponentDecorator<T>;
		}
	}
}

