public static class CardTypes
{
	public static readonly string HERO = "HERO";
	public static readonly string ALTER_EGO = "ALTER_EGO";
	public static readonly string UPGRADE = "UPGRADE";
	public static readonly string SUPPORT = "SUPPORT";
	public static readonly string EVENT = "EVENT";
	public static readonly string RESOURCE = "RESOURCE";
	public static readonly string ALLY = "ALLY";

	public static readonly string VILLAIN = "VILLAIN";
	public static readonly string MAIN_SCHEME = "MAIN_SCHEME";
	public static readonly string ATTACHMENT = "ATTACHMENT";
	public static readonly string MINION = "MINION";
	public static readonly string TREACHERY = "TREACHERY";
	public static readonly string SIDE_SCHEME = "SIDE_SCHEME";
	public static readonly string OBLIGATION = "OBLIGATION";

	public static bool IsCardType(this ICardComponent cardComponent, ICardType cardType) => cardComponent.CardType.Equals(cardType);
	public static bool IsOneOfCardType(this ICardComponent cardComponent, params ICardType[] cardTypes)
	{
		for (int i = 0; i < cardTypes.Length; i++)
			if (cardComponent.IsCardType(cardTypes[i])) return (true);
		return (false);
	}
}
