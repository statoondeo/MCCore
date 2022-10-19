using System.Collections.Generic;

public interface IBasicComponentProxy : IComponentProxy<IBasicComponent>, IBasicComponent 
{
	IDictionary<string, ICommand> MoveCommands { get; }
}
