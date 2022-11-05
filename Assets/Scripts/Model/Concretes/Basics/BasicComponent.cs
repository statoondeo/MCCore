public class BasicComponent : BaseComponent, IBasicComponent
{
	public (string, IPlayer) Location { get; protected set; }
	public int Order { get; protected set; }

	public BasicComponent() : base() { }

	public bool CanMoveTo(string zoneId) => CanMoveTo((zoneId, Entity.Owner));
	public bool CanMoveTo((string, IPlayer) zoneId) => Location != zoneId;
	public void MoveTo(string zoneId) => MoveTo((zoneId, Entity.Owner));
	public void MoveTo((string, IPlayer) zoneId)
	{
		IZoneService zoneService = ServiceLocator.Get<IZoneService>();
		if ((null, null) != Location) zoneService.Get(Location).GetComponent<ITankComponentProxy>().Remove(Entity);

		Location = zoneId;
		zoneService.Get(Location).GetComponent<ITankComponentProxy>().Add(Entity);
	}
	public void SetOrder(int order) => Order = order;
}
