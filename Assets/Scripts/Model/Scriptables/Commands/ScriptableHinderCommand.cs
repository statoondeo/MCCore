using UnityEngine;

[CreateAssetMenu(fileName = "Command", menuName = "Commands/Hinder Command")]
public class ScriptableHinderCommand : ScriptableCommand
{
	[SerializeField] protected ScriptableValue Value;

	public override ICommand Create(IEntity parentEntity) => new HinderCommand(parentEntity, Value.GetValue());
}
