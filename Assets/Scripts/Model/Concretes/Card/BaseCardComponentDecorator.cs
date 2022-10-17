public abstract class BaseCardComponentDecorator : BaseComponentDecorator<ICardComponent>, ICardComponentDecorator
{
	public virtual ICardType CardType => Inner.CardType;

	protected BaseCardComponentDecorator(IActivable owner) : base(owner) { }
}
