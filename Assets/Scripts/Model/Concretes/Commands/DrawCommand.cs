public class DrawCommand : BaseCommand
{
	protected IPlayer Player;

	public DrawCommand(IPlayer player) : base(CommandType.DRAW) => Player = player;

	public override void Execute()
	{
		ITankComponentProxy deck = ServiceLocator.Get<IZoneService>().Get((Zones.DECK, Player)).GetComponent<ITankComponentProxy>();
		IEntity card = deck.Get(deck.Count - 1);
		card.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.RECTO);
		IBasicComponentProxy basicComponentProxy = card.GetComponent<IBasicComponentProxy>();
		basicComponentProxy.MoveTo(Zones.HAND);
		base.Execute();
	}
}
