using System;

public class GenericCommand : ICommand
{
	public string Type => CommandType.NONE;
	public bool Done { get; protected set; }

	protected Action Action;

	public GenericCommand(Action action) => Action = action;

	public bool CanExecute() => true;

	public void Execute()
	{
		Action.Invoke();
		Done = true;
	}
}
public class DrawHandCommand : ICommand
{
	public string Type => CommandType.NONE;
	public bool Done { get; protected set; }

	protected int MaxHandSize;
	protected IPlayer Player;
	protected IStackService StackService;
	protected IHandCountComponentProxy HandCountComponentProxy;

	public DrawHandCommand(IPlayer player) => Player = player;

	public bool CanExecute() => true;

	public void Execute()
	{
		MaxHandSize = MaxHandSize > 0 ? MaxHandSize : Player.Identity.GetComponent<IFaceContainerComponentProxy>().ActiveFace.Face.GetComponent<IHandSizeComponentProxy>().MaxSize;
		StackService ??= ServiceLocator.Get<IStackService>();
		HandCountComponentProxy ??= ServiceLocator.Get<IZoneService>().Get((Zones.HAND, Player)).GetComponent<IHandCountComponentProxy>();
		
		if (HandCountComponentProxy.Count() < MaxHandSize)
			StackService.EnqueueCommand(new DrawCommand(Player));
		else
			Done = true;
	}
}
