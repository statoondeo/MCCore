using UnityEngine;

public class DrawCommand : BaseCommand
{
	public DrawCommand() : base(CommandType.DRAW) { }

	public override void Execute()
	{
		Debug.Log("Draw 1 card");
		base.Execute();
	}
}
