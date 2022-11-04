using System.Collections.Generic;

public class ZoneService : IndexedTankService<IEntity, (string, IPlayer)>, IZoneService
{
	public static readonly string RESOURCE_PATH = "Zones";
	protected static readonly IList<string> mZoneNames = new List<string>
	{
		Zones.STACK,
		Zones.BATTLEFIELD,
	};

	public override IService Initialize()
	{
		IList<IPlayer> players = ServiceLocator.Get<IPlayerService>().Get();
		for (int i = 0; i < players.Count; i++)
			for (int j = 0; j < players[i].ZoneNames.Count; j++)
				Add((players[i].ZoneNames[j], players[i]), Zones.CreateZone(players[i], players[i].ZoneNames[j]));
		for (int i = 0; i < mZoneNames.Count; i++)
			Add((mZoneNames[i], null), Zones.CreateZone(null, mZoneNames[i]));
		return (this);
	}
}
