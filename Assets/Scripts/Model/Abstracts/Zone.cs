public class Zone : IZone
{
	public string Key { get; protected set; }
	public string Name { get; protected set; }

	public Zone(string name, string key)
	{
		Name = name;
		Key = key;
	}

	public override string ToString() => Name;
}