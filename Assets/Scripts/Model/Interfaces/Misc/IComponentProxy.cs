public interface IComponentProxy<T> : IComponent, IActivable where T : IComponent
{
	IComponentDecorator<T> Register(IComponentDecorator<T> decorator);
	void UnRegister(IComponentDecorator<T> decorator);
}

