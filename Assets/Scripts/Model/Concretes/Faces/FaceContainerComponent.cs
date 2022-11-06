using System.Collections.Generic;
using System.Linq;

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
	public void FlipToNext()
	{
		IList<string> keyList = Faces.Keys.ToList();
		int currentKeyIndex = keyList.IndexOf(ActiveFace.Name);
		if (currentKeyIndex < (keyList.Count - 1)) FlipTo(keyList[currentKeyIndex + 1]);
	}
	public IFaceComponentProxy RegisterFace(IFaceComponentProxy face)
	{
		Faces.Add(face.Name, face);
		if (null == ActiveFace) ActiveFace = face;
		return (face);
	}
}
