﻿using System.Collections.Generic;
using System.Linq;

public class AlterEgoActionFlipHeroAction : IScenario
{
	public IList<ICommand> Commands { get; protected set; }

	public AlterEgoActionFlipHeroAction(ScriptableEntity hero)
	{
		Commands = new List<ICommand>();
		string captainMarvelId = string.Empty;
		Commands.Add(new GenericCommand(() =>
		{
			IEntity captainMarvel = ServiceLocator.Get<IEntityService>().Add(hero.Create());
			captainMarvelId = captainMarvel.Id;
			IBasicComponentProxy basicComponent = captainMarvel.GetComponent<IBasicComponentProxy>();
			ServiceLocator.Get<IStackService>().EnqueueCommand(basicComponent.MoveCommands[Zones.BATTLEFIELD]);
		}));
		Commands.Add(new GenericCommand(() =>
		{
			IEntity captainMarvel = null;
			IList<IEntity> entities = ServiceLocator.Get<IEntityService>().Get();
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].Id == captainMarvelId)
				{
					captainMarvel = entities[i];
					break;
				}
			}
			IFaceContainerComponentProxy faceContainer = captainMarvel.GetComponent<IFaceContainerComponentProxy>();
			IPlayableContainerComponentProxy playableContainer = faceContainer.ActiveFace.Face.GetComponent<IPlayableContainerComponentProxy>();
			Commands.Add(playableContainer.Playables.First().Value.PlayCommand);
			ServiceLocator.Get<IStackService>().EnqueueCommand(playableContainer.Playables.First().Value.PlayCommand);
		}));
		Commands.Add(new GenericCommand(() =>
		{
			IEntity captainMarvel = null;
			IList<IEntity> entities = ServiceLocator.Get<IEntityService>().Get();
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].Id == captainMarvelId)
				{
					captainMarvel = entities[i];
					break;
				}
			}
			IFaceContainerComponentProxy faceContainer = captainMarvel.GetComponent<IFaceContainerComponentProxy>();
			ServiceLocator.Get<IStackService>().EnqueueCommand(faceContainer.FlipCommands[CardTypes.HERO]);
			;
		}));
		Commands.Add(new GenericCommand(() =>
		{
			IEntity captainMarvel = null;
			IList<IEntity> entities = ServiceLocator.Get<IEntityService>().Get();
			for (int i = 0; i < entities.Count; i++)
			{
				if (entities[i].Id == captainMarvelId)
				{
					captainMarvel = entities[i];
					break;
				}
			}
			IFaceContainerComponentProxy faceContainer = captainMarvel.GetComponent<IFaceContainerComponentProxy>();
			IPlayableContainerComponentProxy playableContainer = faceContainer.ActiveFace.Face.GetComponent<IPlayableContainerComponentProxy>();
			ServiceLocator.Get<IStackService>().EnqueueCommand(playableContainer.Playables.First().Value.PlayCommand);
			;
		}));
	}
}
