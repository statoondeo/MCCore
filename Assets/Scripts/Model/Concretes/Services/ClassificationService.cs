using UnityEngine;

public class ClassificationService : IndexedTankService<IClassification, string>, IClassificationService
{
	public static readonly string ITEMS_PATH = "Classifications";

	public override IService Initialize()
	{
		ScriptableClassification[] items = Resources.LoadAll<ScriptableClassification>(ITEMS_PATH);
		for (int i = 0; i < items.Length; i++)
		{
			IClassification item = items[i].Create();
			Add(item.Key, item);
		}
		return (this);
	}
}
