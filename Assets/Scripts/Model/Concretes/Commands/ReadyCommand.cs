using UnityEngine;

public class ReadyCommand : BaseCommand
{
	public ReadyCommand() : base(CommandType.READY) { }

	public override void Execute()
	{
		Debug.Log("Ready");
		base.Execute();
	}
}
