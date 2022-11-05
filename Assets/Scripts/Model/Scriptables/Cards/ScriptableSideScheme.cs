using UnityEngine;

[CreateAssetMenu(fileName = "Side Scheme", menuName = "Cards/Side Scheme")]
public class ScriptableSideScheme : ScriptableEntity
{
	[Header("Card Attributes")]
	[SerializeField] protected string Name;
	[SerializeField] protected string Title;
	[SerializeField] protected bool Unique;
	[SerializeField] protected ScriptableClassification Classification;
	[SerializeField] protected ScriptableValue Threat;
	[SerializeField] protected ScriptableCommand WhenRevealedAbility;
	[SerializeField] protected Sprite Image;
	[SerializeField] protected ScriptableBack Back;

	public override IEntity Create(IPlayer owner)
	{
		IEntity card = new Entity(Id, owner);
		card.AddComponent<IBasicComponentProxy>(new BasicComponentProxy());
		IFaceContainerComponentProxy faceContainerComponentProxy = card.AddComponent<IFaceContainerComponentProxy>(new FaceContainerComponentProxy());

		IEntity face = new Entity();
		face.AddComponent<INameComponentProxy>(new NameComponentProxy(Name, Image));
		face.AddComponent<ICardComponentProxy>(new CardComponentProxy(ServiceLocator.Get<ICardTypeService>().Get(CardTypes.SIDE_SCHEME), ServiceLocator.Get<IClassificationService>().Get(Classification.Key)));
		face.AddComponent<IThreatComponentProxy>(new ThreatComponentProxy(Threat.GetValue()));
		if (null != WhenRevealedAbility) face.AddComponent<IWhenRevealedComponentProxy>(new WhenRevealedComponentProxy(WhenRevealedAbility.Create(card)));
		faceContainerComponentProxy.RegisterFace(new FaceComponentProxy("RECTO", face));

		faceContainerComponentProxy.RegisterFace(new FaceComponentProxy("VERSO", Back.Create(owner)));

		return (card);
	}
}
