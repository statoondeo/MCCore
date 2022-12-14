using System.Collections.Generic;
using UnityEngine;

public class PlayerSetupScenario : BaseScenario
{
	public PlayerSetupScenario(string playerName, ScriptableDeck[] playerDeck, string villainName, ScriptableDeck[] villainDeck) : base()
	{
		Commands.Add(new GenericCommand(() =>
		{
			// Mute messages
			ServiceLocator.Get<IMessageService>().Mute();
			ServiceLocator.Get<IStateBasedEffectService>().Mute();
		}));

		#region Player Setup

		Commands.Add(new GenericCommand(() =>
		{
			// Create player
			IPlayer player = ServiceLocator.Get<IPlayerService>().Add(playerName, new Player(playerName));

			// Create player zones
			IZoneService zoneService = ServiceLocator.Get<IZoneService>();
			for (int j = 0; j < player.ZoneNames.Count; j++)
				zoneService.Add((player.ZoneNames[j], player), Zones.CreateZone(player, player.ZoneNames[j]));
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Create player deck
			List<IEntity> deckList = new();
			for (int i = 0; i < playerDeck.Length; i++) 
				deckList.AddRange(playerDeck[i].Create(ServiceLocator.Get<IPlayerService>().Get(playerName)));

			// Deck feeding
			IEntityService entityService = ServiceLocator.Get<IEntityService>();
			for (int i = 0; i < deckList.Count; i++)
			{
				IEntity card = entityService.Add(deckList[i]);
				card.GetComponent<IBasicComponentProxy>().MoveTo(Zones.DECK);
				card.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.VERSO);
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			IPlayer player = ServiceLocator.Get<IPlayerService>().Get(playerName);

			// Select Identity
			player.SetIdentity(ServiceLocator.Get<IZoneService>().Get((Zones.DECK, player)).GetComponent<ITankComponentProxy>()
				.GetFirst(new IdentityCardFilterStrategy()));

			// Flip to Alter-ego face
			player.Identity.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.ALTER_EGO);

			// Move to Battlefield
			player.Identity.GetComponent<IBasicComponentProxy>().MoveTo((Zones.BATTLEFIELD, null));
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Set aside obligations
			IList<IEntity> cards = ServiceLocator.Get<IZoneService>().Get((Zones.DECK, ServiceLocator.Get<IPlayerService>().Get(playerName)))
									.GetComponent<ITankComponentProxy>().Get(new CardTypesFilterStrategy(CardTypes.OBLIGATION));
			for (int i = 0; i < cards.Count; i++) cards[i].GetComponent<IBasicComponentProxy>().MoveTo(Zones.EXIL);
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Set aside nemesis cards
			IList<IEntity> cards = ServiceLocator.Get<IZoneService>().Get((Zones.DECK, ServiceLocator.Get<IPlayerService>().Get(playerName)))
									.GetComponent<ITankComponentProxy>().Get(new ClassificationFilterStrategy(Classifications.NEMESIS));
			for (int i = 0; i < cards.Count; i++) cards[i].GetComponent<IBasicComponentProxy>().MoveTo(Zones.EXIL);

		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Shuffle deck
			ServiceLocator.Get<IZoneService>()
				.Get((Zones.DECK, ServiceLocator.Get<IPlayerService>().Get(playerName)))
				.GetComponent<IShuffleComponentProxy>().Shuffle();

		}));
		Commands.Add(new DrawHandCommand(playerName));

		#endregion

		#region Villain Setup

