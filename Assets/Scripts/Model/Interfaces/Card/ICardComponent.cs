public interface ICardComponent : IComponent
{
	ICardType CardType { get; }
	IClassification Classification { get; }
}
