public interface ILifeComponent : IComponent
{
	int HitPoints { get; }
	int Damages { get; }
	void TakeDamage(int amount);
}
