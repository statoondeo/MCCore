using UnityEngine;
public class AddCounterCommand : BaseCommand
{
	public AddCounterCommand() : base(CommandType.ADD_COUNTER) { }

	public override void Execute()
	{
		Debug.Log("Add counnter");
		base.Execute();
	}
}
