using System;

public class GenericCommand : ICommand
{
	public string Type => CommandType.NONE;
	public bool Done => true;

	protected Action Action;

	public GenericCommand(Action action) => Action = action;

	public bool CanExecute() => true;

	public void Execute() => Action.Invoke();
}
