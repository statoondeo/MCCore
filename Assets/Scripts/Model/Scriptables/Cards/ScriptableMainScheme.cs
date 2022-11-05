using UnityEngine;

[CreateAssetMenu(fileName = "Main Scheme", menuName = "Cards/Main Scheme/Main Scheme")]
public class ScriptableMainScheme : ScriptableEntity
{
	[Header("Faces List")]
	[SerializeField] protected ScriptableMainSchemeFace[] FacesList;

	public override IEntity Create(IPlayer owner)
	{
		IEntity card = new Entity(Id, owner);
		card.AddComponent<IBasicComponentProxy>(new BasicComponentProxy());
		card.AddComponent<ICardComponentProxy>(new CardComponentProxy(ServiceLocator.Get<ICardTypeService>().Get(CardTypes.MAIN_SCHEME), ServiceLocator.Get<IClassificationService>().Get(Classifications.VILLAIN)));

		IFaceContainerComponentProxy faceContainer = card.AddComponent<IFaceContainerComponentProxy>(new FaceContainerComponentProxy());
		for (int i = 0; i < FacesList.Length; i++) faceContainer.RegisterFace(new FaceComponentProxy((i + 1).ToString(), FacesList[i].Create(card)));

		return (card);
	}
}
