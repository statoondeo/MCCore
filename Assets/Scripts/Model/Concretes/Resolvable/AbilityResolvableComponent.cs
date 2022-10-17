public class AbilityResolvableComponent : BaseResolvableComponent
{
	protected ICommand Command;

	public AbilityResolvableComponent(ICommand command) : base() => Command = command;

	protected void RemoveEntity() => ServiceLocator.Get<IEntityService>().Remove(Entity);
	public override void Cancel() => RemoveEntity();
	public override void Resolve()
	{
		Command.Execute();
		RemoveEntity();
	}
}
