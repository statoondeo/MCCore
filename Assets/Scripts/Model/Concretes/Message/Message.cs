using System;

public class Message
{
	protected Action<MessageArg> Listeners;

	public void Raise(MessageArg eventArg) => Listeners?.Invoke(eventArg);
	public void RegisterListener(Action<MessageArg> callback) => Listeners += callback;
	public void UnregisterListener(Action<MessageArg> callback) => Listeners -= callback;
}
