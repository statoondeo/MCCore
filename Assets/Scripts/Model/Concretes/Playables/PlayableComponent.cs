using UnityEngine;

public class PlayableComponent : BaseComponent, IPlayableComponent
{
	public string Name { get; protected set; }

	public PlayableComponent(string name) => Name = name;

	public bool CanPlay() => true;
	public void Play() => Debug.Log("Played");
}
