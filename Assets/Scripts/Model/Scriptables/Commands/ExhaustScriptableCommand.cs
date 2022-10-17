using UnityEngine;

[CreateAssetMenu()]
public class ExhaustScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new ExhaustCommand();
}
