using System.Text;

public class ThreatComponentProxy : BaseComponentProxy<IThreatComponent>, IThreatComponentProxy
{
	public int Threat => Wrapped.Threat;

	public ThreatComponentProxy(int treat) : base(new ThreatComponent(treat)) { }

	public void AddThreat(int threat) => Wrapped.AddThreat(threat);
	public void RemoveThreat(int threat) => Wrapped.RemoveThreat(threat);

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t ThreatComponentProxy");
		sb.AppendLine($"\t\t Threat={Threat}");
		return (sb.ToString());
	}
}

