public class CardComponent : BaseComponent, ICardComponent
{
	public int HandSize { get; protected set; }
	public ICardType CardType { get; protected set; }
	public IClassification Classification { get; protected set; }

	public CardComponent(ICardType cardType, IClassification classification, int handSize = 1) : base()
	{
		CardType = cardType;
		Classification = classification;
		HandSize = handSize;
	}
}
