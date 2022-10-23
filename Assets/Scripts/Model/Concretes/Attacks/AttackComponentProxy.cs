using System.Text;

public class AttackComponentProxy : BaseComponentProxy<IAttackComponent>, IAttackComponentProxy
{
	public int Atk => Wrapped.Atk;

	public AttackComponentProxy(int atk) : base(new AttackComponent(atk)) { }

	public void Attack() => Wrapped.Attack();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t AttackComponentProxy");
		sb.AppendLine($"\t\t Atk={Atk}");
		return (sb.ToString());
	}
}

