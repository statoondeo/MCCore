public class ZoneComponent : BaseComponent, IZoneComponent
{
	public string Key { get; protected set; }
	public string Name { get; protected set; }

	public ZoneComponent(string key, string name)
	{
		Key = key;
		Name = name;
	}
}
