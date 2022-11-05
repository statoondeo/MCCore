public interface IThreatComponent : IComponent
{
	int Threat { get; }
	void AddThreat(int threat);
	void RemoveThreat(int threat);
}
