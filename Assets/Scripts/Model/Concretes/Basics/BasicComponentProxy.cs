using System.Collections.Generic;
using System.Text;

public class BasicComponentProxy : BaseComponentProxy<IBasicComponent>, IBasicComponentProxy
{
	public string Location => Wrapped.Location;
	public int Order => Wrapped.Order;
	public IDictionary<string, ICommand> MoveCommands { get; protected set; }

	public BasicComponentProxy() : base(new BasicComponent())
	{
		MoveCommands = new Dictionary<string, ICommand>();
		IList<IEntity> zones = ServiceLocator.Get<IZoneService>().Get();
		for (int i = 0; i < zones.Count; i++)
		{
			IZoneComponentProxy zoneComponentProxy = zones[i].GetComponent<IZoneComponentProxy>();
			MoveCommands.Add(zoneComponentProxy.Key, new MoveCommand(this, zoneComponentProxy.Key, CommandType.MOVE));
		}
	}

	public bool CanMoveTo(string zoneId) => Wrapped.CanMoveTo(zoneId);
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
