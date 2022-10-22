using UnityEngine;

[CreateAssetMenu(fileName = "Zone", menuName = "Zone")]
public class ScriptableZone : ScriptableObject
{
	public string Key;
	[SerializeField] protected string Name;
	[SerializeField] protected bool Shufflable;

	public IEntity Create()
	{
		IEntity entity = new Entity();
		entity.AddComponent<IZoneComponentProxy>(new ZoneComponentProxy(Key, Name));
		entity.AddComponent<ITankComponentProxy>(new TankComponentProxy());
		if (Shufflable) entity.AddComponent<IShuffleComponentProxy>(new ShuffleComponentProxy());
		return (entity);
	}
}
