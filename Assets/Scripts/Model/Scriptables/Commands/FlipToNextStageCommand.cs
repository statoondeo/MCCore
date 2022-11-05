public class FlipToNextStageCommand : ICommand
{
	protected IEntity Card;

	public FlipToNextStageCommand(IEntity player) => Card = player;

	public string Type => throw new System.NotImplementedException();
	public bool Done { get; protected set; }
	public bool CanExecute() => true;
	public void Execute() => Card.GetComponent<IFaceContainerComponentProxy>().FlipTo((Card.GetActiveFaceComponent<IStageComponentProxy>().Stage + 1).ToString());
}
