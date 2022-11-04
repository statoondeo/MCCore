using System.Text;

public class HandCountComponentProxy : BaseComponentProxy<IHandCountComponent>, IHandCountComponentProxy
{
	public HandCountComponentProxy() : base(new HandCountComponent()) { }

	public int Count() => Wrapped.Count();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t HandCountComponentProxy");
		sb.AppendLine($"\t Count={Count()}");
		return (sb.ToString());
	}
}
