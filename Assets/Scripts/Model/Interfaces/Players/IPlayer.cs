using System.Collections.Generic;

public interface IPlayer
{
	string Name { get; }
	IList<string> ZoneNames { get; }
	IEntity Identity { get; }
	void SetIdentity(IEntity identity);
	void Draw();
}
