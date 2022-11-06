using System;
using System.Collections.Generic;

public class MessageService : IMessageService
{
	protected readonly Dictionary<(MessageType, string), Message> MessagesAtlas;
	protected Action<(MessageType, string), MessageArg> RaiseAction;

	public MessageService() => MessagesAtlas = new Dictionary<(MessageType, string), Message>();

	protected Message GetEvent((MessageType, string) eventName) => MessagesAtlas.TryGetValue(eventName, out Message message) ? message : null;
	protected void MutedRaise((MessageType, string) eventName, MessageArg eventArg) { } // => Debug.Log($"Muted {eventName.Item1}/{eventName.Item2}");
	protected void UnMutedRaise((MessageType, string) eventName, MessageArg eventArg)
	{
		//Debug.Log($"Raise {eventName.Item1}/{eventName.Item2}");
		GetEvent(eventName)?.Raise(eventArg);
	}

	public void Raise((MessageType, string) eventName) => Raise(eventName, MessageArg.Empty);
	public void Raise((MessageType, string) eventName, MessageArg eventArg) => RaiseAction.Invoke(eventName, eventArg);
	public (MessageType, string) Register((MessageType, string) eventToListen, Action<MessageArg> callback)
	{
		Message message = GetEvent(eventToListen);
		if (null == message)
		{
			message = new Message();
			MessagesAtlas.Add(eventToListen, message);
		}
		message.RegisterListener(callback);
		return (eventToListen);
	}
	public void UnRegister((MessageType, string) eventToListen, Action<MessageArg> callback) => GetEvent(eventToListen)?.UnregisterListener(callback);
	public IService Initialize()
	{
		UnMute();
		return (this);
	}
	public void Mute() => RaiseAction = MutedRaise;
	public void UnMute() => RaiseAction = UnMutedRaise;
}
