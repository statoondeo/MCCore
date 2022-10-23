public interface ILifeComponent : IComponent
{
	int HitPoints { get; }
	int Damages { get; }
	void DealDamage();
}
