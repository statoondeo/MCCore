using System.Collections.Generic;
using UnityEngine;

public class PlayerSetupScenario : BaseScenario
{
	public PlayerSetupScenario(ScriptableDeck[] deck) : base()
	{
		Commands.Add(new GenericCommand(() =>
		{
			// Mute messages
			ServiceLocator.Get<IMessageService>().Mute();
		})); 
		Commands.Add(new GenericCommand(() =>
		{
			// Create player
			IPlayer player = ServiceLocator.Get<IPlayerService>().Add("Statoondeo", new Player("Statoondeo"));

			// Create player deck
			List<IEntity> deckList = new();
			for (int i = 0; i < deck.Length; i++) deckList.AddRange(deck[i].Create());

			// Deck feeding
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
			IEntity hero = Filters.GetFirst(Filters.IdentityFilter, ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_DECK).GetComponent<ITankComponentProxy>().Get());
			ServiceLocator.Get<IPlayerService>().Get("Statoondeo").SetIdentity(hero);

			// Flip to Alter-ego face
			hero.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.ALTER_EGO);

			// Move to Battlefield
			IBasicComponentProxy basicComponent = hero.GetComponent<IBasicComponentProxy>();
			basicComponent.MoveTo(Zones.BATTLEFIELD);
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Set aside obligations
			IList<IEntity> cards = Filters.GetAll(Filters.ObligationFilter, ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_DECK).GetComponent<ITankComponentProxy>().Get());
			for (int i = 0; i < cards.Count; i++)
			{
				IBasicComponentProxy basicComponent = cards[i].GetComponent<IBasicComponentProxy>();
				basicComponent.MoveTo(Zones.PLAYER_EXIL);
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Set aside nemesis cards
			IList<IEntity> cards = Filters.GetAll(Filters.NemesisFilter, ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_DECK).GetComponent<ITankComponentProxy>().Get());
			for (int i = 0; i < cards.Count; i++)
			{
				IBasicComponentProxy basicComponent = cards[i].GetComponent<IBasicComponentProxy>();
				basicComponent.MoveTo(Zones.PLAYER_EXIL);
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Shuffle deck
			ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_DECK).GetComponent<IShuffleComponentProxy>().Shuffle();

		})); Commands.Add(new GenericCommand(() =>
		{
			// Draw hand
			int handSize = ServiceLocator.Get<IPlayerService>().Get("Statoondeo").Identity.GetComponent<IFaceContainerComponentProxy>().ActiveFace.Face.GetComponent<IHandSizeComponentProxy>().Size;
			IStackService stackService = ServiceLocator.Get<IStackService>();
			for (int i = 0; i < handSize; i++) stackService.EnqueueCommand(new DrawCommand());
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Unmute messages
			ServiceLocator.Get<IMessageService>().UnMute();
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Display cards in hand
			IList<IEntity> cards = ServiceLocator.Get<IZoneService>().Get(Zones.HAND).GetComponent<ITankComponentProxy>().Get();
			for (int i = 0; i < cards.Count; i++) Debug.Log(cards[i]);
		}));
	}
}
