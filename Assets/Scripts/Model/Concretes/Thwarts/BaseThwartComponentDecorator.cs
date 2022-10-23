public abstract class BaseThwartComponentDecorator : BaseComponentDecorator<IThwartComponent>, IThwartComponentDecorator
{
	public virtual int Thw => Inner.Thw;

	protected BaseThwartComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void Thwart() => Inner.Thwart();
}
