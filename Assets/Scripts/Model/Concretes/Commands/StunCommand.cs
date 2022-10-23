using UnityEngine;
public class StunCommand : BaseCommand
{
	public StunCommand() : base(CommandType.STUN) { }

	public override void Execute()
	{
		Debug.Log("Stun");
		base.Execute();
	}
}
