public interface IPlayer
{
	string Name { get; }
	IEntity Identity { get; }
	void SetIdentity(IEntity identity);
}
