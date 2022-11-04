public class DefenseComponent : BaseComponent, IDefenseComponent
{
	public int Def { get; protected set; }

	public DefenseComponent(int def) : base() => Def = def;

	public void Defense() { }
	public bool CanBeAttacked() => true;
}
