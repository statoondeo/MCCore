public abstract class BasePlayableComponentDecorator : BaseComponentDecorator<IPlayableComponent>, IPlayableComponentDecorator
{
	public virtual string Name => Inner.Name;

	protected BasePlayableComponentDecorator(IActivable owner) : base(owner) { }

	public virtual bool CanPlay() => Inner.CanPlay();
	public virtual void Play() => Inner.Play();
}
