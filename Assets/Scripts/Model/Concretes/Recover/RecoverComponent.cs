public class RecoverComponent : BaseComponent, IRecoverComponent
{
	public int Rec { get; protected set; }

	public RecoverComponent(int rec) : base() => Rec = rec;

	public void Recover() { }
}
