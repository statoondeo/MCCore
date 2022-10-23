public class StageComponent : BaseComponent, IStageComponent
{
	public int Stage { get; protected set; }

	public StageComponent(int stage) : base() => Stage = stage;
}
