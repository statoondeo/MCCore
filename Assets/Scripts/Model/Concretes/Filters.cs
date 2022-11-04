public interface IFilterStrategy
{
	bool Filter(IEntity card);
}
public class SpecificCardFilterStrategy : IFilterStrategy
{
	protected string CardId;

	public SpecificCardFilterStrategy(string cardId) => CardId = cardId;

	public bool Filter(IEntity card) => (card.Id == CardId);
}
public class CanBeAttackedFilterStrategy : IFilterStrategy
{
	public CanBeAttackedFilterStrategy() { }

	public bool Filter(IEntity card)
	{
		IDefenseComponentProxy defenseComponentProxy = card.GetComponent<IDefenseComponentProxy>();
		return ((null != defenseComponentProxy) && defenseComponentProxy.CanBeAttacked());
	}
}
public class AndCompositeFilterStrategy : IFilterStrategy
{
	protected IFilterStrategy[] FilterStrategies;

	public AndCompositeFilterStrategy(params IFilterStrategy[] filterStrategies) => FilterStrategies = filterStrategies;

	public bool Filter(IEntity card)
	{
		for (int i = 0; i < FilterStrategies.Length; i++)
		 if (!FilterStrategies[i].Filter(card)) return (false);
		return (true);
	}
}
public class CardTypesFilterStrategy : IFilterStrategy
{
	protected ICardType[] CardTypesToFilter;

	public CardTypesFilterStrategy(params string[] cardTypesToFilter)
	{
		CardTypesToFilter = new ICardType[cardTypesToFilter.Length];
		for (int i = 0; i < CardTypesToFilter.Length; i++)
			CardTypesToFilter[i] = ServiceLocator.Get<ICardTypeService>().Get(cardTypesToFilter[i]);
	}

	public bool Filter(IEntity card)
	{
		ICardComponentProxy cardComponentProxy = card.GetComponent<ICardComponentProxy>();
		if (null == cardComponentProxy) return (false);

		return (cardComponentProxy.IsOneOfCardType(CardTypesToFilter));
	}
}
public class ClassificationFilterStrategy : IFilterStrategy
{
	protected IClassification ClassificationsToFilter;

	public ClassificationFilterStrategy(string classificationToFilter) 
		=> ClassificationsToFilter = ServiceLocator.Get<IClassificationService>().Get(classificationToFilter);

	public bool Filter(IEntity card)
	{
		ICardComponentProxy cardComponentProxy = card.GetComponent<ICardComponentProxy>();
		if (null == cardComponentProxy) return (false);

		return (cardComponentProxy.IsClassification(ClassificationsToFilter));
	}
}
public class EncounterCardFilterStrategy : CardTypesFilterStrategy, IFilterStrategy
{
	public EncounterCardFilterStrategy() : base(
		CardTypes.ATTACHMENT,
		CardTypes.MAIN_SCHEME,
		CardTypes.MINION,
		CardTypes.SIDE_SCHEME,
		CardTypes.TREACHERY,
		CardTypes.VILLAIN)
	{ }
}
public class EnemyFilterStrategy : CardTypesFilterStrategy, IFilterStrategy
{
	public EnemyFilterStrategy() : base(
		CardTypes.MINION,
		CardTypes.VILLAIN)
	{ }
}
public class AttackEnemyFilterStrategy : AndCompositeFilterStrategy
{
	public AttackEnemyFilterStrategy() : base(new EnemyFilterStrategy(), new CanBeAttackedFilterStrategy()) { }
}
public class IdentityCardFilterStrategy : CardTypesFilterStrategy, IFilterStrategy
{
	public IdentityCardFilterStrategy() : base( CardTypes.ALTER_EGO, CardTypes.HERO) { }
}
