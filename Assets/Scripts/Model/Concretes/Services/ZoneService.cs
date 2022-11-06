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
		for (int i = 0; i < mZoneNames.Count; i++)
			Add((mZoneNames[i], null), Zones.CreateZone(null, mZoneNames[i]));
		return (this);
	}
	public override IEntity Add((string, IPlayer) itemId, IEntity item)
	{
		return (base.Add(itemId, item));
	}
}
