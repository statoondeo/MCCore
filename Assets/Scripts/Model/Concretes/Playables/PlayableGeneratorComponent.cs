using UnityEngine;

public class PlayableGeneratorComponent : BaseComponent, IPlayableComponent
{
	public string Name { get; protected set; }

	public PlayableGeneratorComponent(string name) => Name = name;

	public bool CanPlay() => true;
	public void Play() => Debug.Log("Played");
}
