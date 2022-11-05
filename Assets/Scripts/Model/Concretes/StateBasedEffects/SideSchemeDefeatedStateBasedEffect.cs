using System.Collections.Generic;

public class SideSchemeDefeatedStateBasedEffect : IStateBasedEffect
{
	public SideSchemeDefeatedStateBasedEffect() { }

	public bool Check()
	{
		IMessageService messageService = ServiceLocator.Get<IMessageService>();
		IList<IEntity> items = ServiceLocator.Get<IZoneService>().Get((Zones.BATTLEFIELD, null)).GetComponent<ITankComponentProxy>().Get(new CardTypesFilterStrategy(CardTypes.SIDE_SCHEME));
		bool check = false;
		for (int i = 0; i < items.Count; i++)
		{
			IThreatComponentProxy component = items[i].GetActiveFaceComponent<IThreatComponentProxy>();
			if (component.Threat <= 0)
			{
				messageService.Raise((MessageType.None, Messages.SIDE_SCHEME_DEFEATED));
				items[i].GetComponent<IBasicComponentProxy>().MoveTo(Zones.DISCARD);
				check = true;
			}
		}
		return (check);
	}
}