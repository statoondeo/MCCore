public interface IComponentDecorator<T> : IComponent where T : IComponent
{
	T Inner { get; }
	IActivable Owner { get; }
	void SetInner(T inner);
}
