public class AdvanceToNextStageCommand : ICommand
{
	protected IEntity Card;

	public AdvanceToNextStageCommand(IEntity player) => Card = player;

	public string Type => CommandType.NONE;
	public bool Done { get; protected set; }
	public bool CanExecute() => true;
	public void Execute()
	{
		Card.GetComponent<IFaceContainerComponentProxy>().FlipToNext();
		Done = true;
	}
}
