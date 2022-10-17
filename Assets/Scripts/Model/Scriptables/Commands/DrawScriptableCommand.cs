using UnityEngine;

[CreateAssetMenu()]
public class DrawScriptableCommand : ScriptableCommand
{
	public override ICommand Create() => new DrawCommand();
}
