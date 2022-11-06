using System.Collections.Generic;

public class CharacterDefeatedStateBasedEffect : IStateBasedEffect
{
	public CharacterDefeatedStateBasedEffect() { }

	public bool Check()
	{
		IMessageService messageService = ServiceLocator.Get<IMessageService>();
		IList<IEntity> characters = ServiceLocator.Get<IZoneService>().Get((Zones.BATTLEFIELD, null)).GetComponent<ITankComponentProxy>().Get(new CardTypesFilterStrategy(CardTypes.MINION, CardTypes.ALLY));
		bool check = false;
		for (int i = 0; i < characters.Count; i++)
		{
			ILifeComponentProxy lifeComponentProxy = characters[i].GetActiveFaceComponent<ILifeComponentProxy>();
			if ((null != lifeComponentProxy) && (lifeComponentProxy.Damages >= lifeComponentProxy.HitPoints))
			{
				messageService.Raise((MessageType.None, Messages.CHARACTER_DEFEATED));
				characters[i].GetComponent<IBasicComponentProxy>().MoveTo(Zones.DISCARD);
				check = true;
			}
		}
		return (check);
	}
}
