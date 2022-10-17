public interface IPlayableComponent : IComponent
{
	string Name { get; }
	void Play();
}
