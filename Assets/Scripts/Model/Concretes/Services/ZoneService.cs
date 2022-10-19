using UnityEngine;

public class ZoneService : IndexedTankService<IZone, string>, IZoneService
{
	public static readonly string RESOURCE_PATH = "Zones";

	public override IService Initialize()
	{
		ScriptableZone[] items = Resources.LoadAll<ScriptableZone>(RESOURCE_PATH);
		for (int i = 0; i < items.Length; i++)
		{
			IZone item = items[i].Create();
			Add(item.Key, item);
		}
		return (this);
	}
}
