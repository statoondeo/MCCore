using System.Collections.Generic;

public abstract class BaseFaceContainerComponentDecorator : BaseComponentDecorator<IFaceContainerComponent>, IFaceContainerComponentDecorator
{
	public IFaceComponentProxy ActiveFace => Inner.ActiveFace;
	public IDictionary<string, IFaceComponentProxy> Faces => Inner.Faces;

	protected BaseFaceContainerComponentDecorator(IActivable owner) : base(owner) { }

	public bool CanFlipTo(string faceName) => Inner.CanFlipTo(faceName);
	public void FlipTo(string faceName) => Inner.FlipTo(faceName);
	public IFaceComponentProxy RegisterFace(IFaceComponentProxy face) => Inner.RegisterFace(face);
}
