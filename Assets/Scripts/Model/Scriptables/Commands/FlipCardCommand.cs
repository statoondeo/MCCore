
using UnityEngine;

public class FlipCardCommand : ICommand
{
	protected IEntity Card;

	public FlipCardCommand(IEntity player) => Card = player;

	public string Type => throw new System.NotImplementedException();
	public bool Done { get; protected set; }
	public bool CanExecute() => true;
	public void Execute() => Card.GetComponent<IFaceContainerComponentProxy>().FlipTo((Card.GetActiveFaceComponent<IStageComponentProxy>().Stage + 1).ToString());
}