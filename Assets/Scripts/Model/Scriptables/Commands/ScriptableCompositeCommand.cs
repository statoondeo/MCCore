using UnityEngine;

[CreateAssetMenu(fileName = "Command", menuName = "Commands/Composite Command")]
public class ScriptableCompositeCommand : ScriptableCommand
{
	[SerializeField] protected ScriptableCommand[] Commands;
	public override ICommand Create(IEntity parentEntity)
	{
		ICommand[] commands = new ICommand[Commands.Length];
		for (int i = 0; i < commands.Length; i++) commands[i] = Commands[i].Create(parentEntity);
		return (new CompositeCommand(commands));
	}
}
