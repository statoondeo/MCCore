public class DrawHandCommand : ICommand
{
	public string Type => CommandType.NONE;
	public bool Done { get; protected set; }

	protected int MaxHandSize;
	protected string PlayerName;
	protected IPlayer Player;
	protected IStackService StackService;
	protected IHandCountComponentProxy HandCountComponentProxy;

	public DrawHandCommand(string playerName) => PlayerName = playerName;

	public bool CanExecute() => true;

	public void Execute()
	{
		Player ??= ServiceLocator.Get<IPlayerService>().Get(PlayerName);
		MaxHandSize = MaxHandSize > 0 ? MaxHandSize : Player.Identity.GetComponent<IFaceContainerComponentProxy>().ActiveFace.Face.GetComponent<IHandSizeComponentProxy>().MaxSize;
		StackService ??= ServiceLocator.Get<IStackService>();
		HandCountComponentProxy ??= ServiceLocator.Get<IZoneService>().Get((Zones.HAND, Player)).GetComponent<IHandCountComponentProxy>();

		if (HandCountComponentProxy.Count() >=  MaxHandSize)
		{
			Done = true;
			return;
		}

		StackService.EnqueueCommand(new DrawCommand(Player));
	}
}
