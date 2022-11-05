using UnityEngine;

[CreateAssetMenu(fileName = "Villain", menuName = "Cards/Villain")]
public class ScriptableVillain : ScriptableEntity
{
	[Header("Common Attributes")]
	[SerializeField] protected string Name;

	[Header("Face 1 Attributes")]
	[SerializeField] protected int Face1Stage;
	[SerializeField] protected int Face1Scheme;
	[SerializeField] protected int Face1Attack;
	[SerializeField] protected int Face1HitPoints;
	[SerializeField] protected ScriptableTrait[] Face1Traits;
	[SerializeField] protected ScriptableCommand Face1WhenRevealedAbility;
	[SerializeField] protected Sprite Face1Image;

	[Header("Face 2 Attributes")]
	[SerializeField] protected int Face2Stage;
	[SerializeField] protected int Face2Scheme;
	[SerializeField] protected int Face2Attack;
	[SerializeField] protected int Face2HitPoints;
	[SerializeField] protected ScriptableTrait[] Face2Traits;
	[SerializeField] protected ScriptableCommand Face2WhenRevealedAbility;
	[SerializeField] protected Sprite Face2Image;

	protected ITraitService TraitService;
	protected ICardType VillainCardType;
	protected IClassification VillainClassification;

	protected IEntity CreateFace(IEntity parentEntity, int stage, int scheme, int attack, int hitPoints, ScriptableTrait[] traits, ScriptableCommand ability, Sprite image)
	{
		IEntity face = new FaceEntity();
		face.AddComponent<INameComponentProxy>(new NameComponentProxy(Name, image));
		face.AddComponent<ICardComponentProxy>(new CardComponentProxy(VillainCardType, VillainClassification));
		ITrait[] traitsArray = traits.Length > 0 ? new ITrait[traits.Length] : null;
		for (int i = 0; i < traits.Length; i++) traitsArray[i] = TraitService.Get(traits[i].Key);
		face.AddComponent<ITraitComponentProxy>(new TraitComponentProxy(traitsArray));
		face.AddComponent<ISchemeComponentProxy>(new SchemeComponentProxy(scheme));
		face.AddComponent<IAttackComponentProxy>(new AttackComponentProxy(attack));
		face.AddComponent<ILifeComponentProxy>(new LifeComponentProxy(hitPoints));
		face.AddComponent<IStageComponentProxy>(new StageComponentProxy(stage));
		if (null != ability) face.AddComponent<IWhenRevealedComponentProxy>(new WhenRevealedComponentProxy(ability.Create(parentEntity)));

		return (face);
	}

	public override IEntity Create(IPlayer owner)
	{
		TraitService = ServiceLocator.Get<ITraitService>();
		VillainCardType = ServiceLocator.Get<ICardTypeService>().Get(CardTypes.VILLAIN);
		VillainClassification = ServiceLocator.Get<IClassificationService>().Get(Classifications.VILLAIN);

		IEntity identity = new Entity(Id, owner);
		identity.AddComponent<IBasicComponentProxy>(new BasicComponentProxy());

		IFaceContainerComponentProxy faceContainer = identity.AddComponent<IFaceContainerComponentProxy>(new FaceContainerComponentProxy());
		faceContainer.RegisterFace(new FaceComponentProxy(Faces.RECTO, CreateFace(identity, Face1Stage, Face1Scheme, Face1Attack, Face1HitPoints, Face1Traits, Face1WhenRevealedAbility, Face1Image)));
		faceContainer.RegisterFace(new FaceComponentProxy(Faces.VERSO, CreateFace(identity, Face2Stage, Face2Scheme, Face2Attack, Face2HitPoints, Face2Traits, Face2WhenRevealedAbility, Face2Image)));

		return (identity);
	}
}
