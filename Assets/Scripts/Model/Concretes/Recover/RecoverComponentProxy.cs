using System.Text;

public class RecoverComponentProxy : BaseComponentProxy<IRecoverComponent>, IRecoverComponentProxy
{
	public int Rec => Wrapped.Rec;

	public RecoverComponentProxy(int def) : base(new RecoverComponent(def)) { }

	public void Recover() => Wrapped.Recover();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t RecoverComponentProxy");
		sb.AppendLine($"\t\t Rec={Rec}");
		return (sb.ToString());
	}
}

