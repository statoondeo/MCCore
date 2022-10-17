using UnityEngine;

[CreateAssetMenu()]
public class ConfuseScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new ConfuseCommand();
}
