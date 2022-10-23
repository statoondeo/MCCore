public class AttackComponent : BaseComponent, IAttackComponent
{
	public int Atk { get; protected set; }

	public AttackComponent(int atk) : base() => Atk = atk;

	public void Attack() { }
}
