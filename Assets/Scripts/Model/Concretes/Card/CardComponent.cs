public class CardComponent : BaseComponent, ICardComponent
{
	public ICardType CardType { get; protected set; }
	public IClassification Classification { get; protected set; }

	public CardComponent(ICardType cardType, IClassification classification) : base()
	{
		CardType = cardType;
		Classification = classification;
	}
}
