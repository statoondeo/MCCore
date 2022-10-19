using UnityEngine;

public class AttackTester : MonoBehaviour
{
	[SerializeField] protected ScriptableEntity Hero;
	[SerializeField] protected ScriptableEntity Upgrade;

	void Start()
	{
		// Data services
		ServiceLocator.Register<ICardTypeService>(new CardTypeService()).Initialize();
		ServiceLocator.Register<ITraitService>(new TraitService()).Initialize();
		ServiceLocator.Register<IZoneService>(new ZoneService()).Initialize();
		ServiceLocator.Register<IEntityService>(new EntityService()).Initialize();

		// Process services
		ServiceLocator.Register<IStackService>(new StackService()).Initialize();
		ServiceLocator.Register<IMessageService>(new MessageService()).Initialize();

		// Test scenario
		IStackService stackService = ServiceLocator.Get<IStackService>();
		IScenario scenario = new AlterEgoActionFlipHeroAction(Hero);
		for (int i = 0; i < scenario.Commands.Count; i++)
		{
			scenario.Commands[i].Execute();
			stackService.PerformStack();
		}
	}
}
