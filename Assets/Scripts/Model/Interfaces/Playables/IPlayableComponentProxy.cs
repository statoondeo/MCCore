public interface IPlayableComponentProxy : IComponentProxy<IPlayableComponent>, IPlayableComponent
{
	ICommand PlayCommand {get;}
}
