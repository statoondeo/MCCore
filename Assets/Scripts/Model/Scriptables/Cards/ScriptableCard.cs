using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "Cards/Card")]
public class ScriptableCard : ScriptableEntity
{
	[Header("Card Attributes")]
	[SerializeField] protected string Name;
	[SerializeField] protected string Title;
	[SerializeField] protected bool Unique;
	[SerializeField] protected ScriptableCardType CardType;
	[SerializeField] protected ScriptableClassification Classification;
	[SerializeField] protected Sprite Image;
	[SerializeField] protected ScriptableBack Back;

	public override IEntity Create(IPlayer owner)
	{
		IEntity card = new Entity(Id);
		card.AddComponent<IBasicComponentProxy>(new BasicComponentProxy(owner));
		IFaceContainerComponentProxy faceContainerComponentProxy = card.AddComponent<IFaceContainerComponentProxy>(new FaceContainerComponentProxy());

		IEntity face = new Entity();
		face.AddComponent<INameComponentProxy>(new NameComponentProxy(Name, Image));
		face.AddComponent<ICardComponentProxy>(new CardComponentProxy(ServiceLocator.Get<ICardTypeService>().Get(CardType.Key), ServiceLocator.Get<IClassificationService>().Get(Classification.Key)));
		faceContainerComponentProxy.RegisterFace(new FaceComponentProxy("RECTO", face));

		faceContainerComponentProxy.RegisterFace(new FaceComponentProxy("VERSO", Back.Create(owner)));

		return (card);
	}
}
