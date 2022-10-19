using UnityEngine;

public class BasicComponent : BaseComponent, IBasicComponent
{
	public string Location { get; protected set; }
	public int Order { get; protected set; }

	public BasicComponent() : base() { }

	public bool CanMoveTo(string zoneId) => Location != zoneId;
	public void MoveTo(string zoneId)
	{
		Debug.Log("Moved");
		Location = zoneId;
	}
	public void SetOrder(int order) { }
}
