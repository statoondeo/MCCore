public class Player : IPlayer
{
	public string Name { get; protected set; }
	public IEntity Identity { get; protected set; }

	public Player(string name) => Name = name;

	public void SetIdentity(IEntity identity) => Identity = identity;
}
