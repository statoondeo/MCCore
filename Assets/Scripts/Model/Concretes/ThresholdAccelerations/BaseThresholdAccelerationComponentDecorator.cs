public abstract class BaseThresholdAccelerationComponentDecorator : BaseComponentDecorator<IThresholdAccelerationComponent>, IThresholdAccelerationComponentDecorator
{
	public virtual int Threshold => Inner.Threshold;
	public virtual int Acceleration => Inner.Acceleration;

	protected BaseThresholdAccelerationComponentDecorator(IActivable owner) : base(owner) { }

	public virtual void Accelerate() => Inner.Accelerate();
}
