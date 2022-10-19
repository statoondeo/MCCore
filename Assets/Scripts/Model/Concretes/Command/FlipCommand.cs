public class FlipCommand : BaseCommand
{
	protected IFaceContainerComponentProxy FaceContainerContainerComponent;
	protected string TargetFaceName;

	public FlipCommand(IFaceContainerComponentProxy faceContainerContainerComponent, string targetFaceName) : base(CommandType.FLIP)
	{
		FaceContainerContainerComponent = faceContainerContainerComponent;
		TargetFaceName = targetFaceName;
	}
	public override bool CanExecute() => FaceContainerContainerComponent.ActiveFace != FaceContainerContainerComponent.Faces[TargetFaceName];
	public override void Execute()
	{
		if (CanExecute())
		{
			FaceContainerContainerComponent.FlipTo(TargetFaceName);
			base.Execute();
		}
	}
}
