public class EmptyDeckStateBasedEffect : IStateBasedEffect
{
	protected ITankComponentProxy ObservedTankComponentProxy;
	protected ITankComponentProxy TargetTankComponentProxy;
	protected IEntity TargetZoneEntity;
	protected IPlayer Player;
	protected string ObservedZone;
	protected string TargetZone;

	public EmptyDeckStateBasedEffect(IPlayer player, string observedZone, string targetZone)
	{
		Player = player;
		ObservedZone = observedZone;
		TargetZone = targetZone;
	}

	public bool Check()
	{
		ObservedTankComponentProxy ??= ServiceLocator.Get<IZoneService>().Get((ObservedZone, Player)).GetComponent<ITankComponentProxy>();
		if (0 < ObservedTankComponentProxy.Count) return (false);

		ServiceLocator.Get<IMessageService>().Raise((MessageType.None, Messages.EMPTY_DECK));
		TargetZoneEntity ??= ServiceLocator.Get<IZoneService>().Get((TargetZone, Player));
		TargetTankComponentProxy ??= TargetZoneEntity.GetComponent<ITankComponentProxy>();
		ObservedTankComponentProxy.Add(TargetTankComponentProxy.Get());
		TargetTankComponentProxy.Remove();
		TargetZoneEntity.GetComponent<IShuffleComponentProxy>().Shuffle();
		return (true);
	}
}
