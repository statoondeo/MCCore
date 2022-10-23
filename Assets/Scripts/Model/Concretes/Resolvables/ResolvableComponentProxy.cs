public class ResolvableComponentProxy : BaseComponentProxy<IResolvableComponent>, IResolvableComponentProxy
{
	public ResolvableComponentProxy(IResolvableComponent resolvable) : base(resolvable) { }

	public void Resolve() => Wrapped.Resolve();
	public void Cancel() => Wrapped.Resolve();
}
