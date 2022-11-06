using UnityEngine;

[CreateAssetMenu(fileName = "Command", menuName = "Commands/Discard Until Command")]
public class ScriptableDiscardDeckUntilCardAndRevealItCommand : ScriptableCommand
{
	[SerializeField] protected ScriptableCardType CardType;

	public override ICommand Create(IEntity parentEntity)
	{
		return new DiscardDeckUntilCardAndRevealItCommand(parentEntity.Owner, ServiceLocator.Get<ICardTypeService>().Get(CardType.Key));
	}
}
