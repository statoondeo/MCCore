public abstract class BaseResolvableComponentDecorator : BaseComponentDecorator<IResolvableComponent>, IResolvableComponentDecorator
{
	protected BaseResolvableComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void Resolve() => Inner.Resolve();
	public virtual void Cancel() => Inner.Resolve();
}
