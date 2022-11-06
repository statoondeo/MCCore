public class PutOntoTheBattlefieldCommand : BaseCommand
{
	protected IEntity Card;

	public PutOntoTheBattlefieldCommand(IEntity card) : base(CommandType.ENTER_BATTLEFIELD) => Card = card;

	public override void Execute()
	{
		Card.GetActiveFaceComponent<IBasicComponentProxy>().MoveTo((Zones.BATTLEFIELD, null));
		base.Execute();
	}
}