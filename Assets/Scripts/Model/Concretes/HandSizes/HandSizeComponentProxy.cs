using System.Text;

public class HandSizeComponentProxy : BaseComponentProxy<IHandSizeComponent>, IHandSizeComponentProxy
{
	public int Size => Wrapped.Size;
	public int MaxSize => Wrapped.MaxSize;

	public HandSizeComponentProxy(int maxSize) : base(new HandSizeComponent(maxSize)) { }

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t HandSizeComponentProxy");
		sb.AppendLine($"\t\t Size={Size}");
		return (sb.ToString());
	}
}

