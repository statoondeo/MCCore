public interface IPlayableComponent : IComponent
{
	string Name { get; }
	bool CanPlay();
	void Play();
}
