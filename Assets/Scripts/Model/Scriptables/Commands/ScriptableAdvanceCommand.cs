using UnityEngine;

[CreateAssetMenu(fileName = "Command", menuName = "Commands/Advance Command")]
public class ScriptableAdvanceCommand : ScriptableCommand
{
	public override ICommand Create(IEntity parentEntity) => new AdvanceToNextStageCommand(parentEntity);
}
