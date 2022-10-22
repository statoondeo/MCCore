public abstract class BaseShuffleComponentDecorator : BaseComponentDecorator<IShuffleComponent>, IShuffleComponentDecorator
{
	protected BaseShuffleComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void Shuffle() => Inner.Shuffle();
}
