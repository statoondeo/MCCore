using System.Text;

public class ZoneComponentProxy : BaseComponentProxy<IZoneComponent>, IZoneComponentProxy
{
	public string Key => Wrapped.Key;
	public string Name => Wrapped.Name;

	public ZoneComponentProxy(string key, string name) : base(new ZoneComponent(key, name)) { }

	public override string ToString()
	{
		StringBuilder sb = new();
		sb.AppendLine($"\t ZoneComponentProxy");
		sb.AppendLine($"\t\t Key={Key}");
		sb.AppendLine($"\t\t Name={Name}");
		return (sb.ToString());
	}
}
