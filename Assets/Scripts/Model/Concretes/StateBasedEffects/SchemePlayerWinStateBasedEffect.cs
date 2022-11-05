using System.Linq;

public class SchemePlayerWinStateBasedEffect : IStateBasedEffect
{
	protected IPlayer Player;
	protected IEntity MainScheme;

	public SchemePlayerWinStateBasedEffect(IPlayer player) => Player = player;

	public bool Check()
	{
		IMessageService messageService = ServiceLocator.Get<IMessageService>();
		MainScheme ??= ServiceLocator.Get<IZoneService>().Get((Zones.BATTLEFIELD, null)).GetComponent<ITankComponentProxy>().GetFirst(new CardTypesFilterStrategy(CardTypes.MAIN_SCHEME));
		IThresholdAccelerationComponentProxy thresholdAccelerationComponent = MainScheme.GetActiveFaceComponent<IThresholdAccelerationComponentProxy>();
		if (null == thresholdAccelerationComponent) return (false);

		IFaceContainerComponentProxy faceContainerComponent = MainScheme.GetComponent<IFaceContainerComponentProxy>();
		string lastFaveKey = faceContainerComponent.Faces.Keys.ToList()[faceContainerComponent.Faces.Keys.Count - 1];
		IThreatComponentProxy threatComponent = MainScheme.GetActiveFaceComponent<IThreatComponentProxy>();

		if ((faceContainerComponent.Faces[lastFaveKey] == faceContainerComponent.ActiveFace)
			&& (threatComponent.Threat >= thresholdAccelerationComponent.Threshold))
		{
			messageService.Raise((MessageType.None, Messages.MAIN_SCHEME_COMPLETED));
			return (true);
		}

		if (threatComponent.Threat >= thresholdAccelerationComponent.Threshold)
		{
			//faceContainerComponent.FlipTo();
			messageService.Raise((MessageType.None, Messages.MAIN_SCHEME_NEXT_STAGE));
			return (true);
		}
		return (false);
	}
}
