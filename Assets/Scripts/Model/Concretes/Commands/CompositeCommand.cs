public class CompositeCommand : BaseCommand
{
	protected ICommand[] Commands;

	public CompositeCommand(ICommand[] commands, string type) : base(type) => Commands = commands;

	public override bool Done
	{
		get
		{
			bool done = true;
			int i = 0;
			while (done && (i < Commands.Length))
			{
				done = done && Commands[i].Done;
				i++;
			}
			return (done);
		}
	}
	public override bool CanExecute()
	{
		bool canExecute = true;
		int i = 0;
		while (canExecute && (i < Commands.Length))
		{
			canExecute = canExecute && Commands[i].CanExecute();
			i++;
		}
		return (canExecute);
	}
	public override void Execute()
	{
		for (int i = 0; i < Commands.Length; i++) ServiceLocator.Get<IStackService>().EnqueueCommand(Commands[i]);
		base.Execute();
	}
}
