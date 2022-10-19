using System.Collections.Generic;

public interface IScenario
{
	IList<ICommand> Commands { get; }
}