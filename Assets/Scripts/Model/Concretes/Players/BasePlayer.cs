using System.Collections.Generic;

public abstract class BasePlayer
{
	public string Name { get; protected set; }

	protected BasePlayer(string name) => Name = name;

	public IEntity Identity { get; protected set; }
	public abstract IList<string> ZoneNames { get; }
	public void SetIdentity(IEntity identity) => Identity = identity;
	public virtual void Draw() { }
}