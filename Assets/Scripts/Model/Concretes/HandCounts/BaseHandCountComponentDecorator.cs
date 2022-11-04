public abstract class BaseHandCountComponentDecorator : BaseComponentDecorator<IHandCountComponent>, IHandCountComponentDecorator
{
	protected BaseHandCountComponentDecorator(IActivable owner) : base(owner) { }

	public virtual int Count() => Inner.Count();
}
