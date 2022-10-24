using System.Text;

public class SetupComponentProxy : BaseComponentProxy<ISetupComponent>, ISetupComponentProxy
{
	public SetupComponentProxy() : base(new SetupComponent()) { }

	public void Setup() => Wrapped.Setup();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t SetupComponentProxy");
		return (sb.ToString());
	}
}

