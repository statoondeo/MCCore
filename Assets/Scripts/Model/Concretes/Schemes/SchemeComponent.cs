public class SchemeComponent : BaseComponent, ISchemeComponent
{
	public int Sch { get; protected set; }

	public SchemeComponent(int sch) : base() => Sch = sch;

	public void Scheme() { }
}
