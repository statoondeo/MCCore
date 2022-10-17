using System.Collections.Generic;

public class FaceContainerComponent : BaseComponent, IFaceContainerComponent
{
	public IFaceComponentProxy ActiveFace { get; protected set; }
	public IDictionary<string, IFaceComponentProxy> Faces { get; protected set; }

	public FaceContainerComponent() : base() => Faces = new Dictionary<string, IFaceComponentProxy>();

	protected void ChangeFace(string faceName) => ActiveFace = Faces[faceName];

	public void FlipTo(string faceName)
	{
		if (ActiveFace == Faces[faceName]) return;
		ICommand flipCommand = new ContainerCommand(new FlipCommand(ChangeFace, faceName));
		while(!flipCommand.Done) flipCommand.Execute();
	}
	public IFaceComponentProxy RegisterFace(IFaceComponentProxy face)
	{
		Faces.Add(face.Name, face);
		if (null == ActiveFace) ActiveFace = face;
		return (face);
	}
}
