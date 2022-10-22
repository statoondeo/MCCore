public class Classification : IClassification
{
	public string Key { get; protected set; }
	public string Name { get; protected set; }

	public Classification(string name, string key)
	{
		Name = name;
		Key = key;
	}

	public override string ToString() => Name;

}
