public class WhenRevealedComponent : BaseComponent, IWhenRevealedComponent
{
	protected ICommand Command;

	public WhenRevealedComponent(ICommand command) : base() => Command = command;

	public void WhenRevealed() => ServiceLocator.Get<IStackService>().EnqueueCommand(Command);
}
