public class HinderCommand : ICommand
{
	protected IEntity Card;
	protected int Value;

	public HinderCommand(IEntity entity, int value)
	{
		Card = entity;
		Value = value;
	}

	public string Type => CommandType.NONE;
	public bool Done { get; protected set; }
	public bool CanExecute() => true;
	public void Execute()
	{
		Card.GetActiveFaceComponent<IThreatComponentProxy>().AddThreat(Value);
		Done = true;
	}
}