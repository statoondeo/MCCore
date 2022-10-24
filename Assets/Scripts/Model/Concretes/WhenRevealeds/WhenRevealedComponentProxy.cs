using System.Text;

public class WhenRevealedComponentProxy : BaseComponentProxy<IWhenRevealedComponent>, IWhenRevealedComponentProxy
{
	public WhenRevealedComponentProxy() : base(new WhenRevealedComponent()) { }

	public void WhenRevealed() => Wrapped.WhenRevealed();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t WhenRevealedComponentProxy");
		return (sb.ToString());
	}
}

