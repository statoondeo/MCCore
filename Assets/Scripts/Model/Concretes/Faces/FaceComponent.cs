public class FaceComponent : BaseComponent, IFaceComponent
{
	public string Name { get; protected set; }
	public IEntity Face { get; protected set; }

	public FaceComponent(string name, IEntity face)
	{
		Name = name;
		Face = face;
	}
}
