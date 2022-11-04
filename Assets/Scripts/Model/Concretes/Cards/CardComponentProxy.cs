using System.Text;

public class CardComponentProxy : BaseComponentProxy<ICardComponent>, ICardComponentProxy
{
	public int HandSize => Wrapped.HandSize;
	public ICardType CardType => Wrapped.CardType;
	public IClassification Classification => Wrapped.Classification;

	public CardComponentProxy(ICardType cardType, IClassification classification) : base(new CardComponent(cardType, classification)) { }

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t CardComponentProxy");
		sb.AppendLine($"\t\t HandSize={HandSize}");
		sb.AppendLine($"\t\t CardType={CardType}");
		sb.AppendLine($"\t\t Classification={Classification}");
		return (sb.ToString());
	}
}
