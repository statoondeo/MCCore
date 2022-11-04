using System.Collections.Generic;
using UnityEngine;

public class PlayerSetupScenario : BaseScenario
{
	public PlayerSetupScenario(IPlayer player, ScriptableDeck[] playerDeck, IPlayer villain, ScriptableDeck[] villainDeck) : base()
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
			// Create player deck
			List<IEntity> deckList = new();
			for (int i = 0; i < playerDeck.Length; i++) deckList.AddRange(playerDeck[i].Create(player));

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
			// Select Identity
			player.SetIdentity(ServiceLocator.Get<IZoneService>().Get((Zones.DECK, player)).GetComponent<ITankComponentProxy>().GetFirst(new IdentityCardFilterStrategy()));

			// Flip to Alter-ego face
			player.Identity.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.ALTER_EGO);

			// Move to Battlefield
			player.Identity.GetComponent<IBasicComponentProxy>().MoveTo((Zones.BATTLEFIELD, null));
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Set aside obligations
			IList<IEntity> cards = ServiceLocator.Get<IZoneService>().Get((Zones.DECK, player)).GetComponent<ITankComponentProxy>().Get(new CardTypesFilterStrategy(CardTypes.OBLIGATION));
			for (int i = 0; i < cards.Count; i++) cards[i].GetComponent<IBasicComponentProxy>().MoveTo(Zones.EXIL);
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Set aside nemesis cards
			IList<IEntity> cards = ServiceLocator.Get<IZoneService>().Get((Zones.DECK, player)).GetComponent<ITankComponentProxy>().Get(new ClassificationFilterStrategy(Classifications.NEMESIS));
			for (int i = 0; i < cards.Count; i++) cards[i].GetComponent<IBasicComponentProxy>().MoveTo(Zones.EXIL);

		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Shuffle deck
			ServiceLocator.Get<IZoneService>().Get((Zones.DECK, player)).GetComponent<IShuffleComponentProxy>().Shuffle();

		})); 
		Commands.Add(new DrawHandCommand(player));

		#endregion

		#region Villain Setup

		Commands.Add(new GenericCommand(() =>
		{
			// Create player
			//ServiceLocator.Get<IPlayerService>().Add("VILLAIN", new Player("VILLAIN"));

			// Create player deck
			List<IEntity> deckList = new();
			for (int i = 0; i < villainDeck.Length; i++) deckList.AddRange(villainDeck[i].Create(villain));

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
			// Select Identity
			villain.SetIdentity(ServiceLocator.Get<IZoneService>().Get((Zones.DECK, villain)).GetComponent<ITankComponentProxy>().GetFirst(new CardTypesFilterStrategy(CardTypes.VILLAIN)));

			// Flip to Alter-ego face
			villain.Identity.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.RECTO);

			// Move to Battlefield
			villain.Identity.GetComponent<IBasicComponentProxy>().MoveTo((Zones.BATTLEFIELD, null));
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Shuffle deck
			ServiceLocator.Get<IZoneService>().Get((Zones.DECK, villain)).GetComponent<IShuffleComponentProxy>().Shuffle();
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Main Scheme Setup
			IList<IEntity> mainSchemes = ServiceLocator.Get<IZoneService>().Get((Zones.DECK, villain)).GetComponent<ITankComponentProxy>().Get(new CardTypesFilterStrategy(CardTypes.MAIN_SCHEME));
			for (int i = 0; i < mainSchemes.Count; i++) mainSchemes[i].GetComponent<ISetupComponentProxy>()?.Setup();
		})); 
		Commands.Add(new GenericCommand(() =>
		{
			// Battlefield Encounter cards WhenRevealed
			IList<IEntity> cards = ServiceLocator.Get<IZoneService>().Get((Zones.BATTLEFIELD, null)).GetComponent<ITankComponentProxy>().Get(new EncounterCardFilterStrategy());
			for (int i = 0; i < cards.Count; i++) cards[i].GetComponent<IWhenRevealedComponentProxy>()?.WhenRevealed();
		}));
		Commands.Add(new GenericCommand(() =>
		{
			// Move player obligations into villain deck
			IList<IEntity> cards = ServiceLocator.Get<IZoneService>().Get((Zones.EXIL, player)).GetComponent<ITankComponentProxy>().Get(new CardTypesFilterStrategy(CardTypes.OBLIGATION));
			for (int i = 0; i < cards.Count; i++) cards[i].GetComponent<IBasicComponentProxy>().MoveTo((Zones.DECK, villain));

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
		Commands.Add(new DrawHandCommand(player));
		Commands.Add(new GenericCommand(() =>
		{
			// Hero Setup
			player.Identity.GetComponent<ISetupComponentProxy>()?.Setup();
		}));

		#endregion

		Commands.Add(new GenericCommand(() =>
		{
			// Unmute messages/state based effects
			ServiceLocator.Get<IMessageService>().UnMute();
			ServiceLocator.Get<IStateBasedEffectService>().UnMute();
		}));
		//// Rhino II revealed
		//Commands.Add(new GenericCommand(() =>
		//{
		//	// Search Breakin' & Takin'
		//	IZoneService zoneService = ServiceLocator.Get<IZoneService>();
		//	IFilterStrategy filterStrategy = new SpecificCardFilterStrategy("1497f5a1-72c6-4450-b618-46b0e6affc14");
		//	ITankComponentProxy discard = zoneService.Get((Zones.DISCARD, villain)).GetComponent<ITankComponentProxy>();
		//	ITankComponentProxy deck = zoneService.Get((Zones.DECK, villain)).GetComponent<ITankComponentProxy>(); 
		//	IEntity cardFound = /*discard.GetFirst(filterStrategy) ?? */deck.GetFirst(filterStrategy);

		//	if (null != cardFound)
		//	{
		//		cardFound.GetComponent<IBasicComponentProxy>().MoveTo((Zones.BATTLEFIELD, null));
		//		cardFound.GetComponent<IFaceContainerComponentProxy>().FlipTo(Faces.RECTO);
		//		cardFound.GetComponent<IFaceContainerComponentProxy>().ActiveFace.Face.GetComponent<IWhenRevealedComponentProxy>()?.WhenRevealed();
		//	}
		//	zoneService.Get((Zones.DECK, villain)).GetComponent<IShuffleComponentProxy>().Shuffle();
		//}));
		Commands.Add(new GenericCommand(() =>
		{
			// Display cards on battlefield
			Debug.Log(ServiceLocator.Get<IZoneService>().Get((Zones.BATTLEFIELD, null)));
		}));
	}
}
