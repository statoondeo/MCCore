using UnityEngine;

[CreateAssetMenu()]
public class RemoveThreatsScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new ContainerCommand(new RemoveThreatsCommand());
}
