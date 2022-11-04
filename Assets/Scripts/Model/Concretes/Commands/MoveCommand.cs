public class MoveCommand : BaseCommand
{
	protected IBasicComponentProxy BasicComponentProxy;
	protected (string, IPlayer) TargetZone;

	public MoveCommand(IBasicComponentProxy basicComponentProxy, (string, IPlayer) targetZone, string commandType) : base(commandType)
	{
		BasicComponentProxy = basicComponentProxy;
		TargetZone = targetZone;
	}
	public override bool CanExecute() => BasicComponentProxy.Location != TargetZone;
	public override void Execute()
	{
		if (CanExecute())
		{
			BasicComponentProxy.MoveTo(TargetZone);
			base.Execute();
		}
	}
}
