public class FaceComponentProxy : BaseComponentProxy<IFaceComponent>, IFaceComponentProxy
{
	public string Name => Wrapped.Name;
	public IEntity Face => Wrapped.Face;

	public FaceComponentProxy(string name, IEntity face) : base(new FaceComponent(name, face)) { }

	public override string ToString() => Face.ToString();
}