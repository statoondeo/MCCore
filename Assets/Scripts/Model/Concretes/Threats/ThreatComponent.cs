using System;

public class ThreatComponent : BaseComponent, IThreatComponent
{
	public int Threat { get; protected set; }

	public ThreatComponent(int threat) : base() => Threat = threat;

	public void AddThreat(int threat) => Threat += threat;
	public void RemoveThreat(int threat) => Threat = Math.Max(Threat - threat, 0);
}
