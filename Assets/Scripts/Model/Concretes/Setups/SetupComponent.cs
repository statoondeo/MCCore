public class SetupComponent : BaseComponent, ISetupComponent
{
	protected ICommand Command;

	public SetupComponent(ICommand command) : base() => Command = command;

	public void Setup() => Command.Execute();
}
