using UnityEngine;

[CreateAssetMenu()]
public class SpendResourceScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new ContainerCommand(new SpendResourceCommand());
}
