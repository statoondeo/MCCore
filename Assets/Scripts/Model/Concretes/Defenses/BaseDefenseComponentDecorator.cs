public abstract class BaseDefenseComponentDecorator : BaseComponentDecorator<IDefenseComponent>, IDefenseComponentDecorator
{
	public virtual int Def => Inner.Def;

	protected BaseDefenseComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void Defense() => Inner.Defense();

	public virtual bool CanBeAttacked() => Inner.CanBeAttacked();
}
