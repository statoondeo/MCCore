public interface IFaceComponent : IComponent
{
	string Name { get; }
	IEntity Face { get; }
}
