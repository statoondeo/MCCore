public abstract class BaseLifeComponentDecorator : BaseComponentDecorator<ILifeComponent>, ILifeComponentDecorator
{
	public virtual int HitPoints => Inner.HitPoints;
	public virtual int Damages => Inner.Damages;

	protected BaseLifeComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void DealDamage() => Inner.DealDamage();
}
