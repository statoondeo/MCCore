using UnityEngine;

[CreateAssetMenu(fileName = "Search Command", menuName = "Commands/Search Command")]
public class ScriptableSearchCommand : ScriptableCommand
{
	[SerializeField] protected ScriptableEntity SearchedCard;

	public override ICommand Create(IEntity parentEntity) => new SearhEncounterCardInDeckDiscardAndRevealItThenShuffleCommand(SearchedCard.Id, parentEntity.Owner);
}
