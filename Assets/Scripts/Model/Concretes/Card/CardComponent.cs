public class CardComponent : BaseComponent, ICardComponent
{
	public ICardType CardType { get; protected set; }

	public CardComponent(ICardType cardType) : base() => CardType = cardType;
}
