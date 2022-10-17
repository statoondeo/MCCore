using System.Text;

public class BasicComponentProxy : BaseComponentProxy<IBasicComponent>, IBasicComponentProxy
{
	public string Location => Wrapped.Location;
	public int Order => Wrapped.Order;

	public BasicComponentProxy() : base(new BasicComponent()) { }

	public void MoveTo(string zoneId) => Wrapped.MoveTo(zoneId);
	public void SetOrder(int order) => Wrapped.SetOrder(order);

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t BasicComponentProxy");
		sb.AppendLine($"\t\t Location={Location}");
		sb.AppendLine($"\t\t Order={Order}");
		return (sb.ToString());
	}
}
