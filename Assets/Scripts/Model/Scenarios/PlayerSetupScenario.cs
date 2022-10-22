using System;
using System.Collections.Generic;
using System.Linq;
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
			for (int i = 0; i < deckList.Count; i++)
			{
				IEntity card = entityService.Add(deckList[i]);
				card.GetComponent<IBasicComponentProxy>().MoveTo(Zones.PLAYER_DECK);
				card.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.VERSO);
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Select Identity
			IEntity hero = GetFirst(IdentityFilter, ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_DECK).GetComponent<ITankComponentProxy>().Get());

			// Flip to Alter-ego face
			hero.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.ALTER_EGO);

			// Move to Battlefield
			IBasicComponentProxy basicComponent = hero.GetComponent<IBasicComponentProxy>();
			ServiceLocator.Get<IStackService>().EnqueueCommand(basicComponent.MoveCommands[Zones.BATTLEFIELD]);
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Set aside obligations
			IList<IEntity> cards = GetAll(ObligationFilter, ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_DECK).GetComponent<ITankComponentProxy>().Get());
			for (int i = 0; i < cards.Count; i++)
			{
				IBasicComponentProxy basicComponent = cards[i].GetComponent<IBasicComponentProxy>();
				ServiceLocator.Get<IStackService>().EnqueueCommand(basicComponent.MoveCommands[Zones.PLAYER_EXIL]);
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Set aside nemesis cards
			IList<IEntity> cards = GetAll(NemesisFilter, ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_DECK).GetComponent<ITankComponentProxy>().Get());
			for (int i = 0; i < cards.Count; i++)
			{
				IBasicComponentProxy basicComponent = cards[i].GetComponent<IBasicComponentProxy>();
				ServiceLocator.Get<IStackService>().EnqueueCommand(basicComponent.MoveCommands[Zones.PLAYER_EXIL]);
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Shuffle deck
			ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_DECK).GetComponent<IShuffleComponentProxy>().Shuffle();
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Unmute messages
			ServiceLocator.Get<IMessageService>().UnMute();
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Display cards
			IList<IEntity> cards = ServiceLocator.Get<IEntityService>().Get();
			for (int i = 0; i < cards.Count; i++) Debug.Log(cards[i]);
		}));
	}

	public bool IdentityFilter(IEntity card)
	{
		ICardType alterEgoCardType = ServiceLocator.Get<ICardTypeService>().Get(CardTypes.ALTER_EGO);
		ICardType heroCardType = ServiceLocator.Get<ICardTypeService>().Get(CardTypes.HERO);

		ICardComponentProxy cardComponentProxy = card.GetComponent<ICardComponentProxy>();
		if (null == cardComponentProxy) return (false);

		return (cardComponentProxy.IsOneOfCardType(alterEgoCardType, heroCardType));
	}
	public bool NemesisFilter(IEntity card)
	{
		IClassification nemesisClassification = ServiceLocator.Get<IClassificationService>().Get(Classifications.NEMESIS);

		ICardComponentProxy cardComponentProxy = card.GetComponent<ICardComponentProxy>();
		if (null == cardComponentProxy) return (false);

		return (cardComponentProxy.IsClassification(nemesisClassification));
	}
	public bool ObligationFilter(IEntity card)
	{
		ICardType obligationCardType = ServiceLocator.Get<ICardTypeService>().Get(CardTypes.OBLIGATION);

		ICardComponentProxy cardComponentProxy = card.GetComponent<ICardComponentProxy>();
		if (null == cardComponentProxy) return (false);

		return (cardComponentProxy.IsCardType(obligationCardType));
	}
	public static IEntity GetFirst(Func<IEntity, bool> filter, IList<IEntity> dataSet)
	{
		for (int i = 0; i < dataSet.Count; i++)
		{
			IFaceContainerComponentProxy faceContainer = dataSet[i].GetComponent<IFaceContainerComponentProxy>();
			IList<string> faces = faceContainer.Faces.Keys.ToList();
			for (int j = 0; j < faces.Count; j++)
				if (filter.Invoke(faceContainer.Faces[faces[j]].Face)) return (dataSet[i]);
		}

		return (null);
	}
	public static IList<IEntity> GetAll(Func<IEntity, bool> filter, IList<IEntity> dataSet)
	{
		IList<IEntity> filteredDataSet = new List<IEntity>();
		for (int i = 0; i < dataSet.Count; i++)
		{
			IFaceContainerComponentProxy faceContainer = dataSet[i].GetComponent<IFaceContainerComponentProxy>();
			IList<string> faces = faceContainer.Faces.Keys.ToList();
			for (int j = 0; j < faces.Count; j++)
				if (filter.Invoke(faceContainer.Faces[faces[j]].Face)) filteredDataSet.Add(dataSet[i]);
		}

		return (filteredDataSet);
	}
}
