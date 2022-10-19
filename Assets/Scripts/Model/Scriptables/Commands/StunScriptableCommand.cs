using UnityEngine;

[CreateAssetMenu()]
public class StunScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new ContainerCommand(new StunCommand());
}
