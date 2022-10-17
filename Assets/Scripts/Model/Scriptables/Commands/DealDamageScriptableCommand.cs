using UnityEngine;

[CreateAssetMenu()]
public class DealDamageScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new DealDamageCommand();
}
