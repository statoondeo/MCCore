public abstract class BaseSchemeComponentDecorator : BaseComponentDecorator<ISchemeComponent>, ISchemeComponentDecorator
{
	public virtual int Sch => Inner.Sch;

	protected BaseSchemeComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void Scheme() => Inner.Scheme();
}
