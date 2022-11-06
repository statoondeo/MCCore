using System;

public class GenericCommand : ICommand
{
	public string Type => CommandType.NONE;
	public bool Done { get; protected set; }

	protected Action Action;

	public GenericCommand(Action action) => Action = action;

	public bool CanExecute() => true;

	public void Execute()
	{
		Action.Invoke();
		Done = true;
	}
}
