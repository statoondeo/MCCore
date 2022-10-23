public class HandSizeComponent : BaseComponent, IHandSizeComponent
{
	public int Size { get; protected set; }

	public HandSizeComponent(int size) : base() => Size = size;
}
