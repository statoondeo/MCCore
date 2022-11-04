public static class Zones
{
	#region Names

	public const string STACK = "STACK";
	public const string BATTLEFIELD = "BATTLEFIELD";
	public const string DISCARD = "DISCARD";
	public const string DECK = "DECK";
	public const string EXIL = "EXIL";
	public const string HAND = "HAND";
	public const string BOOST = "BOOST";
	public const string ENCOUNTER = "ENCOUNTER";

	#endregion

	#region Helpers

	public static bool IsLocation(this IBasicComponentProxy basicComponent, (string, IPlayer) location) => basicComponent.Location == location;
	public static bool IsOneOfLocation(this IBasicComponentProxy basicComponent, params (string, IPlayer)[] locations)
	{
		for (int i = 0; i < locations.Length; i++)
			if (basicComponent.IsLocation(locations[i])) return (true);
		return (false);
	}

	#endregion

	#region Factories

	public static IEntity CreateZone(IPlayer player, string zoneId)
	{
		IEntity zone = new Entity();
		zone.AddComponent<IZoneComponentProxy>(new ZoneComponentProxy(zoneId, zoneId));
		zone.AddComponent<ITankComponentProxy>(new TankComponentProxy());

		switch (zoneId)
		{
			case DECK:
				zone.AddComponent<IShuffleComponentProxy>(new ShuffleComponentProxy());
				ServiceLocator.Get<IStateBasedEffectService>().Register(new EmptyDeckStateBasedEffect(player, DECK, DISCARD));
				break;
			case HAND:
				zone.AddComponent<IHandCountComponentProxy>(new HandCountComponentProxy());
				break;
		}
		return (zone);
	}

	#endregion
}
