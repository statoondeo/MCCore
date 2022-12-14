public abstract class BaseBasicComponentDecorator : BaseComponentDecorator<IBasicComponent>, IBasicComponentDecorator
{
	public virtual (string, IPlayer) Location => Inner.Location;
	public virtual int Order => Inner.Order;
	
	protected BaseBasicComponentDecorator(IActivable owner) : base(owner) { }

	public virtual bool CanMoveTo(string zoneId) => Inner.CanMoveTo(zoneId);
	public virtual bool CanMoveTo((string, IPlayer) zoneId) => Inner.CanMoveTo(zoneId);
	public virtual void MoveTo(string zoneId) => Inner.MoveTo(zoneId);
	public virtual void MoveTo((string, IPlayer) zoneId) => Inner.MoveTo(zoneId);
	public virtual void SetOrder(int order) => Inner.SetOrder(order);
}
