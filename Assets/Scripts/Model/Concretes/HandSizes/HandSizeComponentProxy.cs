using System.Text;

public class HandSizeComponentProxy : BaseComponentProxy<IHandSizeComponent>, IHandSizeComponentProxy
{
	public int Size => Wrapped.Size;

	public HandSizeComponentProxy(int size) : base(new HandSizeComponent(size)) { }

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t HandSizeComponentProxy");
		sb.AppendLine($"\t\t Size={Size}");
		return (sb.ToString());
	}
}

