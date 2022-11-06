public class StageComponent : BaseComponent, IStageComponent
{
	public string Stage { get; protected set; }

	public StageComponent(string stage) : base() => Stage = stage;
}
