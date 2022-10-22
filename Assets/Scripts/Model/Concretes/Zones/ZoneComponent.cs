public class ZoneComponent : BaseComponent, IZoneComponent
{
	public string Key { get; protected set; }
	public string Name { get; protected set; }

	public ZoneComponent(string key, string name) : base()
	{
		Key = key;
		Name = name;
	}
}
