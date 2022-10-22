public class BasicComponent : BaseComponent, IBasicComponent
{
	public string Location { get; protected set; }
	public int Order { get; protected set; }

	public BasicComponent() : base() { }

	public bool CanMoveTo(string zoneId) => Location != zoneId;
	public void MoveTo(string zoneId)
	{
		IEntity entity;
		ITankComponentProxy tankZone;
		if (!string.IsNullOrWhiteSpace(Location))
		{
			entity = ServiceLocator.Get<IZoneService>().Get(Location);
			tankZone = entity.GetComponent<ITankComponentProxy>();
			tankZone.Remove(entity);
		}

		entity = ServiceLocator.Get<IZoneService>().Get(zoneId);
		IZoneComponentProxy zone = entity.GetComponent<IZoneComponentProxy>();
		tankZone = entity.GetComponent<ITankComponentProxy>();
		tankZone.Add(Entity);

		Location = zone.Key;
	}
	public void SetOrder(int order) => Order = order;
}
