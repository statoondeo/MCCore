using System.Text;

public class ThresholdAccelerationComponentProxy : BaseComponentProxy<IThresholdAccelerationComponent>, IThresholdAccelerationComponentProxy
{
	public int Threshold => Wrapped.Threshold;
	public int Acceleration => Wrapped.Acceleration;

	public ThresholdAccelerationComponentProxy(int threshold, int acceleration) : base(new ThresholdAccelerationComponent(threshold, acceleration)) { }

	public void Accelerate() => Wrapped.Accelerate();

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t ThresholdAccelerationComponentProxy");
		sb.AppendLine($"\t\t Threshold={Threshold}");
		sb.AppendLine($"\t\t Acceleration={Acceleration}");
		return (sb.ToString());
	}
}

