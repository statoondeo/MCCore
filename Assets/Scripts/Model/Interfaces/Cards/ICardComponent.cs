public interface ICardComponent : IComponent
{
	int HandSize { get; }
	ICardType CardType { get; }
	IClassification Classification { get; }
}
