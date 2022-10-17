using UnityEngine;
public class ConfuseCommand : BaseCommand
{
	public ConfuseCommand() : base(CommandType.CONFUSE) { }

	public override void Execute()
	{
		Debug.Log("Confuse");
		base.Execute();
	}
}
