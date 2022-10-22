public abstract class BaseZoneComponentDecorator : BaseComponentDecorator<IZoneComponent>, IZoneComponentDecorator
{
	public virtual string Key => Inner.Key;
	public virtual string Name => Inner.Name;

	protected BaseZoneComponentDecorator(IActivable owner) : base(owner) { }
}
