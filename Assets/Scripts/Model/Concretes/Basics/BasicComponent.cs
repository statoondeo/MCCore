public class BasicComponent : BaseComponent, IBasicComponent
{
	public IPlayer Owner { get; protected set; }
	public (string, IPlayer) Location { get; protected set; }
	public int Order { get; protected set; }

	public BasicComponent(IPlayer owner) : base() => Owner = owner;

	public bool CanMoveTo(string zoneId) => CanMoveTo((zoneId, Owner));
	public bool CanMoveTo((string, IPlayer) zoneId) => Location != zoneId;
	public void MoveTo(string zoneId) => MoveTo((zoneId, Owner));
	public void MoveTo((string, IPlayer) zoneId)
	{
		IZoneService zoneService = ServiceLocator.Get<IZoneService>();
		if ((null, null) != Location) zoneService.Get(Location).GetComponent<ITankComponentProxy>().Remove(Entity);

		Location = zoneId;
		zoneService.Get(Location).GetComponent<ITankComponentProxy>().Add(Entity);
	}
	public void SetOrder(int order) => Order = order;
}
