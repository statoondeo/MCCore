using System.Collections.Generic;
using UnityEngine;

public class AttackTester : MonoBehaviour
{
	[SerializeField] protected string PlayerName;
	[SerializeField] protected string VillainName;
	[SerializeField] protected ScriptableDeck[] PlayerDeck;
	[SerializeField] protected ScriptableDeck[] VillainDeck;

	void Start()
	{
		// Process services
		ServiceLocator.Register<IStateBasedEffectService>(new StateBasedEffectService()).Initialize();
		ServiceLocator.Register<IStackService>(new StackService()).Initialize();
		ServiceLocator.Register<IMessageService>(new MessageService()).Initialize();

		// Data services
		ServiceLocator.Register<IClassificationService>(new ClassificationService()).Initialize();
		ServiceLocator.Register<ICardTypeService>(new CardTypeService()).Initialize();
		ServiceLocator.Register<ITraitService>(new TraitService()).Initialize();
		ServiceLocator.Register<IEntityService>(new EntityService()).Initialize();
		ServiceLocator.Register<IPlayerService>(new PlayerService()).Initialize(new Player(PlayerName), new Villain(VillainName));
		ServiceLocator.Register<IZoneService>(new ZoneService()).Initialize();

		// Test scenario
		IStackService stackService = ServiceLocator.Get<IStackService>();
		IScenario scenario = new PlayerSetupScenario(
			ServiceLocator.Get<IPlayerService>().Get(PlayerName), PlayerDeck,
			ServiceLocator.Get<IPlayerService>().Get(VillainName), VillainDeck);
		for (int i = 0; i < scenario.Commands.Count; i++)
		{
			stackService.EnqueueCommand(scenario.Commands[i]);
			stackService.PerformStack();
		}
	}
}

public interface ICostPaiementStrategy
{
	IList<IEntity> PayCosts();
}
public class ResourcePaiement : ICostPaiementStrategy
{
	public IList<IEntity> PayCosts() => null;
}
public interface IActionStrategy
{
	void InvokeAction(IList<IEntity> targets, IList<IEntity> costs);
}
public class DealDamageActionStrategy : IActionStrategy
{
	protected int DamageAmount;

	public DealDamageActionStrategy(int damageAmount) => DamageAmount = damageAmount;

	public void InvokeAction(IList<IEntity> targets, IList<IEntity> costs)
	{
		IEntity target = targets[0];
		target.GetComponent<ILifeComponentProxy>().TakeDamage(DamageAmount);
	}
}
//public class DrawActionStrategy : IActionStrategy
//{
//	protected int Count;

//	public DrawActionStrategy(int count) => Count = count;

//	public void InvokeAction(IList<IEntity> targets, IList<IEntity> costs)
//	{
//		ITankComponentProxy tankComponentProxy = ServiceLocator.Get<IZoneService>().Get(Zones.PLAYER_DECK).GetComponent<ITankComponentProxy>();
//		IStackService stackService = ServiceLocator.Get<IStackService>();
//		for (int i = 0; i < Count; i++)
//			stackService.EnqueueCommand(new DrawCommand(tankComponentProxy.Get(tankComponentProxy.Count - 1)));
//	}
//}
//public class PhotonicBlastActionStrategy : IActionStrategy
//{
//	public void InvokeAction(IList<IEntity> targets, IList<IEntity> costs)
//	{
//		(new DealDamageActionStrategy(5)).InvokeAction(targets, costs);
//		if (costs.Contains(null)) (new DrawActionStrategy(1)).InvokeAction(targets, costs);
//	}
//}
public abstract class HeroAction
{
	protected IFilterStrategy TargetSelectionStrategy;
	protected ICostPaiementStrategy CostPaiementStrategy;
	protected IActionStrategy ActionStrategy;
	protected (string, IPlayer)[] TargetSources;

	protected IList<IEntity> Targets;
	protected IList<IEntity> Costs;

	protected HeroAction(
		IFilterStrategy targetSelectionStrategy,
		ICostPaiementStrategy costPaiementStrategy,
		IActionStrategy actionStrategy,
		params (string, IPlayer)[] targetSources)
	{
		TargetSelectionStrategy = targetSelectionStrategy;
		CostPaiementStrategy = costPaiementStrategy;
		ActionStrategy = actionStrategy;
		TargetSources = targetSources;
	}

	public IList<IEntity> GetTargets()
	{
		if ((null == TargetSources) || (0 == Targets.Count)) return (new List<IEntity>());
		if (1 == Targets.Count) return (ServiceLocator.Get<IZoneService>().Get(TargetSources[0]).GetComponent<ITankComponentProxy>().Get(TargetSelectionStrategy));
		IList<IEntity> targets = new List<IEntity>();
		for (int i = 0; i < TargetSources.Length; i++)
			((List<IEntity>)targets).AddRange(ServiceLocator.Get<IZoneService>().Get(TargetSources[i]).GetComponent<ITankComponentProxy>().Get(TargetSelectionStrategy));
		return (targets);
	}

	public void SetTargets(IList<IEntity> targets) => Targets = targets;
	public IList<IEntity> GetCosts() => null;
	public void PayCosts(IList<IEntity> costs) => Costs = costs;
	public void InvokeAction() => ActionStrategy.InvokeAction(Targets, Costs);
}