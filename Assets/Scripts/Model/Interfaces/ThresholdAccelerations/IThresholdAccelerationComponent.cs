public interface IThresholdAccelerationComponent : IComponent
{
	int Threshold { get; }
	int Acceleration { get; }
	void Accelerate();
}
