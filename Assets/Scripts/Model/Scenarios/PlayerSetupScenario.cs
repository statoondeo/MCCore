using System.Collections.Generic;
using UnityEngine;

public class PlayerSetupScenario : BaseScenario
{
	public PlayerSetupScenario(ScriptableDeck deck) : base()
	{
		Commands.Add(new GenericCommand(() =>
		{
			// Mute messages
			ServiceLocator.Get<IMessageService>().Mute();
		})); 
		Commands.Add(new GenericCommand(() =>
		{
			// Create player deck
			IList<IEntity> deckList = deck.Create();
			IEntityService entityService = ServiceLocator.Get<IEntityService>();
			for (int i = 0; i < deckList.Count; i++) entityService.Add(deckList[i]);
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Select Identity
			IEntity hero = null;
			IList<IEntity> entities = ServiceLocator.Get<IEntityService>().Get();
			ICardType alterEgoCardType = ServiceLocator.Get<ICardTypeService>().Get(CardTypes.ALTER_EGO);
			ICardType heroCardType = ServiceLocator.Get<ICardTypeService>().Get(CardTypes.HERO);
			for (int i = 0; i < entities.Count; i++)
			{
				IEntity currentEntity;
				IFaceContainerComponentProxy faceContainer = entities[i].GetComponent<IFaceContainerComponentProxy>();
				currentEntity = null == faceContainer ? entities[i] : faceContainer.ActiveFace.Face;
				ICardComponentProxy cardComponentProxy = currentEntity.GetComponent<ICardComponentProxy>();
				if (cardComponentProxy.IsOneOfCardType(alterEgoCardType, heroCardType))
				{
					hero = entities[i];
					break;
				}
			}

			// Move to Battlefield
			IBasicComponentProxy basicComponent = hero.GetComponent<IBasicComponentProxy>();
			ServiceLocator.Get<IStackService>().EnqueueCommand(basicComponent.MoveCommands[Zones.BATTLEFIELD]);

			// Flip to Alter-ego face
			IFaceContainerComponentProxy faceContainerComponentProxy = hero.GetComponent<IFaceContainerComponentProxy>();
			faceContainerComponentProxy.FlipTo(CardTypes.ALTER_EGO);
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Set aside obligations
			ICardType obligationCardType = ServiceLocator.Get<ICardTypeService>().Get(CardTypes.OBLIGATION);
			IList<IEntity> entities = ServiceLocator.Get<IEntityService>().Get();
			for (int i = 0; i < entities.Count; i++)
			{
				IEntity currentEntity;
				IFaceContainerComponentProxy faceContainer = entities[i].GetComponent<IFaceContainerComponentProxy>();
				currentEntity = null == faceContainer ? entities[i] : faceContainer.ActiveFace.Face;
				ICardComponentProxy cardComponentProxy = currentEntity.GetComponent<ICardComponentProxy>();
				if (cardComponentProxy.IsCardType(obligationCardType))
				{
					IBasicComponentProxy basicComponent = entities[i].GetComponent<IBasicComponentProxy>();
					ServiceLocator.Get<IStackService>().EnqueueCommand(basicComponent.MoveCommands[Zones.PLAYER_EXIL]);
				}
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Set aside nemesis cards
			IClassification nemesisClassification = ServiceLocator.Get<IClassificationService>().Get(Classifications.NEMESIS);
			IList<IEntity> entities = ServiceLocator.Get<IEntityService>().Get();
			for (int i = 0; i < entities.Count; i++)
			{
				IEntity currentEntity;
				IFaceContainerComponentProxy faceContainer = entities[i].GetComponent<IFaceContainerComponentProxy>();
				currentEntity = null == faceContainer ? entities[i] : faceContainer.ActiveFace.Face;
				ICardComponentProxy cardComponentProxy = currentEntity.GetComponent<ICardComponentProxy>();
				if (cardComponentProxy.IsClassification(nemesisClassification))
				{
					IBasicComponentProxy basicComponent = entities[i].GetComponent<IBasicComponentProxy>();
					ServiceLocator.Get<IStackService>().EnqueueCommand(basicComponent.MoveCommands[Zones.PLAYER_EXIL]);
				}
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Deck feeding
			IList<IEntity> entities = ServiceLocator.Get<IEntityService>().Get();
			for (int i = 0; i < entities.Count; i++)
			{
				IBasicComponentProxy basicComponentProxy = entities[i].GetComponent<IBasicComponentProxy>();
				if (string.IsNullOrWhiteSpace(basicComponentProxy.Location)) basicComponentProxy.MoveTo(Zones.PLAYER_DECK);
			}

			// Shuffle deck
			IEntity playerDeck = ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_DECK);
			ITankComponentProxy tankComponentProxy = playerDeck.GetComponent<ITankComponentProxy>();
			IList<IEntity> cards = tankComponentProxy.Get();
			for (int i = 0; i < cards.Count; i++)
			{
				int j = Random.Range(i, cards.Count);
				IBasicComponentProxy cardiBasicComponentProxy = cards[i].GetComponent<IBasicComponentProxy>();
				IBasicComponentProxy cardjBasicComponentProxy = cards[j].GetComponent<IBasicComponentProxy>();
				cardiBasicComponentProxy.SetOrder(j);
				cardjBasicComponentProxy.SetOrder(i);
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Unmute messages
			ServiceLocator.Get<IMessageService>().UnMute();
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Deck feeding
			IList<IEntity> entities = ServiceLocator.Get<IEntityService>().Get();
			for (int i = 0; i < entities.Count; i++) Debug.Log(entities[i]);
		}));
	}
}
