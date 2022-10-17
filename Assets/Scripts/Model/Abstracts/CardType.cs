public class CardType : ICardType
{
	public string Key { get; protected set; }
	public string Name { get; protected set; }

	public CardType(string name, string key)
	{
		Name = name;
		Key = key;
	}

	public override string ToString() => Name;

}
