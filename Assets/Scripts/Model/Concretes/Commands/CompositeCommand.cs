public class CompositeCommand : ICommand
{
	protected ICommand[] Commands;

	public CompositeCommand(params ICommand[] commands) => Commands = commands;

	public string Type => CommandType.NONE;
	public bool Done { get; protected set; }
	public bool CanExecute() => true;
	public void Execute()
	{
		for (int i = 0; i < Commands.Length; i++) Commands[i].Execute();
		Done = true;
	}
}