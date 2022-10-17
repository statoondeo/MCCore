using UnityEngine;

[CreateAssetMenu()]
public class AddCounterScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new AddCounterCommand();
}
