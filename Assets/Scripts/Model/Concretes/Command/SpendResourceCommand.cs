using UnityEngine;

public class SpendResourceCommand : BaseCommand
{
	public SpendResourceCommand() : base(CommandType.SPEND_RESOURCE) { }

	public override void Execute()
	{
		Debug.Log("Spend resource");
		base.Execute();
	}
}
