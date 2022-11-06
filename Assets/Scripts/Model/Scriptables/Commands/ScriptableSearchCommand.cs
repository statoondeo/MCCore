using UnityEngine;

[CreateAssetMenu(fileName = "Command", menuName = "Commands/Search Command")]
public class ScriptableSearchCommand : ScriptableCommand
{
	[SerializeField] protected ScriptableEntity SearchedCard;

	public override ICommand Create(IEntity parentEntity) => new SearchEncounterCardInDeckDiscardAndRevealItThenShuffleCommand(SearchedCard.Id, parentEntity.Owner);
}
