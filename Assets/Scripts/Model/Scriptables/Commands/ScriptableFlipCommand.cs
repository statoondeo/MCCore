using UnityEngine;

[CreateAssetMenu(fileName = "Flip Command", menuName = "Commands/Flip Command")]
public class ScriptableFlipCommand : ScriptableCommand
{
	public override ICommand Create(IEntity parentEntity) => new FlipToNextStageCommand(parentEntity);
}
