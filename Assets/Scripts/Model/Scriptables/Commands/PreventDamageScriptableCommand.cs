using UnityEngine;

[CreateAssetMenu()]
public class PreventDamageScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new PreventDamageCommand();
}
