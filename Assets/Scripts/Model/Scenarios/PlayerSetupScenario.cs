using System.Collections.Generic;
using UnityEngine;

public class PlayerSetupScenario : BaseScenario
{
	public PlayerSetupScenario(ScriptableDeck[] deck, ScriptableDeck[] villainDeck, string playerName) : base()
	{
		Commands.Add(new GenericCommand(() =>
		{
			// Mute messages
			ServiceLocator.Get<IMessageService>().Mute();
		}));

		#region Player Setup

		Commands.Add(new GenericCommand(() =>
		{
			// Create player
			IPlayer player = ServiceLocator.Get<IPlayerService>().Add(playerName, new Player(playerName));

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
			ServiceLocator.Get<IPlayerService>().Get(playerName).SetIdentity(hero);

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

		})); 
		Commands.Add(new GenericCommand(() =>
		{
			// Draw hand
			int handSize = ServiceLocator.Get<IPlayerService>().Get(playerName).Identity.GetComponent<IFaceContainerComponentProxy>().ActiveFace.Face.GetComponent<IHandSizeComponentProxy>().Size;
			IStackService stackService = ServiceLocator.Get<IStackService>();
			for (int i = 0; i < handSize; i++) stackService.EnqueueCommand(new DrawCommand());
		}));

		#endregion

		#region Villain Setup

		Commands.Add(new GenericCommand(() =>
		{
			// Create player
			ServiceLocator.Get<IPlayerService>().Add("VILLAIN", new Player("VILLAIN"));

			// Create player deck
			List<IEntity> deckList = new();
			for (int i = 0; i < villainDeck.Length; i++) deckList.AddRange(villainDeck[i].Create());

			// Deck feeding
			IEntityService entityService = ServiceLocator.Get<IEntityService>();
			for (int i = 0; i < deckList.Count; i++)
			{
				IEntity card = entityService.Add(deckList[i]);
				card.GetComponent<IBasicComponentProxy>().MoveTo(Zones.VILLAIN_DECK);
				card.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.VERSO);
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Select Identity
			IEntity villain = Filters.GetFirst(Filters.VillainFilter, ServiceLocator.Get<IZoneService>().Get(Zones.VILLAIN_DECK).GetComponent<ITankComponentProxy>().Get());
			ServiceLocator.Get<IPlayerService>().Get("VILLAIN").SetIdentity(villain);

			// Flip to Alter-ego face
			villain.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.RECTO);

			// Move to Battlefield
			IBasicComponentProxy basicComponent = villain.GetComponent<IBasicComponentProxy>();
			basicComponent.MoveTo(Zones.BATTLEFIELD);
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Shuffle deck
			ServiceLocator.Get<IZoneService>().Get(Zones.VILLAIN_DECK).GetComponent<IShuffleComponentProxy>().Shuffle();

		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Main Scheme Setup
			IList<IEntity> mainSchemes = Filters.GetAll(Filters.MainSchemeFilter, ServiceLocator.Get<IZoneService>().Get(Zones.VILLAIN_DECK).GetComponent<ITankComponentProxy>().Get());
			for (int i = 0; i < mainSchemes.Count; i++)
			{
				ISetupComponentProxy setupComponentProxy = mainSchemes[i].GetComponent<ISetupComponentProxy>();
				setupComponentProxy?.Setup();
			}
		})); 
		Commands.Add(new GenericCommand(() =>
		{
			// Battlefield Encounter cards WhenRevealed
			IList<IEntity> cards = Filters.GetAll(Filters.EncounterFilter, ServiceLocator.Get<IZoneService>().Get(Zones.BATTLEFIELD).GetComponent<ITankComponentProxy>().Get());
			for (int i = 0; i < cards.Count; i++)
			{
				IWhenRevealedComponentProxy setupComponentProxy = cards[i].GetComponent<IWhenRevealedComponentProxy>();
				setupComponentProxy?.WhenRevealed();
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Move player obligations into villain deck
			IList<IEntity> cards = Filters.GetAll(Filters.ObligationFilter, ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_EXIL).GetComponent<ITankComponentProxy>().Get());
			for (int i = 0; i < cards.Count; i++)
			{
				IBasicComponentProxy basicComponent = cards[i].GetComponent<IBasicComponentProxy>();
				basicComponent.MoveTo(Zones.VILLAIN_DECK);
			}

			// Shuffle deck
			ServiceLocator.Get<IZoneService>().Get(Zones.VILLAIN_DECK).GetComponent<IShuffleComponentProxy>().Shuffle();
		}));

		#endregion

		#region Player Setup end

		Commands.Add(new GenericCommand(() =>
		{
			// Mulligan
		})); 
		Commands.Add(new GenericCommand(() =>
		{
			// Hero Setup
			IEntity identity = Filters.GetFirst(Filters.IdentityFilter, ServiceLocator.Get<IZoneService>().Get(Zones.BATTLEFIELD).GetComponent<ITankComponentProxy>().Get());
			ISetupComponentProxy setupComponentProxy = identity.GetComponent<ISetupComponentProxy>();
			setupComponentProxy?.Setup();
		}));

		#endregion

		Commands.Add(new GenericCommand(() =>
		{
			// Unmute messages
			ServiceLocator.Get<IMessageService>().UnMute();
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Display cards in hand
			Debug.Log(ServiceLocator.Get<IZoneService>().Get(Zones.HAND));
		})); 
		Commands.Add(new GenericCommand(() =>
		{
			// Display cards on battlefield
			Debug.Log(ServiceLocator.Get<IZoneService>().Get(Zones.BATTLEFIELD));
		}));
	}
}
