public abstract class BaseHandSizeComponentDecorator : BaseComponentDecorator<IHandSizeComponent>, IHandSizeComponentDecorator
{
	public virtual int Size => Inner.Size;

	protected BaseHandSizeComponentDecorator(IActivable owner) : base(owner) { }
}
