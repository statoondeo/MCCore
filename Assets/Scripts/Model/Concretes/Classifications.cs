public static class Classifications
{
	public static readonly string HERO = "HERO";
	public static readonly string NEMESIS = "NEMESIS";
	public static readonly string VILLAIN = "VILLAIN";
	public static readonly string AGGRESSION = "AGGRESSION";
	public static readonly string JUSTICE = "JUSTICE";
	public static readonly string LEADERSHIP = "LEADERSHIP";
	public static readonly string PROTECTED = "PROTECTED";
	public static readonly string BASIC = "BASIC";

	public static bool IsClassification(this ICardComponent cardComponent, IClassification classification) 
		=> cardComponent.Classification.Equals(classification);
}
