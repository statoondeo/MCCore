using System.Collections.Generic;
using UnityEngine;

public class FaceContainerComponent : BaseComponent, IFaceContainerComponent
{
	public IFaceComponentProxy ActiveFace { get; protected set; }
	public IDictionary<string, IFaceComponentProxy> Faces { get; protected set; }

	public FaceContainerComponent() : base() => Faces = new Dictionary<string, IFaceComponentProxy>();

	protected void ChangeFace(string faceName) => ActiveFace = Faces[faceName];

	public bool CanFlipTo(string faceName) => ActiveFace != Faces[faceName];
	public void FlipTo(string faceName)
	{
		if (!CanFlipTo(faceName)) return;
		Debug.Log("Flip");
		ActiveFace = Faces[faceName];
	}
	public IFaceComponentProxy RegisterFace(IFaceComponentProxy face)
	{
		Faces.Add(face.Name, face);
		if (null == ActiveFace) ActiveFace = face;
		return (face);
	}
}
