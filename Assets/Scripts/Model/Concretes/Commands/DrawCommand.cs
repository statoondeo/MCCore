using System.Collections.Generic;
using UnityEngine;

public class DrawCommand : BaseCommand
{
	public DrawCommand() : base(CommandType.DRAW) { }

	public override void Execute()
	{
		IList<IEntity> cards = ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_DECK).GetComponent<ITankComponentProxy>().Get();
		cards[cards.Count - 1].GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.RECTO);
		cards[cards.Count - 1].GetComponent<IBasicComponentProxy>().MoveTo(Zones.HAND);
		base.Execute();
	}
}
