public class AbilityPlayableComponentDecorator : BasePlayableComponentDecorator
{
	protected ICommandFactory PlayableCommandFactory;

	public AbilityPlayableComponentDecorator(IActivable owner, ICommandFactory playableCommandFactory) : base(owner) => PlayableCommandFactory = playableCommandFactory;

	public override void Play()
	{
		IEntity entity = ServiceLocator.Get<IEntityService>().Add(new Entity());
		IBasicComponentProxy basicComponentProxy = entity.AddComponent<IBasicComponentProxy>(new BasicComponentProxy());
		ICommand command = PlayableCommandFactory.Create();
		entity.AddComponent<IResolvableComponentProxy>(new ResolvableComponentProxy(new AbilityResolvableComponent(command)));
		basicComponentProxy.MoveTo(Zones.STACK);
		ServiceLocator.Get<IStackService>().EnqueueCommand(command);
		Inner.Play();
	}
}
