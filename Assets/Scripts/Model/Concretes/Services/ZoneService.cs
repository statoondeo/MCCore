using UnityEngine;

public class ZoneService : IndexedTankService<IEntity, string>, IZoneService
{
	public static readonly string RESOURCE_PATH = "Zones";

	public override IService Initialize()
	{
		ScriptableZone[] items = Resources.LoadAll<ScriptableZone>(RESOURCE_PATH);
		for (int i = 0; i < items.Length; i++)
		{
			IEntity item = items[i].Create();
			IZoneComponentProxy zoneComponentProxy = item.GetComponent<IZoneComponentProxy>();
			Add(zoneComponentProxy.Key, item);
		}
		return (this);
	}
}
