public abstract class BaseSetupComponentDecorator : BaseComponentDecorator<ISetupComponent>, ISetupComponentDecorator
{
	protected BaseSetupComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void Setup() => Inner.Setup();
}
