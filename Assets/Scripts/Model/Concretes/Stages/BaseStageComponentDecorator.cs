public abstract class BaseStageComponentDecorator : BaseComponentDecorator<IStageComponent>, IStageComponentDecorator
{
	public virtual int Stage => Inner.Stage;

	protected BaseStageComponentDecorator(IActivable owner) : base(owner) { }
}
