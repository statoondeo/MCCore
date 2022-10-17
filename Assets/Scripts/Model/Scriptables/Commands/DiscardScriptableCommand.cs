using UnityEngine;

[CreateAssetMenu()]
public class DiscardScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new DiscardCommand();
}
