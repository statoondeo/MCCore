using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackTester : MonoBehaviour
{
	[SerializeField] protected ScriptableEntity Hero;
	[SerializeField] protected ScriptableEntity Upgrade;

	void Start()
	{
		ServiceLocator.Register<ICardTypeService>(new CardTypeService()).Initialize();
		ServiceLocator.Register<ITraitService>(new TraitService()).Initialize();
		ServiceLocator.Register<IMessageService>(new MessageService()).Initialize();

		IEntityService entityService = ServiceLocator.Register<IEntityService>(new EntityService()).Initialize() as IEntityService;

		IEntity captainMarvel = entityService.Add(Hero.Create());
		captainMarvel.GetComponent<IBasicComponentProxy>().MoveTo("BATTLEFIELD");
		Debug.Log(captainMarvel);

		IFaceContainerComponentProxy faceContainer = captainMarvel.GetComponent<IFaceContainerComponentProxy>();
		IPlayableContainerComponent playableContainer = faceContainer.ActiveFace.Face.GetComponent<IPlayableContainerComponent>();
		playableContainer.Playables.First().Value.Play();

		IList<IEntity> entities = ServiceLocator.Get<IEntityService>().Get();
		for (int i = 0; i < entities.Count; i++)
		{
			IBasicComponentProxy basicComponent = entities[i].GetComponent<IBasicComponentProxy>();
			if ("STACK".Equals(basicComponent.Location))
				entities[i].GetComponent<IResolvableComponentProxy>().Resolve();
		}

		faceContainer.FlipTo(CardTypes.HERO);
		Debug.Log(captainMarvel);

		playableContainer = faceContainer.ActiveFace.Face.GetComponent<IPlayableContainerComponent>();
		playableContainer.Playables.First().Value.Play();

		entities = ServiceLocator.Get<IEntityService>().Get();
		for (int i = 0; i < entities.Count; i++)
		{
			IBasicComponentProxy basicComponent = entities[i].GetComponent<IBasicComponentProxy>();
			if ("STACK".Equals(basicComponent.Location))
				entities[i].GetComponent<IResolvableComponentProxy>().Resolve();
		}
	}
}
