public interface IResolvableComponent : IComponent
{
	void Resolve();
	void Cancel();
}