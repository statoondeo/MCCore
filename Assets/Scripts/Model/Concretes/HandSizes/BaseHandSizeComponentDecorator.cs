public abstract class BaseHandSizeComponentDecorator : BaseComponentDecorator<IHandSizeComponent>, IHandSizeComponentDecorator
{
	public virtual int Size => Inner.Size;
	public virtual int MaxSize => Inner.MaxSize;

	protected BaseHandSizeComponentDecorator(IActivable owner) : base(owner) { }
}
