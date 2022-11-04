public abstract class BaseCardComponentDecorator : BaseComponentDecorator<ICardComponent>, ICardComponentDecorator
{
	public virtual int HandSize => Inner.HandSize;
	public virtual ICardType CardType => Inner.CardType;
	public virtual IClassification Classification => Inner.Classification;

	protected BaseCardComponentDecorator(IActivable owner) : base(owner) { }
}
