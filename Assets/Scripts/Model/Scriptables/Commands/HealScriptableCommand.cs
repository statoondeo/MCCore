using UnityEngine;

[CreateAssetMenu()]
public class HealScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new HealCommand();
}
