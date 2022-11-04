using System.Collections.Generic;

public class Villain : BasePlayer, IPlayer
{
	protected static readonly IList<string> mZoneNames = new List<string>
	{
		Zones.DECK,
		Zones.DISCARD,
		Zones.EXIL,
	};
	public override IList<string> ZoneNames => mZoneNames;

	public Villain(string name) : base(name) { }
}
