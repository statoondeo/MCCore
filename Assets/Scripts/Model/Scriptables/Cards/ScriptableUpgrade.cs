using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/Card")]
public class ScriptableUpgrade : ScriptableEntity
{
	[Header("Card Attributes")]
	[SerializeField] protected string Name;
	[SerializeField] protected string Title;
	[SerializeField] protected bool Unique;
	[SerializeField] protected ScriptableCardType CardType;
	[SerializeField] protected ScriptableClassification Classification;
	[SerializeField] protected Sprite Image;

	public override IEntity Create()
	{
		IEntity card = new Entity();
		card.AddComponent<IBasicComponentProxy>(new BasicComponentProxy());
		card.AddComponent<INameComponentProxy>(new NameComponentProxy(Name, Image));
		card.AddComponent<ICardComponentProxy>(new CardComponentProxy(ServiceLocator.Get<ICardTypeService>().Get(CardType.Key), ServiceLocator.Get<IClassificationService>().Get(Classification.Key)));
		return (card);
	}
}
