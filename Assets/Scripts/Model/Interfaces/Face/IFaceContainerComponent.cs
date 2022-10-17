using System.Collections.Generic;

public interface IFaceContainerComponent : IComponent
{
	IFaceComponentProxy ActiveFace { get; }
	IDictionary<string, IFaceComponentProxy> Faces { get; }
	void FlipTo(string faceName);
	IFaceComponentProxy RegisterFace(IFaceComponentProxy face);
}
