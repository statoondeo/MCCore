public interface IComponent
{
	IEntity Entity { get; }
	void Attach(IEntity Entity);
	void Detach();
}
