using System;
using UnityEngine;

public class FlipCommand : BaseCommand
{
	protected Action<string> Action;
	protected string Parameter;

	public FlipCommand(Action<string> action, string parameter) : base(CommandType.FLIP)
	{
		Action = action;
		Parameter = parameter;
	}

	public override void Execute()
	{
		Debug.Log("Flip");
		Action.Invoke(Parameter);
		base.Execute();
	}
}
