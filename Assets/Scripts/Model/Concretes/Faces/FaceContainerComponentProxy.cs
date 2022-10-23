using System.Collections.Generic;
using System.Text;

public class FaceContainerComponentProxy : BaseComponentProxy<IFaceContainerComponent>, IFaceContainerComponentProxy
{
	public IFaceComponentProxy ActiveFace => Wrapped.ActiveFace;
	public IDictionary<string, IFaceComponentProxy> Faces => Wrapped.Faces;
	public IDictionary<string, ICommand> FlipCommands {get; protected set;}

	public FaceContainerComponentProxy() : base(new FaceContainerComponent()) => FlipCommands = new	Dictionary<string, ICommand>();

	public bool CanFlipTo(string faceName) => Wrapped.CanFlipTo(faceName);
	public void FlipTo(string faceName) => Wrapped.FlipTo(faceName);
	public IFaceComponentProxy RegisterFace(IFaceComponentProxy face)
	{
		FlipCommands.Add(face.Name, new FlipCommand(this, face.Name));
		return (Wrapped.RegisterFace(face));
	}

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t FaceContainerComponentProxy");
		sb.AppendLine($"\t\t Faces={Faces.Count}");
		sb.AppendLine($"\t\t Active Face=");
		sb.Append(ActiveFace);
		return (sb.ToString());
	}
}
