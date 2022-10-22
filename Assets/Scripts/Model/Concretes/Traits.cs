public static class Traits
{
	public static readonly string ARMOR = "ARMOR";
	public static readonly string ATTACK = "ATTACK";
	public static readonly string AVENGER = "AVENGER";
	public static readonly string BRUTE = "BRUTE";
	public static readonly string CONDITION = "CONDITION";
	public static readonly string CRIMINAL = "CRIMINAL";
	public static readonly string ELITE = "ELITE";
	public static readonly string GAMMA = "GAMMA";
	public static readonly string HYDRA = "HYDRA";
	public static readonly string KREE = "KREE";
	public static readonly string LOCATION = "LOCATION";
	public static readonly string SHIELD = "SHIELD";
	public static readonly string SKILL = "SKILL";
	public static readonly string SOLDIER = "SOLDIER";
	public static readonly string SPY = "SPY";
	public static readonly string SUPER_POWER = "SUPER_POWER";
	public static readonly string TECH = "TECH";
	public static readonly string THWART = "THWART";
	public static readonly string WEAPON = "WEAPON";

	public static bool IsTrait(this ITraitComponentProxy traitComponent, ITrait trait)
	{
		for (int i = 0; i < traitComponent.Traits.Count; i++)
			if (traitComponent.Traits[i].Equals(trait)) return (true);
		return (false);
	}
	public static bool IsOneOfTrait(this ITraitComponentProxy traitComponent, params ITrait[] traits)
	{
		for (int i = 0; i < traits.Length; i++)
			if (traitComponent.IsTrait(traits[i])) return (true);
		return (false);
	}
	public static bool IsAllTrait(this ITraitComponentProxy traitComponent, params ITrait[] traits)
	{
		for (int i = 0; i < traits.Length; i++)
			if (!traitComponent.IsTrait(traits[i])) return (false);
		return (true);
	}
}
