public class PlayerLossStateBasedEffect : IStateBasedEffect
{
	protected IPlayer Player;
	protected ILifeComponentProxy LifeComponentProxy;

	public PlayerLossStateBasedEffect(IPlayer player) => Player = player;

	public bool Check()
	{
		if (null == Player.Identity) return (false);
		LifeComponentProxy ??= Player.Identity.GetComponent<ILifeComponentProxy>();
		LifeComponentProxy ??= Player.Identity.GetComponent<IFaceContainerComponentProxy>().ActiveFace.Face.GetComponent<ILifeComponentProxy>();
		return (LifeComponentProxy.Damages >= LifeComponentProxy.HitPoints);
	}
}