public class LifeComponent : BaseComponent, ILifeComponent
{
	public int HitPoints { get; protected set; }
	public int Damages { get; protected set; }

	public LifeComponent(int hitPoints) : base()
	{
		HitPoints = hitPoints;
		Damages = 0;
	}

	public void TakeDamage(int amount) { }
}
