public abstract class BaseStageComponentDecorator : BaseComponentDecorator<IStageComponent>, IStageComponentDecorator
{
	public virtual string Stage => Inner.Stage;

	protected BaseStageComponentDecorator(IActivable owner) : base(owner) { }
}
