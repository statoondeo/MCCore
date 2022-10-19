using System.Collections.Generic;

public class StackService : IStackService
{
	protected IList<ICommand> CommandsStack;
	protected ICommand CurrentCommand;

	public StackService() => CommandsStack = new List<ICommand>();

	public void EnqueueCommand(ICommand command)
	{
		CommandsStack.Insert(0, new MessageCommand(MessageType.OnResponse, command.Type));
		CommandsStack.Insert(0, new MessageCommand(MessageType.OnForcedResponse, command.Type));
		CommandsStack.Insert(0, command);
		CommandsStack.Insert(0, new MessageCommand(MessageType.OnInterrupt, command.Type));
		CommandsStack.Insert(0, new MessageCommand(MessageType.OnForcedInterrupt, command.Type));
	}

	public void PerformStack()
	{
		while (CommandsStack.Count > 0)
		{
			if (CommandsStack[0].Done)
			{
				CommandsStack.RemoveAt(0);
			}
			else
			{
				CommandsStack[0].Execute();
			}
		}
	}

	public IService Initialize() => this;
}