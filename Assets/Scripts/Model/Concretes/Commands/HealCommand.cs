using UnityEngine;

public class HealCommand : BaseCommand
{
	public HealCommand() : base(CommandType.HEAL) { }

	public override void Execute()
	{
		Debug.Log("Heal 1 damage");
		base.Execute();
	}
}
