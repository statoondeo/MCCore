using System.Collections.Generic;

public class FaceContainerComponentProxy : BaseComponentProxy<IFaceContainerComponent>, IFaceContainerComponentProxy
{
	public IFaceComponentProxy ActiveFace => Wrapped.ActiveFace;
	public IDictionary<string, IFaceComponentProxy> Faces => Wrapped.Faces;

	public FaceContainerComponentProxy() : base(new FaceContainerComponent()) { }

	public void FlipTo(string faceName) => Wrapped.FlipTo(faceName);
	public IFaceComponentProxy RegisterFace(IFaceComponentProxy face) => Wrapped.RegisterFace(face);

	public override string ToString() => ActiveFace.ToString();
}
