public class HandSizeComponent : BaseComponent, IHandSizeComponent
{
	public int Size { get; protected set; }
	public int MaxSize { get; protected set; }

	public HandSizeComponent(int maxSize) : base() => MaxSize = maxSize;
}
