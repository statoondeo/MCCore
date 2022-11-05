public interface ICommandFactory
{
	ICommand Create(IEntity parentEntity);
}