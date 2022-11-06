public class DiscardCommand : BaseCommand
{
	protected IEntity Card;

	public DiscardCommand(IEntity card) : base(CommandType.DISCARD) => Card = card;

	public override void Execute()
	{
		Card.GetActiveFaceComponent<IBasicComponentProxy>().MoveTo(Zones.DISCARD);
		Card.GetActiveFaceComponent<IFaceContainerComponentProxy>().FlipTo(Faces.RECTO);
		base.Execute();
	}
}
