using System.Collections.Generic;

public class FaceContainerComponent : BaseComponent, IFaceContainerComponent
{
	public IFaceComponentProxy ActiveFace { get; protected set; }
	public IDictionary<string, IFaceComponentProxy> Faces { get; protected set; }

	public FaceContainerComponent() : base() => Faces = new Dictionary<string, IFaceComponentProxy>();

	public bool CanFlipTo(string faceName) => Faces.ContainsKey(faceName) && ActiveFace != Faces[faceName];
	public void FlipTo(string faceName)
	{
		if (!CanFlipTo(faceName)) return;
		ActiveFace = Faces[faceName];
	}
	public IFaceComponentProxy RegisterFace(IFaceComponentProxy face)
	{
		Faces.Add(face.Name, face);
		if (null == ActiveFace) ActiveFace = face;
		return (face);
	}
}
