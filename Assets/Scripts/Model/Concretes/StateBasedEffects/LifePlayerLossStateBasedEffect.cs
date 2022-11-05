public class LifePlayerLossStateBasedEffect : IStateBasedEffect
{
	protected IPlayer Player;
	protected ILifeComponentProxy LifeComponentProxy;

	public LifePlayerLossStateBasedEffect(IPlayer player) => Player = player;

	public bool Check()
	{
		if (null == Player.Identity) return (false);
		LifeComponentProxy ??= Player.Identity.GetActiveFaceComponent<ILifeComponentProxy>();
		if (LifeComponentProxy.Damages >= LifeComponentProxy.HitPoints)
		{
			ServiceLocator.Get<IMessageService>().Raise((MessageType.None, Messages.PLAYER_LIFE_LOOSE));
			return (true);
		}
		return (false);
	}
}
