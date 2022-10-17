using UnityEngine;

public class ExhaustCommand : BaseCommand
{
	public ExhaustCommand() : base(CommandType.EXHAUST) { }

	public override void Execute()
	{
		Debug.Log("Exhaust");
		base.Execute();
	}
}
