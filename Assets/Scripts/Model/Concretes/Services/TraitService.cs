using UnityEngine;

public class TraitService : IndexedTankService<ITrait, string>, ITraitService
{
	public static readonly string RESOURCE_PATH = "Traits";

	public override IService Initialize()
	{
		ScriptableTrait[] items = Resources.LoadAll<ScriptableTrait>(RESOURCE_PATH);
		for (int i = 0; i < items.Length; i++)
		{
			ITrait item = items[i].Create();
			Add(item.Key, item);
		}
		return (this);
	}
}
