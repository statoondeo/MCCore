using UnityEngine;

[CreateAssetMenu(fileName = "Hero", menuName = "Cards/Hero")]
public class ScriptableHero : ScriptableEntity
{
	[Header("Common Attribues")]
	[SerializeField] protected int HitPoints;

	[Header("Alter Ego Attribues")]
	[SerializeField] protected string AEName;
	[SerializeField] protected Sprite AEImage;
	[SerializeField] protected int Recover;
	[SerializeField] protected int AEHandSize;
	[SerializeField] protected ScriptableTrait[] AETraits;
	[SerializeField] protected ScriptableCommand[] AEAbilities;
	
	[Header("Hero Attribues")]
	[SerializeField] protected string HeroName;
	[SerializeField] protected Sprite HeroImage;
	[SerializeField] protected int Thwart;
	[SerializeField] protected int Attack;
	[SerializeField] protected int Defense;
	[SerializeField] protected int HeroHandSize;
	[SerializeField] protected ScriptableTrait[] HeroTraits;
	[SerializeField] protected ScriptableCommand[] HeroAbilities;

	protected IEntity CreateAEFace()
	{
		ITraitService traitService = ServiceLocator.Get<ITraitService>();
		IEntity face = new FaceEntity();
		face.AddComponent<INameComponentProxy>(new NameComponentProxy(AEName, AEImage));
		face.AddComponent<ICardComponentProxy>(new CardComponentProxy(ServiceLocator.Get<ICardTypeService>().Get(CardTypes.ALTER_EGO), ServiceLocator.Get<IClassificationService>().Get(Classifications.HERO)));
		ITrait[] traits = AETraits.Length > 0 ? new ITrait[AETraits.Length] : null;
		for (int i = 0; i < AETraits.Length; i++) traits[i] = traitService.Get(AETraits[i].Key);
		face.AddComponent<ITraitComponentProxy>(new TraitComponentProxy(traits));
		face.AddComponent<IRecoverComponentProxy>(new RecoverComponentProxy(Recover));
		IPlayableContainerComponentProxy playableContainerComponent = face.AddComponent<IPlayableContainerComponentProxy>(new PlayableContainerComponentProxy());
		for (int i = 0; i < AEAbilities.Length; i++)
		{
			IPlayableComponentProxy playable = playableContainerComponent.RegisterPlayable(new PlayableGenerateComponentProxy(string.Empty, new PlayableGeneratorComponent(string.Empty)));
			playable.Register(new AbilityPlayableComponentDecorator(playable, AEAbilities[i]));
		}
		face.AddComponent<IHandSizeComponentProxy>(new HandSizeComponentProxy(AEHandSize));
		return (face);
	}
	protected IEntity CreateHeroFace()
	{
		ITraitService traitService = ServiceLocator.Get<ITraitService>();
		IEntity face = new FaceEntity();
		face.AddComponent<INameComponentProxy>(new NameComponentProxy(HeroName, HeroImage));
		face.AddComponent<ICardComponentProxy>(new CardComponentProxy(ServiceLocator.Get<ICardTypeService>().Get(CardTypes.HERO), ServiceLocator.Get<IClassificationService>().Get(Classifications.HERO)));
		ITrait[] traits = HeroTraits.Length > 0 ? new ITrait[HeroTraits.Length] : null;
		for (int i = 0; i < HeroTraits.Length; i++) traits[i] = traitService.Get(HeroTraits[i].Key);
		face.AddComponent<ITraitComponentProxy>(new TraitComponentProxy(traits));
		face.AddComponent<IThwartComponentProxy>(new ThwartComponentProxy(Thwart));
		face.AddComponent<IAttackComponentProxy>(new AttackComponentProxy(Attack));
		face.AddComponent<IDefenseComponentProxy>(new DefenseComponentProxy(Defense));
		IPlayableContainerComponentProxy playableContainerComponent = face.AddComponent<IPlayableContainerComponentProxy>(new PlayableContainerComponentProxy());
		for (int i = 0; i < HeroAbilities.Length; i++)
		{
			IPlayableComponentProxy playable = playableContainerComponent.RegisterPlayable(new PlayableGenerateComponentProxy(string.Empty, new PlayableGeneratorComponent(string.Empty)));
			playable.Register(new AbilityPlayableComponentDecorator(playable, HeroAbilities[i]));
		}
		face.AddComponent<IHandSizeComponentProxy>(new HandSizeComponentProxy(HeroHandSize));
		return (face);
	}

	public override IEntity Create()
	{
		IEntity identity = new Entity(Id);
		identity.AddComponent<IBasicComponentProxy>(new BasicComponentProxy());

		IFaceContainerComponentProxy faceContainer = identity.AddComponent<IFaceContainerComponentProxy>(new FaceContainerComponentProxy());
		faceContainer.RegisterFace(new FaceComponentProxy(CardTypes.ALTER_EGO, CreateAEFace()));
		faceContainer.RegisterFace(new FaceComponentProxy(CardTypes.HERO, CreateHeroFace()));

		identity.AddComponent<ILifeComponentProxy>(new LifeComponentProxy(HitPoints));

		return (identity);
	}
}
