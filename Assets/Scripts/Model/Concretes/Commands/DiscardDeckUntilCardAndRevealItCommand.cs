using System;

public class DiscardDeckUntilCardAndRevealItCommand : ICommand
{
	public string Type => CommandType.NONE;
	public bool Done { get; protected set; }

	protected (MessageType, string)? EmptyDeckRegistered;
	protected bool EndCommand;
	protected IPlayer Player;
	protected ICardType CardType;
	protected IEntity Card;
	protected IStackService StackService;
	protected ITankComponentProxy DeckZone;
	protected Action ExecuteMode;

	public DiscardDeckUntilCardAndRevealItCommand(IPlayer player, ICardType cardType)
	{
		Player = player;
		CardType = cardType;
		EndCommand = false;
		EmptyDeckRegistered = null;
		Done = false;
		ExecuteMode = ExecuteDiscardMode;
	}

	public bool CanExecute() => true;
	public void Execute()
	{
		// Stop command if deck is empty
		EmptyDeckRegistered ??= ServiceLocator.Get<IMessageService>().Register((MessageType.None, Messages.EMPTY_DECK), DeckIsEmpty);
		DeckZone ??= ServiceLocator.Get<IZoneService>().Get((Zones.DECK, Player)).GetComponent<ITankComponentProxy>();
		StackService ??= ServiceLocator.Get<IStackService>();

		ExecuteMode.Invoke();

		if (EndCommand)
		{
			Done = true;
			ServiceLocator.Get<IMessageService>().UnRegister((MessageType.None, Messages.EMPTY_DECK), DeckIsEmpty);
			return;
		}
	}
	protected void ExecuteDiscardMode()
	{
		if (DeckZone.Count > 0)
		{
			Card = DeckZone.Get(DeckZone.Count - 1);
			StackService.EnqueueCommand(new DiscardCommand(Card));
			StackService.EnqueueCommand(new FlipCommand(Card.GetComponent<IFaceContainerComponentProxy>(), Faces.RECTO));
			ExecuteMode = ExecuteRevealMode;
		}
		else
		{
			EndCommand = true;
		}
	}
	protected void ExecuteRevealMode()
	{
		ICardComponentProxy cardComponent = Card.GetActiveFaceComponent<ICardComponentProxy>();
		EndCommand = null != cardComponent && cardComponent.IsCardType(CardType);
		ExecuteMode = ExecuteDiscardMode;
		if (EndCommand) StackService.EnqueueCommand(new PutOntoTheBattlefieldCommand(Card));
	}
	protected void DeckIsEmpty(MessageArg arg) => EndCommand = true;
}
