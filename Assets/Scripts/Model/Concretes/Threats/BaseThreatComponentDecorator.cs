public abstract class BaseThreatComponentDecorator : BaseComponentDecorator<IThreatComponent>, IThreatComponentDecorator
{
	public virtual int Threat => Inner.Threat;

	protected BaseThreatComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void AddThreat(int threat) => Inner.AddThreat(threat);
	public virtual void RemoveThreat(int threat) => Inner.RemoveThreat(threat);
}
