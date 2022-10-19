using System.Collections.Generic;

public interface IFaceContainerComponentProxy : IComponentProxy<IFaceContainerComponent>, IFaceContainerComponent 
{
	IDictionary<string, ICommand> FlipCommands { get; }
}
