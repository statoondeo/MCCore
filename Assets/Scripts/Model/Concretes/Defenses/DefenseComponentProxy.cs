using System.Text;

public class DefenseComponentProxy : BaseComponentProxy<IDefenseComponent>, IDefenseComponentProxy
{
	public int Def => Wrapped.Def;

	public DefenseComponentProxy(int def) : base(new DefenseComponent(def)) { }

	public void Defense() => Wrapped.Defense();
	public bool CanBeAttacked() => Wrapped.CanBeAttacked();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t DefenseComponentProxy");
		sb.AppendLine($"\t\t Def={Def}");
		sb.AppendLine($"\t\t CanBeAttacked={CanBeAttacked()}");
		return (sb.ToString());
	}
}

