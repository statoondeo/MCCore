public class Trait : ITrait
{
	public string Key { get; protected set; }
	public string Name { get; protected set; }

	public Trait(string name, string key)
	{
		Name = name;
		Key = key;
	}

	public override string ToString() => Name;
}