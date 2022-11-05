public class HinderCommand : ICommand
{
	protected IEntity Card;
	protected int Value;

	public HinderCommand(IEntity entity, int value)
	{
		Card = entity;
		Value = value;
	}

	public string Type => throw new System.NotImplementedException();
	public bool Done { get; protected set; }
	public bool CanExecute() => true;
	public void Execute()
	{
		Card.GetActiveFaceComponent<IThreatComponentProxy>().AddThreat(Value);
	}
}