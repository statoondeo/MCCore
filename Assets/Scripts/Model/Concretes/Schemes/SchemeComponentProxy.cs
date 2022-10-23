using System.Text;

public class SchemeComponentProxy : BaseComponentProxy<ISchemeComponent>, ISchemeComponentProxy
{
	public int Sch => Wrapped.Sch;

	public SchemeComponentProxy(int sch) : base(new SchemeComponent(sch)) { }

	public void Scheme() => Wrapped.Scheme();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t SchemeComponentProxy");
		sb.AppendLine($"\t\t Sch={Sch}");
		return (sb.ToString());
	}
}

