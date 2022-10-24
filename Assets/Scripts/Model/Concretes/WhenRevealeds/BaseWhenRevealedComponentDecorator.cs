public abstract class BaseWhenRevealedComponentDecorator : BaseComponentDecorator<IWhenRevealedComponent>, IWhenRevealedComponentDecorator
{
	protected BaseWhenRevealedComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void WhenRevealed() => Inner.WhenRevealed();
}
