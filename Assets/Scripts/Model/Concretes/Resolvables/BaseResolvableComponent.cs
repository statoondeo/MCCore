public abstract class BaseResolvableComponent : BaseComponent, IResolvableComponent
{
	protected BaseResolvableComponent() { }

	public abstract void Resolve();
	public abstract void Cancel();
}
