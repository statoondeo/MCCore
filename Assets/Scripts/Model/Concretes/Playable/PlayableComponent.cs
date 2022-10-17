public class PlayableComponent : BaseComponent, IPlayableComponent
{
	public string Name { get; protected set; }

	public PlayableComponent(string name) => Name = name;

	public void Play()
	{
		IBasicComponent basicComponent = Entity.GetComponent<IBasicComponentProxy>();
		basicComponent.MoveTo("STACK");
	}
}
