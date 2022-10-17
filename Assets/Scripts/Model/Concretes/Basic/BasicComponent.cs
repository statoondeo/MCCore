using System.Collections.Generic;

public class BasicComponent : BaseComponent, IBasicComponent
{
	public string Location { get; protected set; }
	public int Order { get; protected set; }

	public BasicComponent() : base() { }

	public void MoveTo(string zoneId) => Location = zoneId;
	public void SetOrder(int order) { }
}
