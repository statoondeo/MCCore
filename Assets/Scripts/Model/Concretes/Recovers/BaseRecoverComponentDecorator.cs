public abstract class BaseRecoverComponentDecorator : BaseComponentDecorator<IRecoverComponent>, IRecoverComponentDecorator
{
	public virtual int Rec => Inner.Rec;

	protected BaseRecoverComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void Recover() => Inner.Recover();
}
