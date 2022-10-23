using UnityEngine;

public class DealDamageCommand : BaseCommand
{
	public DealDamageCommand() : base(CommandType.DEAL_DAMAGE) { }

	public override void Execute()
	{
		Debug.Log("Deal damage");
		base.Execute();
	}
}
