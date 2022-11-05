public class PlayerService : IndexedTankService<IPlayer, string>, IPlayerService
{
	public void Initialize(params IPlayer[] players)
	{
		IStateBasedEffectService stateBasedEffectService = ServiceLocator.Get<IStateBasedEffectService>();
		if ((null == players) || (players.Length == 0)) return;
		for (int i = 0; i < players.Length; i++)
		{
			Add(players[i].Name, players[i]);
			stateBasedEffectService.Register(new LifePlayerLossStateBasedEffect(players[i]));
		}
	}
}
