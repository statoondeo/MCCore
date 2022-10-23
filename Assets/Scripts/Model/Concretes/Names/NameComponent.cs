using UnityEngine;

public class NameComponent : BaseComponent, INameComponent
{
	public string Name { get; protected set; }
	public Sprite Image { get; protected set; }

	public NameComponent(string name, Sprite image) : base()
	{
		Name = name;
		Image = image;
	}
}
