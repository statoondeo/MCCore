using UnityEngine;

[CreateAssetMenu()]
public class CompositeScriptableCommand : ScriptableCommand
{
	[SerializeField] string CommandType = "NONE";
	[SerializeField] ScriptableCommand[] Commands;

	public override ICommand Create()
	{
		ICommand[] commands = new ICommand[Commands.Length];
		for (int i = 0; i < Commands.Length; i++) commands[i] = Commands[i].Create();
		return(new CompositeCommand(commands, CommandType));
	}
}
