using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Cards/Upgrade")]
public class ScriptableUpgrade : ScriptableEntity
{
	[Header("Upgrade Attributes")]
	[SerializeField] protected string Name;
	[SerializeField] protected string Title;
	[SerializeField] protected bool Unique;
	[SerializeField] protected BaseDecoratorFactoryScriptable<IAttackComponent>[] StaticAbilities;
	[SerializeField] protected Sprite Image;

	public override IEntity Create()
	{
		IEntity card = new Entity();
		card.AddComponent<IBasicComponentProxy>(new BasicComponentProxy());
		card.AddComponent<INameComponentProxy>(new NameComponentProxy(Name, Image));
		//ICardComponentProxy cardComponentProxy = card.AddComponent<ICardComponentProxy>(new CardComponentProxy(ServiceLocator.Get<ICardTypeService>().Get(CardTypes.UPGRADE)));
		//for (int i = 0; i < StaticAbilities.Length; i++)
		//	cardComponentProxy.Register(new CardComponentDecoratorAttacherDecorator<IAttackComponent>(cardComponentProxy, StaticAbilities[i]));

		return (card);
	}
}
