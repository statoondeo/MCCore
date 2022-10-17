using UnityEngine;

public class DiscardCommand : BaseCommand
{
	public DiscardCommand() : base(CommandType.DISCARD) { }

	public override void Execute()
	{
		Debug.Log("Discard card");
		base.Execute();
	}
}
