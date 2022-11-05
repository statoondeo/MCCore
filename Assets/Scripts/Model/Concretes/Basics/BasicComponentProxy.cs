using System.Text;

public class BasicComponentProxy : BaseComponentProxy<IBasicComponent>, IBasicComponentProxy
{
	public (string, IPlayer) Location => Wrapped.Location;
	public int Order => Wrapped.Order;

	public BasicComponentProxy() : base(new BasicComponent()) { }

	public bool CanMoveTo(string zoneId) => Wrapped.CanMoveTo(zoneId);
	public bool CanMoveTo((string, IPlayer) zoneId) => Wrapped.CanMoveTo(zoneId);
	public void MoveTo(string zoneId) => Wrapped.MoveTo(zoneId);
	public void MoveTo((string, IPlayer) zoneId) => Wrapped.MoveTo(zoneId);
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
