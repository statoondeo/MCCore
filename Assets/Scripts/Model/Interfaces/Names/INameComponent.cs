using UnityEngine;

public interface INameComponent : IComponent
{
	Sprite Image { get; }
	string Name { get; }
}
