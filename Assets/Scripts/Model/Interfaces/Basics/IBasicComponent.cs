public interface IBasicComponent : IComponent
{
	(string, IPlayer) Location { get; }
	int Order { get; }

	bool CanMoveTo(string zoneId);
	bool CanMoveTo((string, IPlayer) zoneId);
	void MoveTo(string zoneId);
	void MoveTo((string, IPlayer) zoneId);
	void SetOrder(int order);
}
