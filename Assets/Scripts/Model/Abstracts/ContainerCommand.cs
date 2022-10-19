public class ContainerCommand : BaseCommand, IContainerCommand
{
	public override bool Done => State.Done;

	protected IStateCommand State;

	public ContainerCommand(ICommand command) : base(command.Type) 
	{
		IStateCommand stateCommand = new StateCommand(this, (MessageType.OnResponse, Type));
		stateCommand = new StateCommand(this, stateCommand, (MessageType.OnForcedResponse, Type));
		stateCommand = new ExecuteStateCommand(this, stateCommand, command);
		stateCommand = new StateCommand(this, stateCommand, (MessageType.OnInterrupt, Type));
		State = new StateCommand(this, stateCommand, (MessageType.OnForcedInterrupt, Type));
	}

	public override bool CanExecute() => State.CanExecute();
	public override void Execute() => State.Execute();
	public void SetState(IStateCommand state) => State = state;
}
