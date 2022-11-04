public class EmptyTankComponentMessageDecorator : BaseTankComponentDecorator
{
	protected readonly (MessageType, string) MessageToRaise;

	public EmptyTankComponentMessageDecorator(IActivable owner) : base(owner) => MessageToRaise = (MessageType.None, Messages.EMPTY_DECK);

	public override void Remove(IEntity item)
	{
		Inner.Remove(item);
		if (Count > 0) return;
		ServiceLocator.Get<IMessageService>().Raise(MessageToRaise);

	}
}
