public class SetupComponent : BaseComponent, ISetupComponent
{
	protected ICommand Command;

	public SetupComponent(ICommand command) : base() => Command = command;

	public void Setup() => ServiceLocator.Get<IStackService>().EnqueueCommand(Command);
}
