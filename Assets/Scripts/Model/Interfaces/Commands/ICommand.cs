public interface ICommand
{
	string Type { get; }
	bool Done { get; }
	bool CanExecute();
	void Execute();
}
