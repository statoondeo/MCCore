public interface IStackService : IService
{
	void EnqueueCommand(ICommand command);
	void PerformStack();
}