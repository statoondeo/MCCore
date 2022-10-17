using UnityEngine;

[CreateAssetMenu()]
public class ReadyScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new ReadyCommand();
}
