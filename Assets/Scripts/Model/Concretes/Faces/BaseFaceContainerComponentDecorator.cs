using System.Collections.Generic;

public abstract class BaseFaceContainerComponentDecorator : BaseComponentDecorator<IFaceContainerComponent>, IFaceContainerComponentDecorator
{
	public virtual IFaceComponentProxy ActiveFace => Inner.ActiveFace;
	public virtual IDictionary<string, IFaceComponentProxy> Faces => Inner.Faces;

	protected BaseFaceContainerComponentDecorator(IActivable owner) : base(owner) { }

	public virtual bool CanFlipTo(string faceName) => Inner.CanFlipTo(faceName);
	public virtual void FlipTo(string faceName) => Inner.FlipTo(faceName);
	public virtual void FlipToNext() => Inner.FlipToNext();
	public virtual IFaceComponentProxy RegisterFace(IFaceComponentProxy face) => Inner.RegisterFace(face);
}
