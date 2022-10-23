using UnityEngine;

public class RemoveThreatsCommand : BaseCommand
{
	public RemoveThreatsCommand() : base(CommandType.REMOVE_THREAT) { }

	public override void Execute()
	{
		Debug.Log("Remove threat");
		base.Execute();
	}
}
