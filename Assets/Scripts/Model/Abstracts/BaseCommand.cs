public abstract class BaseCommand : ICommand
{
	public virtual string Type { get; protected set; }
	public virtual bool Done { get; protected set; }

	protected BaseCommand(string type)
	{
		Done = false;
		Type = type;
	}

	public virtual bool CanExecute() => true;
	public virtual void Execute() => Done = true;
}
public interface IContainerCommand : ICommand 
{
	void SetState(IStateCommand state);
}
public interface IStateCommand : ICommand 
{
	IContainerCommand Container { get; } 
}
public class StateCommand : BaseCommand, IStateCommand
{
	public IContainerCommand Container { get; protected set; }

	protected IStateCommand NextState;
	protected (MessageType, string)? Message;

	public StateCommand(IContainerCommand container, (MessageType, string) message) : this(container, null, message) { }
	public StateCommand(IContainerCommand container, IStateCommand nextState) : this(container, nextState, null) { }
	public StateCommand(IContainerCommand container, IStateCommand nextState, (MessageType, string)? message) : base(container.Type)
	{
		Container = container;
		NextState = nextState;
		Message = message;
	}

	public override void Execute()
	{
		if (NextState != null) Container.SetState(NextState);
		if (null != Message) ServiceLocator.Get<IMessageService>().Raise(((MessageType, string))Message);
		base.Execute();
	}
}
public class ExecuteStateCommand : StateCommand
{
	protected ICommand Command;

	public ExecuteStateCommand(IContainerCommand container, IStateCommand nextState, ICommand command) 
		: base(container, nextState) => Command = command;

	public override void Execute()
	{
		Command.Execute();
		Container.SetState(NextState);
		base.Execute();
	}
}
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