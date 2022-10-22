public static class Zones
{
	public static readonly string STACK = "STACK";
	public static readonly string BATTLEFIELD = "BATTLEFIELD";
	public static readonly string PLAYER_DISCARD = "PLAYER_DISCARD";
	public static readonly string PLAYER_DECK = "PLAYER_DECK";
	public static readonly string PLAYER_EXIL = "PLAYER_EXIL";
	public static readonly string HAND = "HAND";
	public static readonly string VILLAIN_DISCARD = "VILLAIN_DISCARD";
	public static readonly string VILLAIN_DECK = "VILLAIN_DECK";
	public static readonly string VILLAIN_EXIL = "VILLAIN_EXIL";
	public static readonly string BOOST = "BOOST";
	public static readonly string ENCOUNTER = "ENCOUNTER";

	public static bool IsLocation(this IBasicComponentProxy basicComponent, string location) => basicComponent.Location == location;
	public static bool IsOneOfLocation(this IBasicComponentProxy basicComponent, params string[] locations)
	{
		for (int i = 0; i < locations.Length; i++)
			if (basicComponent.IsLocation(locations[i])) return (true);
		return (false);
	}
}
