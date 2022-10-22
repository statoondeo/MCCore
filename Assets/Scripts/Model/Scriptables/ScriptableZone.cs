using UnityEngine;

[CreateAssetMenu(fileName = "Zone", menuName = "Zone")]
public class ScriptableZone : ScriptableObject
{
	public string Key;
	[SerializeField] protected string Name;

	public IEntity Create()
	{
		IEntity entity = new Entity();
		entity.AddComponent<IZoneComponentProxy>(new ZoneComponentProxy(Key, Name));
		entity.AddComponent<ITankComponentProxy>(new TankComponentProxy());
		return (entity);
	}
}
