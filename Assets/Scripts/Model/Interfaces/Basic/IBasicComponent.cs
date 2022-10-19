public interface IBasicComponent : IComponent
{
	string Location { get; }
	int Order { get; }

	bool CanMoveTo(string zoneId);
	void MoveTo(string zoneId);
	void SetOrder(int order);
}
