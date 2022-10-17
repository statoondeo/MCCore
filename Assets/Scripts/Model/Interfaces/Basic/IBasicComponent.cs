public interface IBasicComponent : IComponent
{
	string Location { get; }
	int Order { get; }

	void MoveTo(string zoneId);
	void SetOrder(int order);
}
