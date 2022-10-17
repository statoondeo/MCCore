public abstract class BaseFaceComponentDecorator : BaseComponentDecorator<IFaceComponent>, IFaceComponentDecorator
{
	public virtual string Name => Inner.Name;
	public virtual IEntity Face => Inner.Face;

	protected BaseFaceComponentDecorator(IActivable owner) : base(owner) { }
}
