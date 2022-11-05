public class SearhEncounterCardInDeckDiscardAndRevealItThenShuffleCommand : ICommand
{
	protected IPlayer Player;
	protected string SearchedCardId;
	protected string[] SearchedZoneId;

	public SearhEncounterCardInDeckDiscardAndRevealItThenShuffleCommand(string searchedCardId, IPlayer player)
	{
		SearchedCardId = searchedCardId;
		SearchedZoneId = new string[] { Zones.DISCARD, Zones.DECK };
		Player = player;
	}

	public string Type => throw new System.NotImplementedException();
	public bool Done { get; protected set; }
	public bool CanExecute() => true;
	public void Execute()
	{
		IZoneService zoneService = ServiceLocator.Get<IZoneService>();
		IFilterStrategy filterStrategy = new SpecificCardFilterStrategy(SearchedCardId);
		IEntity cardFound = null;
		for (int i = 0; i < SearchedZoneId.Length; i++)
		{
			cardFound = zoneService.Get((SearchedZoneId[i], Player)).GetComponent<ITankComponentProxy>().GetFirst(filterStrategy);
			if (null != cardFound) break;
		}
		if (null != cardFound)
		{
			cardFound.GetComponent<IBasicComponentProxy>().MoveTo((Zones.BATTLEFIELD, null));
			IFaceContainerComponentProxy faceContainer = cardFound.GetComponent<IFaceContainerComponentProxy>();
			faceContainer.FlipTo(Faces.RECTO);
			faceContainer.ActiveFace.Face.GetComponent<IWhenRevealedComponentProxy>()?.WhenRevealed();
		}
		zoneService.Get((Zones.DECK, Player)).GetComponent<IShuffleComponentProxy>().Shuffle();
	}
}
