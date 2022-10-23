public abstract class BaseAttackComponentDecorator : BaseComponentDecorator<IAttackComponent>, IAttackComponentDecorator
{
	public virtual int Atk => Inner.Atk;

	protected BaseAttackComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void Attack() => Inner.Attack();
}
