using UnityEngine;

public class PreventDamageCommand : BaseCommand
{
	public PreventDamageCommand() : base(CommandType.PREVENT_DAMAGE) { }

	public override void Execute()
	{
		Debug.Log("Prevent damage");
		base.Execute();
	}
}
