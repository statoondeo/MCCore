using System.Text;

public class StageComponentProxy : BaseComponentProxy<IStageComponent>, IStageComponentProxy
{
	public string Stage => Wrapped.Stage;

	public StageComponentProxy(string stage) : base(new StageComponent(stage)) { }

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t StageComponentProxy");
		sb.AppendLine($"\t\t Stage={Stage}");
		return (sb.ToString());
	}
}

