using System.Collections.Generic;

public class Player : BasePlayer, IPlayer
{
	protected static readonly IList<string> mZoneNames = new List<string>
	{
		Zones.DECK,
		Zones.DISCARD,
		Zones.EXIL,
		Zones.HAND,
		Zones.ENCOUNTER,
		Zones.BOOST,
	};

	public override IList<string> ZoneNames => mZoneNames;

	public Player(string name) : base(name) { }

	public override void Draw()
	{
		ITankComponentProxy deck = ServiceLocator.Get<IZoneService>().Get((Zones.DECK, this)).GetComponent<ITankComponentProxy>();
		IEntity card = deck.Get(deck.Count - 1);
		card.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.RECTO);
		card.GetComponent<IBasicComponentProxy>().MoveTo(Zones.HAND);
	}
}