		Commands.Add(new GenericCommand(() =>
		{
			// Create player
			IPlayer player = ServiceLocator.Get<IPlayerService>().Add(villainName, new Villain(villainName));

			// Create player zones
			IZoneService zoneService = ServiceLocator.Get<IZoneService>();
			for (int j = 0; j < player.ZoneNames.Count; j++)
				zoneService.Add((player.ZoneNames[j], player), Zones.CreateZone(player, player.ZoneNames[j]));
		})); 
		Commands.Add(new GenericCommand(() =>
		{
			IPlayer villain = ServiceLocator.Get<IPlayerService>().Get(villainName);

			// Create player deck
			List<IEntity> deckList = new();
			for (int i = 0; i < villainDeck.Length; i++) 
				deckList.AddRange(villainDeck[i].Create(villain));

			// Deck feeding
			IEntityService entityService = ServiceLocator.Get<IEntityService>();
			for (int i = 0; i < deckList.Count; i++)
			{
				IEntity card = entityService.Add(deckList[i]);
				card.GetComponent<IBasicComponentProxy>().MoveTo(Zones.DECK);
				card.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.VERSO);
			}
		}));
		Commands.Add(new GenericCommand(() =>
		{
			IPlayer villain = ServiceLocator.Get<IPlayerService>().Get(villainName);

			// Select Identity
			villain.SetIdentity(ServiceLocator.Get<IZoneService>().Get((Zones.DECK, villain)).GetComponent<ITankComponentProxy>().GetFirst(new CardTypesFilterStrategy(CardTypes.VILLAIN)));

			// Flip to Alter-ego face
			villain.Identity.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.RECTO);

			// Move to Battlefield
			villain.Identity.GetComponent<IBasicComponentProxy>().MoveTo((Zones.BATTLEFIELD, null));
		}));
		Commands.Add(new GenericCommand(() =>
		{
			IPlayer villain = ServiceLocator.Get<IPlayerService>().Get(villainName);

			// Select Main Scheme
			IEntity mainScheme = ServiceLocator.Get<IZoneService>().Get((Zones.DECK, villain))
									.GetComponent<ITankComponentProxy>().GetFirst(new CardTypesFilterStrategy(CardTypes.MAIN_SCHEME));

			// Flip to first stage
			mainScheme.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.STAGE_1);

			// Move to Battlefield
			mainScheme.GetComponent<IBasicComponentProxy>().MoveTo((Zones.BATTLEFIELD, null));

			// Register scheme loose condition
			ServiceLocator.Get<IStateBasedEffectService>().Register(new SchemePlayerWinStateBasedEffect(villain));
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Shuffle deck
			ServiceLocator.Get<IZoneService>().Get((Zones.DECK, ServiceLocator.Get<IPlayerService>().Get(villainName)))
				.GetComponent<IShuffleComponentProxy>().Shuffle();
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Main Scheme Setup
			IList<IEntity> cards = ServiceLocator.Get<IZoneService>().Get((Zones.BATTLEFIELD, null)).GetComponent<ITankComponentProxy>()
				.Get(new CardTypesFilterStrategy(CardTypes.MAIN_SCHEME));
			for (int i = 0; i < cards.Count; i++) cards[i].GetActiveFaceComponent<ISetupComponentProxy>()?.Setup();
		})); 
		Commands.Add(new GenericCommand(() =>
		{
			// Battlefield Encounter cards WhenRevealed
			IList<IEntity> cards = ServiceLocator.Get<IZoneService>().Get((Zones.BATTLEFIELD, null)).GetComponent<ITankComponentProxy>().Get(new EncounterCardFilterStrategy());
			for (int i = 0; i < cards.Count; i++) cards[i].GetActiveFaceComponent<IWhenRevealedComponentProxy>()?.WhenRevealed();
		}));
		Commands.Add(new GenericCommand(() =>
		{
			IPlayer villain = ServiceLocator.Get<IPlayerService>().Get(villainName);

			// Move player obligations into villain deck
			IList<IEntity> cards = ServiceLocator.Get<IZoneService>().Get((Zones.EXIL, ServiceLocator.Get<IPlayerService>().Get(playerName)))
				.GetComponent<ITankComponentProxy>().Get(new CardTypesFilterStrategy(CardTypes.OBLIGATION));
			for (int i = 0; i < cards.Count; i++) cards[i].GetActiveFaceComponent<IBasicComponentProxy>().MoveTo((Zones.DECK, villain));

			// Shuffle deck
			ServiceLocator.Get<IZoneService>().Get((Zones.DECK, villain)).GetComponent<IShuffleComponentProxy>().Shuffle();
		}));

		#endregion

		#region Player Setup end

		Commands.Add(new GenericCommand(() =>
		{
			// Mulligan
			// Choose cards to discard
			IList<IEntity> cardsToDiscard = new List<IEntity>();
			// Discard cards
			for (int i = 0; i < cardsToDiscard.Count; i++) cardsToDiscard[i].GetComponent<IBasicComponentProxy>().MoveTo(Zones.DISCARD);
		}));
		Commands.Add(new DrawHandCommand(playerName));
		Commands.Add(new GenericCommand(() =>
		{
			// Hero Setup
			ServiceLocator.Get<IPlayerService>().Get(playerName).Identity.GetActiveFaceComponent<ISetupComponentProxy>()?.Setup();
		}));

		#endregion

		Commands.Add(new GenericCommand(() =>
		{
			// Unmute messages/state based effects
			ServiceLocator.Get<IMessageService>().UnMute();
			ServiceLocator.Get<IStateBasedEffectService>().UnMute();
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Display cards on battlefield
			Debug.Log(ServiceLocator.Get<IZoneService>().Get((Zones.BATTLEFIELD, null)));
		}));
	}
}
