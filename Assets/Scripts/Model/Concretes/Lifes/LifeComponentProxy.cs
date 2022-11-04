using System.Text;

public class LifeComponentProxy : BaseComponentProxy<ILifeComponent>, ILifeComponentProxy
{
	public int HitPoints => Wrapped.HitPoints;
	public int Damages => Wrapped.Damages;

	public LifeComponentProxy(int hitPoints) : base(new LifeComponent(hitPoints)) { }

	public void TakeDamage(int amount) => Wrapped.TakeDamage(amount);

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t LifeComponentProxy");
		sb.AppendLine($"\t\t HitPoints={HitPoints}");
		sb.AppendLine($"\t\t Damages={Damages}");
		return (sb.ToString());
	}
}

