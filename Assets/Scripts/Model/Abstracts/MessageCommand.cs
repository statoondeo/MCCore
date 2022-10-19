public class MessageCommand : BaseCommand
{
	protected MessageType MessageTiming;

	public MessageCommand(MessageType messageTiming, string messageType) : base(messageType) => MessageTiming = messageTiming;

	public override void Execute()
	{
		ServiceLocator.Get<IMessageService>().Raise((MessageTiming, Type));
		base.Execute();
	}
}