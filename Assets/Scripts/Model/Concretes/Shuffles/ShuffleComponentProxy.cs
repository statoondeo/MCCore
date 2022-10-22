using System.Text;

public class ShuffleComponentProxy : BaseComponentProxy<IShuffleComponent>, IShuffleComponentProxy
{
	public ShuffleComponentProxy() : base(new ShuffleComponent()) { }

	public void Shuffle() => Wrapped.Shuffle();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t ShuffleComponentProxy");
		return (sb.ToString());
	}
}
