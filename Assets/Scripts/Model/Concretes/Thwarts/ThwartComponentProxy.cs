using System.Text;

public class ThwartComponentProxy : BaseComponentProxy<IThwartComponent>, IThwartComponentProxy
{
	public int Thw => Wrapped.Thw;

	public ThwartComponentProxy(int thw) : base(new ThwartComponent(thw)) { }

	public void Thwart() => Wrapped.Thwart();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t ThwartComponentProxy");
		sb.AppendLine($"\t\t Thw={Thw}");
		return (sb.ToString());
	}
}

