using System.Text;

public class CardComponentProxy : BaseComponentProxy<ICardComponent>, ICardComponentProxy
{
	public ICardType CardType => Wrapped.CardType;

	public CardComponentProxy(ICardType cardType) : base(new CardComponent(cardType)) { }

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t CardComponentProxy");
		sb.AppendLine($"\t\t CardType={CardType}");
		return (sb.ToString());
	}
}
