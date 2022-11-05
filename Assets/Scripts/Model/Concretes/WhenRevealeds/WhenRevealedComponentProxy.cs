using System.Text;

public class WhenRevealedComponentProxy : BaseComponentProxy<IWhenRevealedComponent>, IWhenRevealedComponentProxy
{
	public WhenRevealedComponentProxy(ICommand command) : base(new WhenRevealedComponent(command)) { }

	public void WhenRevealed() => Wrapped.WhenRevealed();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t WhenRevealedComponentProxy");
		return (sb.ToString());
	}
}

