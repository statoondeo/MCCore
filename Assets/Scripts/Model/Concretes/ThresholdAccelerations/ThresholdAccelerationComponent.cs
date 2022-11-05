public class ThresholdAccelerationComponent : BaseComponent, IThresholdAccelerationComponent
{
	public int Threshold { get; protected set; }
	public int Acceleration { get; protected set; }

	public ThresholdAccelerationComponent(int threshold, int acceleration) : base()
	{
		Threshold = threshold;
		Acceleration = acceleration;
	}

	public void Accelerate()
	{
		throw new System.NotImplementedException();
	}
}
