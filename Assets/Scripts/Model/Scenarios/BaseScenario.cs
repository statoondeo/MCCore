using System.Collections.Generic;

public abstract class BaseScenario : IScenario
{
	public IList<ICommand> Commands { get; protected set; }

	protected BaseScenario() => Commands = new List<ICommand>();
}
