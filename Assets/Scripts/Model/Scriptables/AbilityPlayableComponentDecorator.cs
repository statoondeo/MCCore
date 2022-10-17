public class AbilityPlayableComponentDecorator : BasePlayableComponentDecorator
{
	protected ICommandFactory PlayableCommandFactory;

	public AbilityPlayableComponentDecorator(IActivable owner, ICommandFactory playableCommandFactory) : base(owner) => PlayableCommandFactory = playableCommandFactory;

	public override void Play()
	{
		IEntity entity = ServiceLocator.Get<IEntityService>().Add(new Entity());
		entity.AddComponent<IBasicComponentProxy>(new BasicComponentProxy());
		entity.AddComponent<IResolvableComponentProxy>(new ResolvableComponentProxy(new AbilityResolvableComponent(PlayableCommandFactory.Create())));
		IPlayableComponentProxy playableComponentProxy = entity.AddComponent<IPlayableComponentProxy>(new PlayableComponentProxy(""));
		playableComponentProxy.Play();
		Inner.Play();
	}
}
