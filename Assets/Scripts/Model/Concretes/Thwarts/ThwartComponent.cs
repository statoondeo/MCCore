public class ThwartComponent : BaseComponent, IThwartComponent
{
	public int Thw { get; protected set; }

	public ThwartComponent(int thw) : base() => Thw = thw;

	public void Thwart() { }
}
